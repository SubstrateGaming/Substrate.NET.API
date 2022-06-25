using Ajuna.NetApi;
using Ajuna.NetApi.Model.AjunaCommon;
using Ajuna.NetApi.Model.Base;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using Ajuna.NetWallet;
using Ajuna.UnityInterface;
using Dot4GBot.AI;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dot4GBot
{
    partial class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new FileTarget("logfile")
            {
                FileName = "log.txt",
                DeleteOldFileOnStartup = true
            };

            var logconsole = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

            // Add this to your C# console app's Main method to give yourself
            // a CancellationToken that is canceled when the user hits Ctrl+C.
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Canceling...");
                cts.Cancel();
                e.Cancel = true;
            };

            try
            {
                Console.WriteLine("Press Ctrl+C to end.");
                await MainAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                // This is the normal way we close.
            }
        }

        private static async Task MainAsync(CancellationToken token)
        {
            SystemInteraction.ReadData = f => File.ReadAllText(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.DataExists = f => File.Exists(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.ReadPersistent = f => File.ReadAllText(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.PersistentExists = f => File.Exists(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.Persist = (f, c) => File.WriteAllText(Path.Combine(Environment.CurrentDirectory, f), c);

            Wallet wallet = new Wallet();
            wallet.Load("dev_walletA");
            await wallet.UnlockAsync("aA1234dd");
            //var mnemonic = "thing release visual carpet nation rebuild recipe trim tissue chair lumber buzz";
            //await wallet.CreateAsync("aA1234dd", mnemonic, "mnemonic_wallet");
            var name = wallet.Account.Value.Substring(0, 7);
            await wallet.StartAsync("ws://127.0.0.1:9944");

            var dot4gClient = new Dot4GClient(wallet,
                "ws://183c-84-75-48-249.ngrok.io",
                "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi",
                "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi");

            IBotAI logic = new RandomAI();

            NodeState nodeState = NodeState.None;
            WorkerState workerState = WorkerState.None;

            while (!token.IsCancellationRequested)
            {
                var SleepTime = 1000;
                Dot4GObj gameBoard = null;

                if (wallet.AccountInfo == null || wallet.AccountInfo.Data.Free.Value < 1000000000000)
                {
                    nodeState = NodeState.Faucet;
                }
                else
                {
                    var playerQueued = await dot4gClient.GetPlayerQueueAsync();
                    var runnerId = await dot4gClient.GetRunnerIdAsync();

                    if (playerQueued.Value == 0 && runnerId.Value == 0)
                    {
                        nodeState = NodeState.Queue;
                    }
                    else if (playerQueued.Value == 1 && runnerId.Value == 0)
                    {
                        nodeState = NodeState.Players;
                    }
                    else
                    {
                        var runnerState = await dot4gClient.GetRunnerStateAsync(runnerId);
                        if (runnerState is null)
                        {
                            throw new Exception($"Got a runner id {runnerId.Value}, but no state!");
                        }
                        else
                        {
                            switch (runnerState.Value)
                            {
                                case RunnerState.Queued:
                                    nodeState = NodeState.Worker;
                                    break;

                                case RunnerState.Accepted:
                                    nodeState = NodeState.Play;
                                    await dot4gClient.ConnectTeeAsync();
                                    break;

                                case RunnerState.Finished:
                                    nodeState = NodeState.Queue;
                                    workerState = WorkerState.None;
                                    gameBoard = null;
                                    await dot4gClient.DisconnectTeeAsync();
                                    break;
                            }
                        }
                    }
                }

                switch (nodeState)
                {
                    case NodeState.Faucet:
                        var faucet = await dot4gClient.FaucetAsync();
                        break;
                    case NodeState.Queue:
                        var queued = await dot4gClient.QueueAsync();
                        break;
                    case NodeState.None:
                        break;
                    case NodeState.Players:
                        break;
                    case NodeState.Worker:
                        break;
                    case NodeState.Play:
                        break;
                }

                if (nodeState == NodeState.Play)
                {
                    var balanceWorker = await dot4gClient.GetBalanceWorkerAsync();
                    if (balanceWorker is null || balanceWorker.Value < 100)
                    {
                        workerState = WorkerState.Faucet;
                    } 
                    else
                    {
                        gameBoard = await dot4gClient.GetGameBoardAsync();
                        if (gameBoard is null)
                        {
                            workerState = WorkerState.Wait;
                        } 
                        else if (gameBoard.GamePhase == GamePhase.Bomb)
                        {
                            var player = gameBoard.Players.Where(p => p.Address == wallet.Account.Value).ToList();
                            if (player.Count == 1 && player[0].Bombs > 0)
                            {
                                workerState = WorkerState.Bomb;
                            } 
                            else
                            {
                                workerState = WorkerState.Wait;
                            }
                        }
                        else if (gameBoard.GamePhase == GamePhase.Play)
                        {
                            if (gameBoard.Players[gameBoard.Next].Address == wallet.Account.Value)
                            {
                                workerState = WorkerState.Play;
                            }
                            else
                            {
                                workerState = WorkerState.Wait;
                            }
                        }
                    }

                    switch (workerState)
                    {
                        case WorkerState.None:
                            break;

                        case WorkerState.Faucet:
                            var faucet = await dot4gClient.FaucetWorkerAsync();
                            if (faucet)
                            {
                                SleepTime = 500;
                            }
                            break;

                        case WorkerState.Wait:
                            SleepTime = 100;
                            break;

                        case WorkerState.Bomb:
                            int[] bombPos = logic.Bombs(gameBoard);
                            var bomb = await dot4gClient.BombAsync(bombPos[0], bombPos[1]);
                            if (bomb)
                            {
                                SleepTime = 500;
                            }
                            break;

                        case WorkerState.Play:
                            (Side, int) move = logic.Play(gameBoard);
                            var stone = await dot4gClient.StoneAsync(move.Item1, move.Item2);
                            if (stone)
                            {
                                SleepTime = 500;
                            }
                            break;
                    }
                }

                // wait on extrinsic
                if (dot4gClient.HasExtrinsics > 0)
                {
                    while (dot4gClient.HasExtrinsics > 0)
                    {
                        Print(name, nodeState, workerState, true);
                        Console.WriteLine("+---------------------------------------+");
                        Thread.Sleep(500);
                    }
                    continue;
                }

                Print(name, nodeState, workerState);
                // print board here ...
                if (gameBoard != null)
                {
                    gameBoard.Print();
                } 
                else
                {
                    Console.WriteLine("+---------------------------------------+");
                }

                Thread.Sleep(SleepTime);
            }
        }

        private static void Print(string name, NodeState nodeState, WorkerState workerState, bool flag = false)
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| " + $"Name: {name}       Node: {nodeState}".PadRight(38) + "|");
            Console.WriteLine("| " + $"                  Worker: {workerState}".PadRight(38) + "|");
            switch (nodeState)
            {
                case NodeState.None:
                    break;
                case NodeState.Faucet:
                    Console.WriteLine("| " + $"Let's robe Alice faucet! ".PadRight(38) + "|");
                    break;
                case NodeState.Queue:
                    Console.WriteLine("| " + $"Queuing up, now.".PadRight(38) + "|");
                    break;
                case NodeState.Players:
                    Console.WriteLine("| " + $"Waiting for Player.".PadRight(38) + "|");
                    break;
                case NodeState.Play:
                    Console.WriteLine("| " + $"Playtime!".PadRight(38) + "|");
                    break;
                case NodeState.Worker:
                    Console.WriteLine("| " + $"Waiting on TEE.".PadRight(38) + "|");
                    break;
                default:
                    Console.WriteLine("| " + $" ".PadRight(38) + "|");
                    break;
            }

            if (flag)
            {
                Console.WriteLine("| " + $" Waiting on In-Block".PadRight(38) + "|");
            } 
            else 
            { 
                Console.WriteLine("| " + $" ".PadRight(38) + "|");
            }


        }
    }
}

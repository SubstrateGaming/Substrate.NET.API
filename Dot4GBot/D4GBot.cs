using Ajuna.NetApi.Model.AjunaCommon;
using Ajuna.NetApi.Model.Base;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using Ajuna.NetWallet;
using Ajuna.UnityInterface;
using Dot4GBot.AI;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Dot4GBot.Program;

namespace Dot4GBot
{
    internal class D4GBot
    {
        private Dot4GClient _uClient;
        private IBotAI _logic;

        private Wallet Wallet => _uClient.Wallet;

        private string Name => Wallet.Account.Value.Substring(0, 7);

        public D4GBot(Dot4GClient dot4gClient, IBotAI logic)
        {
            _uClient = dot4gClient;
            _logic = logic;
        }

        internal async Task RunAsync(CancellationToken token)
        {
            NodeState nodeState = NodeState.None;
            WorkerState workerState = WorkerState.None;

            while (!token.IsCancellationRequested)
            {
                var SleepTime = 1000;
                Dot4GObj gameBoard = null;

                if (Wallet.AccountInfo == null || Wallet.AccountInfo.Data.Free.Value < 1000000000000)
                {
                    nodeState = NodeState.Faucet;
                }
                else
                {
                    var playerQueued = await _uClient.GetPlayerQueueAsync();
                    var runnerId = await _uClient.GetRunnerIdAsync();

                    if (playerQueued.Value == 0 && runnerId.Value == 0)
                    {
                        nodeState = NodeState.Queue;
                    }
                    else if (playerQueued.Value > 0 && runnerId.Value == 0)
                    {
                        nodeState = NodeState.Players;
                    }
                    else
                    {
                        var runnerState = await _uClient.GetRunnerStateAsync(runnerId);
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
                                    await _uClient.ConnectTeeAsync();
                                    break;

                                case RunnerState.Finished:
                                    nodeState = NodeState.Queue;
                                    workerState = WorkerState.None;
                                    gameBoard = null;
                                    await _uClient.DisconnectTeeAsync();
                                    break;
                            }
                        }
                    }
                }

                switch (nodeState)
                {
                    case NodeState.Faucet:
                        var faucet = await _uClient.FaucetAsync();
                        break;
                    case NodeState.Queue:
                        var queued = await _uClient.QueueAsync();
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
                    var balanceWorker = await _uClient.GetBalanceWorkerAsync();
                    if (balanceWorker is null || balanceWorker.Value < 100)
                    {
                        workerState = WorkerState.Faucet;
                    }
                    else
                    {
                        gameBoard = await _uClient.GetGameBoardAsync();
                        if (gameBoard is null)
                        {
                            workerState = WorkerState.Wait;
                        }
                        else if (gameBoard.GamePhase == GamePhase.Bomb)
                        {
                            var player = gameBoard.Players.Where(p => p.Address == Wallet.Account.Value).ToList();
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
                            if (gameBoard.Players[gameBoard.Next].Address == Wallet.Account.Value)
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
                            var faucet = await _uClient.FaucetWorkerAsync();
                            if (faucet)
                            {
                                SleepTime = 500;
                            }
                            break;

                        case WorkerState.Wait:
                            SleepTime = 100;
                            break;

                        case WorkerState.Bomb:
                            int[] bombPos = _logic.Bombs(gameBoard);
                            var bomb = await _uClient.BombAsync(bombPos[0], bombPos[1]);
                            if (bomb)
                            {
                                SleepTime = 500;
                            }
                            break;

                        case WorkerState.Play:
                            (Side, int) move = _logic.Play(gameBoard);
                            var stone = await _uClient.StoneAsync(move.Item1, move.Item2);
                            if (stone)
                            {
                                SleepTime = 500;
                            }
                            break;
                    }
                }

                // wait on extrinsic
                if (_uClient.HasExtrinsics > 0)
                {
                    while (_uClient.HasExtrinsics > 0)
                    {
                        Print(Name, nodeState, workerState, true);
                        Console.WriteLine("+---------------------------------------+");
                        Thread.Sleep(500);
                    }
                    continue;
                }

                Print(Name, nodeState, workerState);
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

        private void Print(string name, NodeState nodeState, WorkerState workerState, bool flag = false)
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
using Ajuna.NetApi;
using Ajuna.NetWallet;
using Ajuna.UnityInterface;
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
    class Program
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
            await wallet.CreateAsync("aA1234dd");
            await wallet.StartAsync("ws://127.0.0.1:9944");

            var dot4gClient = new Dot4GClient(wallet, 
                "ws://87e8-84-75-48-249.ngrok.io", 
                "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi", 
                "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi");

            Console.WriteLine($"My Address => {wallet.Account.Value}");

            if (await dot4gClient.FaucetAsync())
            {
                Console.Write($"faucet");
                while (dot4gClient.HasExtrinsics > 0)
                {
                    Thread.Sleep(1000);
                    Console.Write($".");

                }
                Console.WriteLine($"ok");
            }

            if (await dot4gClient.ConnectTeeAsync())
            {
                Console.WriteLine($"worker connected!");
            }

            if (await dot4gClient.FaucetWorkerAsync())
            {
                Console.WriteLine($"worker faucet!");
            }

            var registerId = await dot4gClient.GetRegisterIdAsync();
 
                //if (await dot4gClient.GetRegisterIdAsync())
                //{
                //    var state = Utils.Bytes2HexString(dot4gClient.RunnerState2.Value.Value.Select(p => p.Value).ToArray());
                //    Console.WriteLine($"GameId - {dot4gClient.GameId.Value} / {dot4gClient.RunnerState1}[{state}]");
                //}

                //if (dot4gClient.GameId == null && await dot4gClient.QueueAsync())
                //{
                //    Console.Write($"queue");
                //    while (dot4gClient.HasExtrinsics > 0)
                //    {
                //        Thread.Sleep(1000);
                //        Console.Write($".");

                //    }
                //    Console.WriteLine($"ok");
                //}

                //if (await dot4gClient.QueueStateAsync())
                //{
                //    var state = Utils.Bytes2HexString(dot4gClient.RunnerState2.Value.Value.Select(p => p.Value).ToArray());
                //    Console.WriteLine($"GameId - {dot4gClient.GameId.Value} / {dot4gClient.RunnerState1}[{state}]");
                //}

                //Console.Write($"waiting in queue");
                //while (dot4gClient.GameId == null || dot4gClient.RunnerState1 == Ajuna.NetApi.Model.AjunaCommon.RunnerState.Queued)
                //{
                //    if (await dot4gClient.QueueStateAsync())
                //    {
                //        Thread.Sleep(1000);
                //        Console.Write($".");
                //    }
                //}
                //Console.WriteLine($"{dot4gClient.RunnerState1.ToString().ToLower()}");


                //Console.Write($"gameboard");
                //while (dot4gClient.Dot4GObj == null)
                //{
                //    if (await dot4gClient.GameBoardAsync())
                //    {
                //        Console.Write($".");
                //    }
                //}
                //Console.WriteLine($"ok");

                //dot4gClient.Dot4GObj.Print();

        }
    }
}

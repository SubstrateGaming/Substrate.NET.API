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
        private static string _ngrokUrl = "2934-178-197-216-190.ngrok.io";
        private static string _mrenclave = "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi";
        private static string _devWallet = "dev_walletA";

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


            Console.Write("\r\nMRENCLAVE[" + _mrenclave + "]=: ");
            var mrenclave = Console.ReadLine();
            if (mrenclave.Count() > 0)
            {
                _mrenclave = mrenclave;
            }
            Console.Write("\r\nNGROK URL[" + _ngrokUrl + "]=: ");
            var ngrokUrl = Console.ReadLine();
            if (ngrokUrl.Count() > 0)
            {
                _ngrokUrl = ngrokUrl;
            }

            Console.WriteLine("Choose wallet to load:");
            Console.WriteLine("A) dev_walletA");
            Console.WriteLine("B) dev_walletB");
            Console.WriteLine("C) dev_walletC");
            Console.Write("\r\nSelect a wallet [A,B,C]: ");
            switch (Console.ReadLine())
            {
                case "A":
                    _devWallet = "dev_walletA";
                    break;
                case "B":
                    _devWallet = "dev_walletB";
                    break;
                case "C":
                    _devWallet = "dev_walletC";
                    break;
                default:
                    _devWallet = "dev_walletA";
                    break;
            }

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
            wallet.Load(_devWallet);
            await wallet.UnlockAsync("aA1234dd");
            //var mnemonic = "adult foster code famous extend museum attend trade stomach fresh love dwarf";
            //await wallet.CreateAsync("aA1234dd", mnemonic, "mnemonic_wallet");
            var name = wallet.Account.Value.Substring(0, 7);
            await wallet.StartAsync("ws://127.0.0.1:9944");

            var dot4gClient = new Dot4GClient(wallet,
                "ws://" + _ngrokUrl,
                _mrenclave,
                _mrenclave);

            IBotAI logic = new RandomAI();

            var bot = new D4GBot(dot4gClient, logic);
            await bot.RunAsync(token);

        }


    }
}

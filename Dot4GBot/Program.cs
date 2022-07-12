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
        private static string _ngrokUrl = "030a-84-75-48-249.ngrok.io";
        private static string _mrenclave = "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi";
        private static Random _random = new Random();

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

            Console.ReadLine();
        }

        private static async Task MainAsync(CancellationToken token)
        {
            SystemInteraction.ReadData = f => File.ReadAllText(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.DataExists = f => File.Exists(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.ReadPersistent = f => File.ReadAllText(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.PersistentExists = f => File.Exists(Path.Combine(Environment.CurrentDirectory, f));
            SystemInteraction.Persist = (f, c) => File.WriteAllText(Path.Combine(Environment.CurrentDirectory, f), c);

            Wallet wallet = new Wallet();
            
            var randomBytes = new byte[16];
            _random.NextBytes(randomBytes);
            var mnemonic = string.Join(' ', Mnemonic.MnemonicFromEntropy(randomBytes, Mnemonic.BIP39Wordlist.English));

            await wallet.CreateAsync("aA1234dd", mnemonic, "mnemonic_wallet");
            await wallet.StartAsync("ws://127.0.0.1:9944");

            var dot4gClient = new Dot4GClient(wallet,
                "ws://" + _ngrokUrl,
                _mrenclave,
                _mrenclave);

            IBotAI logic = new RandomAI();

            var bot = new D4GBot(dot4gClient, logic, DisplayType.UI);
            await bot.RunAsync(token);

            foreach(var track in bot.Tracker)
            {
                Console.WriteLine($"track {track.Key} = {track.Value[0]} @ {track.Value[1]/1000}s => avg. {track.Value[1]/track.Value[0]}ms");
            }
        }


    }
}

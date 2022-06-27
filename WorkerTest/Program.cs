using Ajuna.NetApi;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerTest
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
            var substrateClient = new SubstrateClient(new Uri("ws://183c-84-75-48-249.ngrok.io"));
            await substrateClient.ConnectAsync(false, false, false, CancellationToken.None);

            Console.WriteLine($"substrateClient.IsConnected = {substrateClient.IsConnected}");

            var shieldingTask = await substrateClient.InvokeAsync<string>("author_getShieldingKey", null, CancellationToken.None);

            Console.WriteLine($"shieldingTask = {shieldingTask}");


        }
    }
}

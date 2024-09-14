using Serilog;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Configure Serilog for logging
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();

        // Set up a cancellation token for graceful shutdown
        CancellationTokenSource cts = new CancellationTokenSource();

        await MainAsync(cts.Token);

        // Keep the application alive to continue monitoring the connection
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        // Cleanup logging resources
        await Log.CloseAndFlushAsync();
    }

    private static async Task MainAsync(CancellationToken token)
    {
        // Create the client
        string substrateNodeUrl = "wss://rpc-parachain.bajun.network";
        var client = new SubstrateClient(new Uri(substrateNodeUrl), ChargeTransactionPayment.Default());

        while (!token.IsCancellationRequested)
        {
            // Ensure the client is connected
            if (!client.IsConnected)
            {
                Log.Information("Attempting to connect to the client...");
                await client.ConnectAsync(
                    useMetaData: true,
                    standardSubstrate: true,
                    maxRetryAttempts: 5,
                    delayRetryMilliseconds: 5000,
                    token: token
                );
                Log.Information("Client connected successfully.");
            }

            var currentBlocknumber = await client.State.GetStorageAsync(Utils.HexToByteArray("0x26aa394eea5630e07c48ae0c9558cef702a5c1b19ab7a04f536c519aca4983ac"), (string)null, token);
            Log.Information("MainAsync running... block: {blocknumber}", currentBlocknumber.ToString());

            // Wait before next call
            await Task.Delay(12000);
        }

        // Gracefully shut down
        await client.CloseAsync();
    }
}
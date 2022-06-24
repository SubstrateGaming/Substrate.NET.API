using Ajuna.NetApi;
using Ajuna.NetApi.Model.AjunaWorker;
using Ajuna.NetApi.Model.Base;
using Ajuna.NetApi.Model.PalletBoard;
using Ajuna.NetApi.Model.PalletConnectfour;
using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using Chaos.NaCl;
using Nerdbank.Streams;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;
using Org.BouncyCastle.Security;
using Schnorrkel.Keys;
using SimpleBase;
using StreamJsonRpc;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTee
{
    partial class Program
    {
        //private const string Websocketurl = "ws://127.0.0.1:9944";
        //private const string Websocketurl = "wss://127.0.0.1:2001";
        //private const string Websocketurl = "ws://127.0.0.1:2000";
        // private const string Websocketurl = "wss://demo.piesocket.com/v3/channel_1?api_key=oCdCMcMPQpbvNjUIzqtvF1d2X2okWpDQj4AwARJuAgtjhzKxVEjQU6IdCjwm&notify_self";

        // Secret Key URI `//Alice` is account:
        // Secret seed:      0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
        // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Account ID:       0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // SS58 Address:     5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        public static MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);
        public static Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToBytes(), MiniSecretAlice.GetPair().Public.Key);

        // Secret Key URI `//Bob` is account:
        // Secret seed:      0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
        // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Account ID:       0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // SS58 Address:     5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        public static MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public static Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToBytes(), MiniSecretBob.GetPair().Public.Key);

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

        private static async Task MainAsync(CancellationToken cancellationToken)
        {
            var ngrok = "wss://6a4b-84-75-48-249.ngrok.io";
            var shardHex = "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi";
            var mrenclaveHex = "Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi";

            await TransactionNodeTestAsync("ws://127.0.0.1:9944");

            //await LaunchGameAsync("ws://127.0.0.1:9944");

            //await TransactionWorkerTestAsync(
            //    websocketurl: ngrok,
            //    shardHex: shardHex,
            //    mrenclaveHex: mrenclaveHex
            //);

            //Thread.Sleep(10000);

            //await PlayGameAsync(
            //    websocketurl: ngrok,
            //    shardHex: shardHex,
            //    mrenclaveHex: mrenclaveHex
            //);

            //while (true)
            //{
            //    Thread.Sleep(10000);

            //    await LaunchGameAsync("ws://127.0.0.1:9944");

            //    Thread.Sleep(10000);

            //    await PlayGameAsync(
            //         websocketurl: ngrok,
            //         shardHex: shardHex,
            //         mrenclaveHex: mrenclaveHex
            //     );
            //}


            //await BenchmarkNodeAsync("ws://127.0.0.1:9944");

            //await BenchmarkWorkerAsync(
            //    websocketurl: ngrok,
            //    shardHex: shardHex,
            //    mrenclaveHex: mrenclaveHex
            //);

        }

        private static async Task RunRPCMethodsTestAsync(string websocketurl)
        {
            var client = new SubstrateClientExt(new Uri(websocketurl));

            await client.ConnectAsync(false, false, false, CancellationToken.None);

            await client.RPCMethodsAsync();

            // close connection
            await client.CloseAsync();
        }

        private static async Task TransactionNodeTestAsync(string websocketurl)
        {
            var extrinsicWait = 10000;

            var client = new SubstrateClientExt(new Uri(websocketurl));

            var cts = new CancellationTokenSource();
            await client.ConnectAsync(false, true, true, cts.Token);

            var accountAlice = new AccountId32();
            accountAlice.Create(Utils.GetPublicKeyFrom(Alice.Value));

            var accountBob = new AccountId32();
            accountBob.Create(Utils.GetPublicKeyFrom(Bob.Value));

            var accountZuerich = new AccountId32();
            accountZuerich.Create(Utils.GetPublicKeyFrom("5FfzQe73TTQhmSQCgvYocrr6vh1jJXEKB8xUB6tExfpKVCEZ"));

            var accountInfoAlice = await client.SystemStorage.Account(accountAlice, CancellationToken.None);
            Console.WriteLine($"Alice Free Balance = {accountInfoAlice.Data.Free.Value.ToString()}");

            var accountInfoBob = await client.SystemStorage.Account(accountBob, CancellationToken.None);
            Console.WriteLine($"Bob Free Balance = {accountInfoBob.Data.Free.Value.ToString()}");

            var multiAddressBob = new EnumMultiAddress();
            multiAddressBob.Create(MultiAddress.Id, accountBob);

            var amount = new BaseCom<U128>();
            amount.Create(100000);
            //500000000000000

            var extrinsicMethod = Ajuna.NetApi.Model.PalletBalances.BalancesCalls.Transfer(multiAddressBob, amount);

            // transaction from alice to bob for a certain amount of tokens
            var subscription1 = await client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Alice, 0, 64, cts.Token);
            Console.WriteLine($"Subscription ID for Transfer {subscription1}");
            Thread.Sleep(extrinsicWait);

            accountInfoAlice = await client.SystemStorage.Account(accountAlice, CancellationToken.None);
            Console.WriteLine($"Alice Free Balance = {accountInfoAlice.Data.Free.Value}");

            accountInfoBob = await client.SystemStorage.Account(accountBob, CancellationToken.None);
            Console.WriteLine($"Bob Free Balance = {accountInfoBob.Data.Free.Value}");


            // move funds ...
            var amountForZuerich = new BaseCom<U128>();
            amountForZuerich.Create(500000000000000);

            var multiAddressZuerich = new EnumMultiAddress();
            multiAddressZuerich.Create(MultiAddress.Id, accountZuerich);

            var extrinsicMethodZuerich = Ajuna.NetApi.Model.PalletBalances.BalancesCalls.Transfer(multiAddressZuerich, amountForZuerich);

            // transaction from zuerich to bob for a certain amount of tokens
            var subscription2 = await client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethodZuerich, Alice, 0, 64, cts.Token);
            Console.WriteLine($"Subscription ID for Transfer {subscription2}");
            Thread.Sleep(extrinsicWait);

            var accountInfoZuerich = await client.SystemStorage.Account(accountZuerich, CancellationToken.None);
            Console.WriteLine($"Zuerich Free Balance = {accountInfoZuerich.Data.Free.Value}");

            // close connection
            await client.CloseAsync();

        }

        private static async Task TransactionWorkerTestAsync(string websocketurl, string shardHex, string mrenclaveHex)
        {
            /**
             * docker ps
             * docker exec -it 7aeac2a21f93 /bin/bash
             * ./integritee-cli trusted transfer //Alice //Bob 1000 --mrenclave 2CMLqGnL56xp4qkVDq4pmKKYJn4btSGF9brgGEsGW3qm --direct
             */

            var client = new SubstrateClientExt(new Uri(websocketurl));

            await client.ConnectAsync(false, false, false, CancellationToken.None);

            var shieldingKey = await client.ShieldingKeyAsync();

            //Thread.Sleep(2000);

            // - TrustedOperation

            var player = Alice;

            var nonce = await client.GetNonce(player, shieldingKey, shardHex);
            if (nonce != null) Console.WriteLine($"Nonce[{player.Value}] = {nonce.Value}");

            //var boardStruct1 = await client.GetBoardStructAsync(player, shieldingKey, shardHex);
            //if (boardStruct1 != null) PrintBoard(boardStruct1);

            //var hash = await client.PlayTurnAsync(Alice, 3, shieldingKey, shardHex, mrenclaveHex);

            Thread.Sleep(2000);

            var balance1 = await client.GetFreeBalanceAsync(player, shieldingKey, shardHex);
            if (balance1 != null) Console.WriteLine($"Balance[{player.Value}] = {balance1.Value}");

            Thread.Sleep(2000);

            var hash = await client.BalanceTransferAsync(Alice, Bob, (uint)100000, shieldingKey, shardHex, mrenclaveHex);
            Console.WriteLine($"BalanceTransfer[{hash}] Alice -[100000]-> Bob");

            Thread.Sleep(2000);

            var balance2 = await client.GetFreeBalanceAsync(player, shieldingKey, shardHex);
            if (balance2 != null) Console.WriteLine($"Balance[{player.Value}] = {balance2.Value}");

            Thread.Sleep(2000);

            // close connection
            await client.CloseAsync();
        }

        private static async Task BenchmarkNodeAsync(string websocketurl)
        {
            var client = new SubstrateClientExt(new Uri(websocketurl));

            var cts = new CancellationTokenSource();
            await client.ConnectAsync(false, true, true, cts.Token);

            var accountAlice = new AccountId32();
            accountAlice.Create(Utils.GetPublicKeyFrom(Alice.Value));
            var accountBob = new AccountId32();
            accountBob.Create(Utils.GetPublicKeyFrom(Bob.Value));

            var iterations = 100;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                var accountInfoAlice = await client.SystemStorage.Account(accountAlice, CancellationToken.None);
                if (accountInfoAlice is null) throw new Exception("Benchmark failed!");
            }
            stopwatch.Stop();
            Console.WriteLine($"SystemStorage(Account) = ~{stopwatch.Elapsed.TotalMilliseconds / iterations} ms");

            // close connection
            await client.CloseAsync();
        }

        private static async Task BenchmarkWorkerAsync(string websocketurl, string shardHex, string mrenclaveHex)
        {
            /**
             * docker ps
             * docker exec -it 7aeac2a21f93 /bin/bash
             * ./integritee-cli trusted transfer //Alice //Bob 1000 --mrenclave 2CMLqGnL56xp4qkVDq4pmKKYJn4btSGF9brgGEsGW3qm --direct
             */

            var client = new SubstrateClientExt(new Uri(websocketurl));
            await client.ConnectAsync(false, false, false, CancellationToken.None);
            var shieldingKey = await client.ShieldingKeyAsync();

            var player = Alice;
            var iterations = 100;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                var balance = await client.GetFreeBalanceAsync(player, shieldingKey, shardHex);
                if (balance is null) throw new Exception("Benchmark failed!");
            }
            stopwatch.Stop();
            Console.WriteLine($"{iterations} TrustedGettter(FreeBalance) = Total {stopwatch.Elapsed.TotalMilliseconds / iterations}");

            Thread.Sleep(2000);

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                var hash = await client.BalanceTransferAsync(Alice, Bob, (uint)1000, shieldingKey, shardHex, mrenclaveHex);
                if (hash is null) throw new Exception("Benchmark failed!");
            }
            stopwatch.Stop();
            Console.WriteLine($"{iterations} TrustedCall(BalanceTransfer) = Total {stopwatch.Elapsed.TotalMilliseconds / iterations}");

            // close connection
            await client.CloseAsync();
        }

        /// <summary>
        /// Simple extrinsic tester
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="extrinsicUpdate"></param>
        private static void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
        {
            switch (extrinsicUpdate.ExtrinsicState)
            {
                case ExtrinsicState.None:
                    if (extrinsicUpdate.InBlock?.Value.Length > 0)
                    {
                        Console.WriteLine($"{subscriptionId}: InBlock {extrinsicUpdate.InBlock.Value}");
                    }
                    else if (extrinsicUpdate.Finalized?.Value.Length > 0)
                    {
                        Console.WriteLine($"{subscriptionId}: Finalized {extrinsicUpdate.Finalized.Value}");
                    }
                    break;
                case ExtrinsicState.Future:
                    break;
                case ExtrinsicState.Ready:
                    break;
                case ExtrinsicState.Dropped:
                    break;
                case ExtrinsicState.Invalid:
                    break;
                default:
                    break;
            }
        }

        private static async Task LaunchGameAsync(string websocketurl)
        {
            var extrinsicWait = 10000;

            var accountAlice = new AccountId32();
            accountAlice.Create(Utils.GetPublicKeyFrom(Alice.Value));

            var accountBob = new AccountId32();
            accountBob.Create(Utils.GetPublicKeyFrom(Bob.Value));

            var client = new SubstrateClientExt(new Uri(websocketurl));

            var cts = new CancellationTokenSource();
            await client.ConnectAsync(false, true, true, cts.Token);

            var gameQueuePre = await client.GameRegistryStorage.Queued(CancellationToken.None);
            Console.WriteLine($"GameRegistry Queue Pre = {gameQueuePre}");

            var extrinsicMethod = Ajuna.NetApi.Model.PalletGameRegistry.GameRegistryCalls.Queue();

            // Alice queues for a game ...
            var subscription1 = await client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Alice, 0, 64, cts.Token);
            Console.WriteLine($"Queued Alice {subscription1}");
            Thread.Sleep(extrinsicWait);

            // find game reference
            var gameIdAlice1 = await client.GameRegistryStorage.Players(accountAlice, cts.Token);
            Console.WriteLine($"GameReference for Alice {gameIdAlice1}");

            Thread.Sleep(2000);

            // Bob queues for a game ...
            var subscription2 = await client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Bob, 0, 64, cts.Token);
            Console.WriteLine($"Queued Bob {subscription2}");
            Thread.Sleep(extrinsicWait);

            // find game reference
            var gameId = await client.GameRegistryStorage.Players(accountAlice, cts.Token);
            Console.WriteLine($"GameReference for Alice {gameId}");

            var gameIdBob = await client.GameRegistryStorage.Players(accountBob, cts.Token);
            Console.WriteLine($"GameReference for Bob {gameIdBob}");

            if (gameId.Value == gameIdBob.Value && gameIdBob.Value > 0)
            {
                var gameRunnerInfo1 = await client.RunnerStorage.Runners(gameId, cts.Token);
                Console.WriteLine($"Game Runner Info for Alice & Bob {gameRunnerInfo1.Value}");

                Thread.Sleep(20000);

                var gameRunnerInfo2 = await client.RunnerStorage.Runners(gameId, cts.Token);
                Console.WriteLine($"Game Runner Info for Alice & Bob {gameRunnerInfo2.Value}");
            }

            // close connection
            await client.CloseAsync();
        }

        private static async Task PlayGameAsync(string websocketurl, string shardHex, string mrenclaveHex)
        {
            /**
             * docker ps
             * docker exec -it 7aeac2a21f93 /bin/bash
             * ./integritee-cli trusted transfer //Alice //Bob 1000 --mrenclave 2CMLqGnL56xp4qkVDq4pmKKYJn4btSGF9brgGEsGW3qm --direct
             */
            var random = new Random(0);
            var sleep = 500;
            var client = new SubstrateClientExt(new Uri(websocketurl));

            Console.WriteLine("*** - ConnectAsync      - ***************************************************************");
            await client.ConnectAsync(false, false, false, CancellationToken.None);

            Console.WriteLine("*** - ShieldingKeyAsync - ***************************************************************");
            var shieldingKey = await client.ShieldingKeyAsync();
            var player = Bob;

            Console.WriteLine("*** - GetBoardGameAsync - ***************************************************************");
            var boardGame = await client.GetBoardGameAsync(player, shieldingKey, shardHex);
            if (boardGame == null) throw new Exception($"No board Game, please check!");
            var d4gObj = new Dot4GObj(boardGame);
            d4gObj.Print();

            while (d4gObj.GamePhase == Ajuna.NetApi.Model.Base.GamePhase.Bomb && d4gObj.Players.Where(p => p.Bombs > 0).Select(p => p).ToList().Any())
            {
                var bombPlayers = d4gObj.Players.Where(p => p.Bombs > 0).Select(p => p).ToList();
                if (bombPlayers.First().Address == Alice.Value)
                {
                    player = Alice;
                }
                else if (bombPlayers.First().Address == Bob.Value)
                {
                    player = Bob;
                }

                Console.WriteLine("*** - PlayTurnAsync     - ***************************************************************");
                var coord = d4gObj.EmptySlots[random.Next(d4gObj.EmptySlots.Count)];
                Console.WriteLine($"PlayTurnAsync {player.Value} play bomb [{coord[0]}/{coord[0]}]");
                var hash1 = await client.PlayTurnAsync(
                    player,
                    SgxGameTurn.DropBomb(coord),
                    shieldingKey, shardHex, mrenclaveHex);
                Console.WriteLine($"Player Turn Transaction hash = {hash1}");
                Thread.Sleep(sleep);

                Console.WriteLine("*** - GetBoardGameAsync - ***************************************************************");
                boardGame = await client.GetBoardGameAsync(player, shieldingKey, shardHex);
                if (boardGame == null) throw new Exception($"No board Game, please check!");
                d4gObj = new Dot4GObj(boardGame);
                d4gObj.Print();
            }

            while (d4gObj.GamePhase == Ajuna.NetApi.Model.Base.GamePhase.Play && d4gObj.Winner is null)
            {
                var nextPlayer = d4gObj.Players[d4gObj.Next];
                if (nextPlayer.Address == Alice.Value)
                {
                    player = Alice;
                }
                else if (nextPlayer.Address == Bob.Value)
                {
                    player = Bob;
                }

                Console.WriteLine("*** - PlayTurnAsync     - ***************************************************************");
                if (d4gObj.PossibleMoves.Count == 0)
                {
                    throw new Exception("No more moves possible!");
                }
                var move = d4gObj.PossibleMoves[random.Next(d4gObj.PossibleMoves.Count())];

                Console.WriteLine($"PlayTurnAsync {player.Value} play stone [{move.Item1}/{move.Item2}]");
                var hash2 = await client.PlayTurnAsync(
                    player,
                    SgxGameTurn.DropStone(move.Item1, (byte)move.Item2),
                    shieldingKey, shardHex, mrenclaveHex);
                Console.WriteLine($"Player Turn Transaction hash = {hash2}");
                Thread.Sleep(sleep);

                Console.WriteLine("*** - GetBoardGameAsync - ***************************************************************");
                boardGame = await client.GetBoardGameAsync(player, shieldingKey, shardHex);
                if (boardGame == null) throw new Exception($"No board Game, please check!");
                d4gObj = new Dot4GObj(boardGame);
                d4gObj.Print();
            }

            //Console.WriteLine("*** - PlayTurnAsync     - ***************************************************************");
            //var coords = d4gObj.GetCoords(Ajuna.NetApi.Model.Base.Cell.Empty);
            //Console.WriteLine($"PlayTurnAsync {player.Value} play bomb [{coords.First()[0]}/{coords.First()[1]}]");
            //var hash = await client.PlayTurnAsync(
            //    player, 
            //    SgxGameTurn.DropBomb(new int[] { 0, 1}), 
            //    shieldingKey, shardHex, mrenclaveHex);
            //Console.WriteLine($"Player Turn Transaction hash = {hash}");
            //Thread.Sleep(sleep);

            //Console.WriteLine("*** - PlayTurnAsync     - ***************************************************************");
            //Console.WriteLine($"PlayTurnAsync {player.Value} play stone [{Side.North}/6]");
            //var hash1 = await client.PlayTurnAsync(
            //    player, 
            //    SgxGameTurn.DropStone(Side.North, (byte)6), 
            //    shieldingKey, shardHex, mrenclaveHex);
            //Console.WriteLine($"Player Turn Transaction hash = {hash1}");
            //Thread.Sleep(sleep);

            //Console.WriteLine("*** - GetBoardGameAsync - ***************************************************************");
            //boardGame = await client.GetBoardGameAsync(player, shieldingKey, shardHex);
            //if (boardGame == null) throw new Exception($"No board Game, please check!");
            //d4gObj = new Dot4GObj(boardGame);
            //d4gObj.Print();
            //Thread.Sleep(sleep);

            /*
            boardGame = await client.GetBoardGameAsync(player, shieldingKey, shardHex);
            Console.WriteLine("*** - GetBoardGameAsync - ***************************************************************");
            if (boardGame != null)
            {
                Console.WriteLine($"BoardId[{boardGame.BoardId.Value}] {String.Join(" vs. ", boardGame.Players.Value.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())))}");
                Console.WriteLine($"- State.NextPlayer = {boardGame.State.NextPlayer.Value}");
                Console.WriteLine($"- State.Players = {String.Join(" vs. ", boardGame.State.Players.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())))}");
                // Guessing: Console.WriteLine($"- State.Solution = {boardGame.State.Solution.Value}");

                var players = boardGame.Players.Value.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())).ToArray();
                var nextPlayer = players[boardGame.State.NextPlayer.Value];
                if (nextPlayer == Alice.Value)
                {
                    player = Alice;
                }
                else if (nextPlayer == Bob.Value)
                {
                    player = Bob;
                }
            }
            else
            {
                Console.WriteLine($"No board Game, please check!");
            }

            Console.WriteLine("*** - PlayTurnAsync     - ***************************************************************");
            play = 42;
            Console.WriteLine($"PlayTurnAsync {player.Value} play {play}");
            hash = await client.PlayTurnAsync(player, play, shieldingKey, shardHex, mrenclaveHex);
            Console.WriteLine($"Player Turn Transaction hash = {hash}");

            Thread.Sleep(sleep);

            boardGame = await client.GetBoardGameAsync(player, shieldingKey, shardHex);
            Console.WriteLine("*** - GetBoardGameAsync - ***************************************************************");
            if (boardGame != null)
            {
                Console.WriteLine($"BoardId[{boardGame.BoardId.Value}] {String.Join(" vs. ", boardGame.Players.Value.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())))}");
                Console.WriteLine($"- State.NextPlayer = {boardGame.State.NextPlayer.Value}");
                Console.WriteLine($"- State.Players = {String.Join(" vs. ", boardGame.State.Players.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())))}");
                // Guessing: Console.WriteLine($"- State.Solution = {boardGame.State.Solution.Value}");

                var players = boardGame.Players.Value.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())).ToArray();
                var nextPlayer = players[boardGame.State.NextPlayer.Value];
                if (nextPlayer == Alice.Value)
                {
                    player = Alice;
                }
                else if (nextPlayer == Bob.Value)
                {
                    player = Bob;
                }
            }
            else
            {
                Console.WriteLine($"No board Game, please check!");
            }*/

            // close connection
            Console.WriteLine("*** - CloseAsync         - ***************************************************************");
            await client.CloseAsync();
        }

        private static Account GetNextPlayer(BoardGame boardGame)
        {
            var players = boardGame.Players.Value.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())).ToArray();
            var nextPlayer = players[boardGame.State.NextPlayer.Value];
            if (nextPlayer == Alice.Value)
            {
                return Alice;
            }
            else if (nextPlayer == Bob.Value)
            {
                return Bob;
            }

            return null;
        }
    }

}

using Ajuna.NetApi;
using Ajuna.NetApi.Model.AjunaCommon;
using Ajuna.NetApi.Model.AjunaWorker;
using Ajuna.NetApi.Model.Base;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.SpRuntime;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using Ajuna.NetWallet;
using Schnorrkel.Keys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Ajuna.UnityInterface
{
    public class Dot4GClient
    {
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

        private Wallet _wallet;

        private SubstrateClientExt _workerClient;

        private RSAParameters _shieldingKey;

        private string _shardHex;

        private string _mrenclaveHex;

        public Dictionary<string, string> _extrinsicStates;

        public bool IsTeeConnected => _workerClient.IsConnected;
        public int HasExtrinsics => _extrinsicStates.Count;

        public Dot4GClient(Wallet wallet, string workerUrl, string shardHex, string mrenclaveHex)
        {
            _wallet = wallet;
            _workerClient = new SubstrateClientExt(new Uri(workerUrl));
            _extrinsicStates = new Dictionary<string, string>();

            _shardHex = shardHex;
            _mrenclaveHex = mrenclaveHex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ConnectTeeAsync()
        {
            if (IsTeeConnected)
            {
                return false;
            }

            await _workerClient.ConnectAsync(false, false, false, CancellationToken.None);

            _shieldingKey = await _workerClient.ShieldingKeyAsync();
            if(_shieldingKey.Modulus == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DisconnectTeeAsync()
        {
            if (!IsTeeConnected)
            {
                return false;
            }
            
            await _workerClient.CloseAsync();

            return true;
        }

        private void ActionExtrinsicUpdate(string subscriptionId, ExtrinsicStatus extrinsicUpdate)
        {
            switch (extrinsicUpdate.ExtrinsicState)
            {
                case ExtrinsicState.None:
                    if (extrinsicUpdate.InBlock?.Value.Length > 0)
                    {
                        if (_extrinsicStates.ContainsKey(subscriptionId))
                        {
                            _extrinsicStates.Remove(subscriptionId);
                        }
                    }
                    else if (extrinsicUpdate.Finalized?.Value.Length > 0)
                    {
                        if (_extrinsicStates.ContainsKey(subscriptionId))
                        {
                            _extrinsicStates.Remove(subscriptionId);
                        }
                    }
                    break;
                case ExtrinsicState.Future:
                    break;
                case ExtrinsicState.Ready:
                    break;
                case ExtrinsicState.Dropped:
                    if (_extrinsicStates.ContainsKey(subscriptionId))
                    {
                        _extrinsicStates.Remove(subscriptionId);
                    }
                    break;
                case ExtrinsicState.Invalid:
                    if (_extrinsicStates.ContainsKey(subscriptionId))
                    {
                        _extrinsicStates.Remove(subscriptionId);
                    }
                    break;
                default:
                    break;
            }
        }

        public async Task<U32> GetRunnerIdAsync()
        {

            if (!_wallet.IsConnected || !_wallet.IsUnlocked)
            {
                return null;
            }

            if (_extrinsicStates.ContainsValue("Queue"))
            {
                return null;
            }

            var account = new AccountId32();
            account.Create(Utils.GetPublicKeyFrom(_wallet.Account.Value));

            var cts = new CancellationTokenSource();
            return await _wallet.Client.GameRegistryStorage.Players(account, cts.Token);
        }


        public async Task<EnumRunnerState> GetRunnerStateAsync(U32 registerId)
        {
            if (!_wallet.IsConnected || !_wallet.IsUnlocked)
            {
                return null;
            }

            var cts = new CancellationTokenSource();
            return await _wallet.Client.RunnerStorage.Runners(registerId, cts.Token);
        }

        public async Task<bool> QueueAsync()
        {
            if (!_wallet.IsConnected || !_wallet.IsUnlocked || _extrinsicStates.ContainsValue("Queue"))
            {
                return false;
            }

            var cts = new CancellationTokenSource();
            var extrinsicMethod = Ajuna.NetApi.Model.PalletGameRegistry.GameRegistryCalls.Queue();
            var subscription = await _wallet.Client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, _wallet.Account, 0, 64, cts.Token);
            if (subscription != null)
            {
                _extrinsicStates.Add(subscription, "Queue");
            }

            return true;
        }

        public async Task<U8> GetPlayerQueueAsync()
        {
            if (!_wallet.IsConnected || !_wallet.IsUnlocked)
            {
                return null;
            }

            var account = new AccountId32();
            account.Create(Utils.GetPublicKeyFrom(_wallet.Account.Value));

            var cts = new CancellationTokenSource();
            return await _wallet.Client.MatchmakerStorage.PlayerQueue(account, cts.Token);
        }

        public async Task<bool> FaucetAsync()
        {
            if (!_wallet.IsConnected || !_wallet.IsUnlocked || _extrinsicStates.ContainsValue("Faucet"))
            {
                return false;
            }

            var accountAlice = new AccountId32();
            accountAlice.Create(Utils.GetPublicKeyFrom(Alice.Value));

            var account = new AccountId32();
            account.Create(Utils.GetPublicKeyFrom(_wallet.Account.Value));

            var multiAddressBob = new EnumMultiAddress();
            multiAddressBob.Create(MultiAddress.Id, account);

            var amount = new BaseCom<U128>();
            amount.Create(1100000000000);

            var extrinsicMethod = Ajuna.NetApi.Model.PalletBalances.BalancesCalls.Transfer(multiAddressBob, amount);

            var cts = new CancellationTokenSource();
            var subscription = await _wallet.Client.Author.SubmitAndWatchExtrinsicAsync(ActionExtrinsicUpdate, extrinsicMethod, Alice, 0, 64, cts.Token);
            if (subscription != null)
            {
                _extrinsicStates.Add(subscription, "Faucet");
            }

            return true;
        }

        public async Task<bool> FaucetWorkerAsync()
        {
            if (!IsTeeConnected)
            {
                return false;
            }

            var hash = await _workerClient.BalanceTransferAsync(Alice, _wallet.Account, (uint)100000, _shieldingKey, _shardHex, _mrenclaveHex);
            if (hash == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> BombAsync(int posX, int posY)
        {
            if (!IsTeeConnected)
            {
                return false;
            }

            var hash = await _workerClient.PlayTurnAsync(
                _wallet.Account, 
                SgxGameTurn.DropBomb(new int[] { posX , posY}),          
                _shieldingKey, 
                _shardHex, 
                _mrenclaveHex);
            if (hash == null)
            {
                return false;
            }

            return true;
        }
        
        public async Task<bool> DropStoneAsync((Side, int) move )
        {
            if (!IsTeeConnected)
            {
                return false;
            }

            var hash = await _workerClient.PlayTurnAsync(
                _wallet.Account, 
                SgxGameTurn.DropStone(move.Item1, (byte)move.Item2),
                _shieldingKey, 
                _shardHex, 
                _mrenclaveHex);
            if (hash == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> StoneAsync(Side side, int column)
        {
            if (!IsTeeConnected)
            {
                return false;
            }

            var hash = await _workerClient.PlayTurnAsync(
                _wallet.Account,
                SgxGameTurn.DropStone(side, (byte)column),
                _shieldingKey,
                _shardHex,
                _mrenclaveHex);
            if (hash == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Dot4GObj> GameBoardAsync()
        {
            if (!IsTeeConnected)
            {
                return null;
            }

            var boardGame = await _workerClient.GetBoardGameAsync(_wallet.Account, _shieldingKey, _shardHex);
            if (boardGame == null)
            {
                return null;
            }

            return new Dot4GObj(boardGame);
        }

        public int GetPlayerId(int player)
        {
            return 0;
        }

        public int GetPlayer(int playerId)
        {
            return 0;
        }
    }
}

using Substrate.NetApi.Model.Extrinsics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.TestNode
{
    public abstract class NodeTest
    {
        //protected const string WebSocketUrl = "wss://rpc-paseo.bajun.network";
        //protected const string WebSocketUrl = "wss://rpc-parachain.bajun.network";
        protected const string WebSocketUrl = "wss://polkadot-rpc.dwellir.com";

        protected SubstrateClient _substrateClient;

        public string Url { get; }

        protected NodeTest(string url = null)
        {
            Url = url ?? WebSocketUrl;
        }

        [SetUp]
        public async Task ConnectAsync()
        {
            await _substrateClient.ConnectAsync();
        }

        [TearDown]
        public async Task CloseAsync()
        {
            await _substrateClient.CloseAsync();
        }

        [OneTimeSetUp]
        public void CreateClient()
        {
            _substrateClient = new SubstrateClient(new Uri(Url), ChargeTransactionPayment.Default());
        }

        [OneTimeTearDown]
        public void DisposeClient()
        {
            _substrateClient.Dispose();
        }

        /// <summary>
        /// Return the 20th hash block from now (totally arbitrary)
        /// </summary>
        /// <returns></returns>
        protected async Task<Hash> GivenBlockAsync()
        {   
            var lastBlockData = await _substrateClient.Chain.GetBlockAsync();
            var lastBlockNumber = lastBlockData.Block.Header.Number.Value;

            var blockNumber = new BlockNumber((uint)(lastBlockNumber - 20));
            return await _substrateClient.Chain.GetBlockHashAsync(blockNumber);
        }
    }
}

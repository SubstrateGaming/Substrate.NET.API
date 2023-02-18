﻿using Ajuna.NetApi.Model.Extrinsics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajuna.NetApi.TestNode
{
    public abstract class NodeTest
    {
        protected const string WebSocketUrl = "ws://rpc-parachain.bajun.network";

        protected SubstrateClient _substrateClient;


        //[SetUp]
        //public void Setup()
        //{
        //    _substrateClient = new SubstrateClient(new Uri(WebSocketUrl), ChargeTransactionPayment.Default());
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    _substrateClient.Dispose();
        //}

        [OneTimeSetUp]
        public async Task ConnectAsync()
        {
            _substrateClient = new SubstrateClient(new Uri(WebSocketUrl), ChargeTransactionPayment.Default());
            await _substrateClient.ConnectAsync();
        }

        [OneTimeTearDown]
        public async Task DisconnectAsync()
        {
            await _substrateClient.CloseAsync();
            _substrateClient.Dispose();
        }

        /// <summary>
        /// Return the 20th hash block from now (totally arbitrary)
        /// </summary>
        /// <returns></returns>
        protected async Task<byte[]> givenBlockAsync()
        {   
            var lastBlockData = await _substrateClient.Chain.GetBlockAsync();
            var lastBlockNumber = lastBlockData.Block.Header.Number.Value;

            var blockNumber = new Model.Types.Base.BlockNumber();
            blockNumber.Create((uint)(lastBlockNumber - 20));
            return (await _substrateClient.Chain.GetBlockHashAsync(blockNumber)).Bytes;
        }
    }
}

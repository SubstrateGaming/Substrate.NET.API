using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using StreamJsonRpc;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.TestNode
{
    public class ModuleChainTest : NodeTest
    {
        [Test]
        public async Task GetBlockAsyncTestAsync()
        {
            var result = await _substrateClient.InvokeAsync<BlockData>("chain_getBlock", new object[] { "0xc3bc40a6dea74478ecfdd99761b53e60e04945a05e7eec125a80a6cf04e81281" }, CancellationToken.None);

            Assert.IsNotNull(result);
        }


    }
}
using NUnit.Framework;
using Substrate.NetApi.Model.Types.Metadata;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.TestNode
{
    public class ModuleRuntimeCallTest : NodeTest
    {
        [Test]
        public async Task GetMetadataAtVersionTestAsync()
        {
            var result14 = await _substrateClient.RuntimeCall.MetadataAtVersionAsync(14, CancellationToken.None);
            var mdv14 = new RuntimeMetadata<RuntimeMetadataV14>();
            mdv14.Create(result14.Value.Value.Select(p => p.Value).ToArray());
            Assert.IsNotNull(mdv14);

            var result15 = await _substrateClient.RuntimeCall.MetadataAtVersionAsync(15, CancellationToken.None);
            var mdv15 = new RuntimeMetadata<RuntimeMetadataV15>();
            mdv15.Create(result15.Value.Value.Select(p => p.Value).ToArray());
            Assert.IsNotNull(mdv15);
        }

        [Test]
        public async Task GetMetadataVersionsTestAsync()
        {
            var result = await _substrateClient.RuntimeCall.MetadataVersionsAsync(CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual(14, result.Value[0].Value);
            Assert.AreEqual(15, result.Value[1].Value);
        }
    }
}
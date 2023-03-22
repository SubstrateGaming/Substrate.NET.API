using Substrate.NetApi.Model.Extrinsics;

namespace Substrate.NetApi.Model.Rpc
{
    public class Block
    {
        public Extrinsic[] Extrinsics { get; set; }
        public Header Header { get; set; }
    }
}
using Ajuna.NetApi.Model.Extrinsics;

namespace Ajuna.NetApi.Model.Rpc
{
    public class Block
    {
        public Extrinsic[] Extrinsics { get; set; }
        public Header Header { get; set; }

    }
}
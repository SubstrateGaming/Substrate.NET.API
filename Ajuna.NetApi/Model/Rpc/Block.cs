using AjunaNetApi.Model.Extrinsics;

namespace AjunaNetApi.Model.Rpc
{
    public class Block
    {
        public Extrinsic[] Extrinsics { get; set; }
        public Header Header { get; set; }

    }
}
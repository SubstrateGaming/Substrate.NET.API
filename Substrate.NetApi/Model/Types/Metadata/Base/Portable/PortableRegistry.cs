using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NetApi.Model.Types.Metadata.Base.Portable
{
    /// <summary>
    /// Portable Registry
    /// </summary>
    public class PortableRegistry : BaseVec<PortableType>
    {
        /// <inheritdoc/>
        public override string TypeName() => "PortableRegistry";
    }
}
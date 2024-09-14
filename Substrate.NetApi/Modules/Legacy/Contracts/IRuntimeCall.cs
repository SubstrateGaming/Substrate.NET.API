using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Threading;
using System.Threading.Tasks;

namespace Substrate.NetApi.Modules.Contracts
{
    /// <summary>
    /// Runtime Call Module Interface
    /// </summary>
    public interface IRuntimeCall
    {
        /// <summary>
        /// Returns the metadata of a runtime.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<BaseVec<U8>> MetadataAsync(CancellationToken token);

        /// <summary>
        /// Returns the metadata at a given version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<BaseOpt<BaseVec<U8>>> MetadataAtVersionAsync(uint version, CancellationToken token);

        /// <summary>
        /// Returns the supported metadata versions.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<BaseVec<U32>> MetadataVersionsAsync(CancellationToken token);
    }
}
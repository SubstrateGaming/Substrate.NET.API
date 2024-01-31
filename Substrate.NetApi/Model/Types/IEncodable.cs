namespace Substrate.NetApi.Model.Types
{
    /// <summary>
    /// Encodable Interface
    /// </summary>
    public interface IEncodable
    {
        /// <summary>
        /// Encode
        /// </summary>
        /// <returns></returns>
        byte[] Encode();
    }
}
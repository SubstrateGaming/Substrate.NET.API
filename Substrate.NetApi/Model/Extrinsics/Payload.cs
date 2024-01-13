using System.Linq;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Payload
    /// </summary>
    public class Payload
    {
        private readonly Method _call;
        
        private readonly SignedExtensions _signedExtension;

        /// <summary>
        /// Initializes a new instance of the <see cref="Payload"/> class.
        /// </summary>
        /// <param name="call">The call.</param>
        /// <param name="signedExtensions">The signed extensions.</param>
        public Payload(Method call, SignedExtensions signedExtensions)
        {
            _call = call;
            _signedExtension = signedExtensions;
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            byte[] bytes = _call.Encode().Concat(_signedExtension.Encode()).ToArray();
            return bytes;
        }
    }
}
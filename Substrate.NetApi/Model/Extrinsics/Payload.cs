using Substrate.NetApi.Model.Types;
using System.Linq;

namespace Substrate.NetApi.Model.Extrinsics
{
    /// <summary>
    /// Payload
    /// </summary>
    public class Payload : IEncodable
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
        /// Encodes this instance, returns the encoded bytes. Additionally, if
        /// the encoded bytes are longer than 256 bytes, they are hashed using `blake2_256`.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            byte[] bytes = _call.Encode().Concat(_signedExtension.Encode()).ToArray();

            // Payloads longer than 256 bytes are going to be `blake2_256`-hashed.
            if (bytes.Length > 256)
            {
                bytes = HashExtension.Blake2(bytes, 256);
            }

            return bytes;
        }
    }
}
using System;
using System.Linq;

namespace Ajuna.NetApi.Model.Extrinsics
{
    public class Payload
    {
        private byte[] _call;

        private byte[] _extra;

        private byte[] _additionalSigned;

        /// <summary>
        /// Initializes a new instance of the <see cref="Payload"/> class.
        /// </summary>
        /// <param name="call">The call.</param>
        /// <param name="signedExtensions">The signed extensions.</param>
        public Payload(byte[] call, byte[] extra, byte[] additionalSigned)
        {
            _call = call;
            _extra = extra;
            _additionalSigned = additionalSigned;
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            return _call.Concat(_extra.Concat(_additionalSigned)).ToArray();
        }
    }
}

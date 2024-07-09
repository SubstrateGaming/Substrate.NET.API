using System.Collections.Generic;
using System.Linq;
using Substrate.NetApi.Model.Types.Base;
using System;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types;



namespace Substrate.NetApi.Model.Extrinsics
{

    /// <summary>
    ///  If the runtime should expect a metadata hash that has been signed in the additional signed.
    /// </summary>  
    public enum Mode
    {
        /// <summary>
        ///  `None` has been signed in the CheckMetadataHash additional signed.
        /// </summary>  
        Disabled,
        /// <summary>
        ///  `Some(MetadataHash)` has been signed in the CheckMetadataHash additional signed.
        /// </summary>  
        Enabled
    }
    /// <summary>
    /// CheckMetadataHash signed extension.
    /// </summary>
    public class CheckMetadataHash: BaseType
    {
        private Mode _mode;

        /// <summary>
        /// Initialize with `Mode.Disabled`.
        /// </summary>
        public CheckMetadataHash() { 
            // Don't allow enabling the mode, as we don't support it.
            _mode = Mode.Disabled;
        }

        /// <summary>
        /// Corresponds to the `Extra` that is sent with the extrinsic.
        /// </summary>
        /// <returns></returns>
        public override byte[] Encode()
        {
            return EncodeExtra();
        }

        /// <summary>
        /// Simplifies the calling code a bit, as we only need this in static contexts for now `Encode`.
        /// </summary>
        /// <returns></returns>
        public byte[] EncodeExtra()
        {
            // // We provide no metadata hash in the signer payload to align with the above.
            return new byte[1];
        }

        /// <summary>
        /// Corresponds to the `Additional` that is signed, but _not_ sent with the extrinsic.
        /// </summary>
        /// <returns></returns>
        public byte[] EncodeAdditional()
        {
            // // We provide no metadata hash in the signer payload to align with the above.
            return new byte[1];
        }

        /// <inheritdoc />
        public override void Decode(byte[] byteArray, ref int p)
        {
            uint modeByte = byteArray[p++];

            if (modeByte > 1) {
                throw new ArgumentException($"{modeByte} is not a valid representation of CheckMetadata Mode.");
            }

            if (modeByte == 0) {
                _mode = Mode.Disabled;
            } else {
                _mode = Mode.Enabled;
            }
        }
    }
}
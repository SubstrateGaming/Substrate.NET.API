using System;
using System.Linq;
using System.Text;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// String Primitive Type
    /// </summary>
    public class Str : BasePrim<string>
    {
        /// <summary>
        /// Explicitly cast a string to a Str
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator Str(string p) => new Str(p);

        /// <summary>
        /// Implicitly cast a Str to a string
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator string(Str p) => p.Value;

        /// <summary>
        /// Str Constructor
        /// </summary>
        public Str()
        { }

        /// <summary>
        /// Str Constructor
        /// </summary>
        /// <param name="value"></param>
        public Str(string value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "str";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Utils.SizePrefixedByteArray(Encoding.UTF8.GetBytes(Value).ToList());
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            var value = String.Empty;

            var length = CompactInteger.Decode(byteArray, ref p);
            for (var i = 0; i < length; i++)
            {
                var t = new PrimChar();
                t.Decode(byteArray, ref p);
                value += t.Value;
            }

            TypeSize = p - start;

            var bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, bytes, 0, TypeSize);

            Bytes = bytes;
            Value = value;
        }

        /// <inheritdoc/>
        public override void Create(string value)
        {
            Value = value;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }
    }
}
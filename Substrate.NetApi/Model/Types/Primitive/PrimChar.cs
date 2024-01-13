using System;
using System.Text;

namespace Substrate.NetApi.Model.Types.Primitive
{
    /// <summary>
    /// Char Primitive Type
    /// </summary>
    public class PrimChar : BasePrim<char>
    {
        /// <summary>
        /// Explicitly cast a char to a PrimChar
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator PrimChar(char p) => new PrimChar(p);

        /// <summary>
        /// Implicitly cast a PrimChar to a char
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator char(PrimChar p) => p.Value;

        /// <summary>
        /// Prim Char Constructor
        /// </summary>
        public PrimChar()
        { }

        /// <summary>
        /// Prim Char Constructor
        /// </summary>
        /// <param name="value"></param>
        public PrimChar(char value)
        {
            Create(value);
        }

        /// <inheritdoc/>
        public override string TypeName() => "char";

        /// <inheritdoc/>
        public override int TypeSize => 1;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Create(byte[] byteArray)
        {
            Bytes = byteArray;
            Value = Encoding.UTF8.GetString(byteArray)[0];
        }

        /// <inheritdoc/>
        public override void Create(char value)
        {
            Bytes = Encoding.UTF8.GetBytes(value.ToString());
            Value = value;
        }
    }
}
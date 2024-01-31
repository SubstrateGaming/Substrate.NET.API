using System;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Compact Integer Type
    /// </summary>
    public class CompactIntegerType : IType
    {
        /// <summary>
        /// Type Name
        /// </summary>
        /// <returns></returns>
        public virtual string TypeName() => "CompactInteger";

        /// <summary>
        /// Type Size
        /// </summary>
        public int TypeSize { get; set; } = 0;

        /// <summary>
        /// Create from string
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Create(string str)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create from byte array
        /// </summary>
        /// <param name="byteArray"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Create(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create from Json
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateFromJson(string str)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode from byte array
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public void Decode(byte[] byteArray, ref int p)
        {
            Value = CompactInteger.Decode(byteArray, ref p);
        }

        /// <summary>
        /// Encode to byte array
        /// </summary>
        /// <returns></returns>
        public byte[] Encode()
        {
            return Value.Encode();
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// New
        /// </summary>
        /// <returns></returns>
        public IType New() => this;

        /// <summary>
        /// Value
        /// </summary>
        public CompactInteger Value { get; set; }
    }

    /// <summary>
    /// T Type Definition
    /// </summary>
    public class TType : CompactIntegerType
    {
        /// <summary>
        /// Type Name
        /// </summary>
        /// <returns></returns>
        public override string TypeName() => "T::Type";
    }

    /// <summary>
    /// Type Definition Enum
    /// </summary>
    public enum TypeDefEnum
    {
        /// A composite type (e.g. a struct or a tuple)
        Composite = 0,

        /// A variant type (e.g. an enum)
        Variant = 1,

        /// A sequence type with runtime known length.
        Sequence = 2,

        /// An array type with compile-time known length.
        Array = 3,

        /// A tuple type.
        Tuple = 4,

        /// A Rust primitive type.
        Primitive = 5,

        /// A type using the [`Compact`] encoding
        Compact = 6,

        /// A type representing a sequence of bits.
        BitSequence = 7
    }

    /// <summary>
    /// Type Definition Composite Type
    /// </summary>
    public class TypeDefComposite : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefComposite<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Fields = new BaseVec<Field>();
            Fields.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Fields
        /// </summary>
        public BaseVec<Field> Fields { get; private set; }
    }

    /// <summary>
    /// Type Definition Variant Type
    /// </summary>
    public class TypeDefVariant : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefVariant<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParam = new BaseVec<Variant>();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Type Param
        /// </summary>
        public BaseVec<Variant> TypeParam { get; private set; }
    }

    /// <summary>
    /// Type Definition Sequence Type
    /// </summary>
    public class TypeDefSequence : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefSequence<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParam = new TType();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Type Param
        /// </summary>
        public TType TypeParam { get; private set; }
    }

    /// <summary>
    /// Type Definition Array Type
    /// </summary>
    public class TypeDefArray : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefArray<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Len = new U32();
            Len.Decode(byteArray, ref p);

            TypeParam = new TType();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Len
        /// </summary>
        public U32 Len { get; private set; }
        
        /// <summary>
        /// Type Param
        /// </summary>
        public TType TypeParam { get; private set; }
    }

    /// <summary>
    /// Type Definition Tuple Type
    /// </summary>
    public class TypeDefTuple : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefTuple<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Fields = new BaseVec<TType>();
            Fields.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Fields
        /// </summary>
        public BaseVec<TType> Fields { get; private set; }
    }

    /// <summary>
    /// Type Definition Primitive Type
    /// </summary>
    public enum TypeDefPrimitive
    {
        /// `bool` type
        Bool,

        /// `char` type
        Char,

        /// `str` type
        Str,

        /// `u8`
        U8,

        /// `u16`
        U16,

        /// `u32`
        U32,

        /// `u64`
        U64,

        /// `u128`
        U128,

        /// 256 bits unsigned int (no rust equivalent)
        U256,

        /// `i8`
        I8,

        /// `i16`
        I16,

        /// `i32`
        I32,

        /// `i64`
        I64,

        /// `i128`
        I128,

        /// 256 bits signed int (no rust equivalent)
        I256,
    }

    /// <summary>
    /// Type Definition Compact Type
    /// </summary>
    public class TypeDefCompact : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefCompact<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParam = new TType();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Type Param
        /// </summary>
        public TType TypeParam { get; private set; }
    }

    /// <summary>
    /// Type Definition Bit Sequence Type
    /// </summary>
    public class TypeDefBitSequence : BaseType
    {
        /// <inheritdoc/>
        public override string TypeName() => "TypeDefBitSequence<T: Form = MetaForm>";

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            BitStoreType = new TType();
            BitStoreType.Decode(byteArray, ref p);

            BitOrderType = new TType();
            BitOrderType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Bit Store Type
        /// </summary>
        public TType BitStoreType { get; private set; }
        
        /// <summary>
        /// Bit Order Type
        /// </summary>
        public TType BitOrderType { get; private set; }
    }
}
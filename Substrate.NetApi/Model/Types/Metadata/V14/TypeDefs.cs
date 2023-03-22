﻿using System;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    public class CompactIntegerType : IType
    {
        public virtual string TypeName() => "CompactInteger";

        public int TypeSize { get; set; } = 0;

        public void Create(string str)
        {
            throw new NotImplementedException();
        }

        public void Create(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public void CreateFromJson(string str)
        {
            throw new NotImplementedException();
        }

        public void Decode(byte[] byteArray, ref int p)
        {
            Value = CompactInteger.Decode(byteArray, ref p);
        }

        public byte[] Encode()
        {
            return Value.Encode();
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        public IType New() => this;

        public CompactInteger Value { get; set; }
    }

    public class TType : CompactIntegerType
    {
        public override string TypeName() => "T::Type";
    }

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

    public class TypeDefComposite : BaseType
    {
        public override string TypeName() => "TypeDefComposite<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Fields = new BaseVec<Field>();
            Fields.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public BaseVec<Field> Fields { get; private set; }
    }

    public class TypeDefVariant : BaseType
    {
        public override string TypeName() => "TypeDefVariant<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParam = new BaseVec<Variant>();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public BaseVec<Variant> TypeParam { get; private set; }
    }

    public class TypeDefSequence : BaseType
    {
        public override string TypeName() => "TypeDefSequence<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParam = new TType();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType TypeParam { get; private set; }
    }

    public class TypeDefArray : BaseType
    {
        public override string TypeName() => "TypeDefArray<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Len = new U32();
            Len.Decode(byteArray, ref p);

            TypeParam = new TType();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public U32 Len { get; private set; }
        public TType TypeParam { get; private set; }
    }

    public class TypeDefTuple : BaseType
    {
        public override string TypeName() => "TypeDefTuple<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Fields = new BaseVec<TType>();
            Fields.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public BaseVec<TType> Fields { get; private set; }
    }

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

    public class TypeDefCompact : BaseType
    {
        public override string TypeName() => "TypeDefCompact<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TypeParam = new TType();
            TypeParam.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType TypeParam { get; private set; }
    }

    public class TypeDefBitSequence : BaseType
    {
        public override string TypeName() => "TypeDefBitSequence<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            BitStoreType = new TType();
            BitStoreType.Decode(byteArray, ref p);

            BitOrderType = new TType();
            BitOrderType.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public TType BitStoreType { get; private set; }
        public TType BitOrderType { get; private set; }
    }
}
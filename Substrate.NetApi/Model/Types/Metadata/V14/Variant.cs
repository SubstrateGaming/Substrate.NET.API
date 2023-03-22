﻿using System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    public class Variant : BaseType
    {
        public override string TypeName() => "Variant<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            VariantName = new Str();
            VariantName.Decode(byteArray, ref p);

            VariantFields = new BaseVec<Field>();
            VariantFields.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Str VariantName { get; private set; }
        public BaseVec<Field> VariantFields { get; private set; }
        public U8 Index { get; private set; }
        public BaseVec<Str> Docs { get; private set; }
    }
}
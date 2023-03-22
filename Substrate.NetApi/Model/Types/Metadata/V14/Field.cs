﻿using System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    public class Field : BaseType
    {
        public override string TypeName() => "Field<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            FieldName = new BaseOpt<Str>();
            FieldName.Decode(byteArray, ref p);

            FieldTy = new TType();
            FieldTy.Decode(byteArray, ref p);

            FieldTypeName = new BaseOpt<Str>();
            FieldTypeName.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public BaseOpt<Str> FieldName { get; private set; }
        public TType FieldTy { get; private set; }
        public BaseOpt<Str> FieldTypeName { get; private set; }
        public BaseVec<Str> Docs { get; private set; }
    }
}
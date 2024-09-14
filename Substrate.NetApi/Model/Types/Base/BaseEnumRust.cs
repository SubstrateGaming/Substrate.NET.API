using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Next version of BaseEnumExt to support Rust enums
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public class BaseEnumRust<TEnum> : BaseType where TEnum : Enum
    {
        private readonly Dictionary<TEnum, Func<byte[], int, Tuple<IType, int>>> _typeDecoders;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseEnumRust()
        {
            _typeDecoders = new Dictionary<TEnum, Func<byte[], int, Tuple<IType, int>>>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseEnumRust(Dictionary<TEnum, Type> typeDecoderMap)
        {
            _typeDecoders = new Dictionary<TEnum, Func<byte[], int, Tuple<IType, int>>>();
            foreach (var decoder in typeDecoderMap)
            {
                var enumValue = decoder.Key;
                var type = decoder.Value;

                _typeDecoders.Add(enumValue, (byteArray, p) =>
                {
                    var typeInstance = (IType)Activator.CreateInstance(type);
                    typeInstance.Decode(byteArray, ref p);
                    return new Tuple<IType, int>(typeInstance, p);
                });
            }
        }

        /// <summary>
        /// Add a type decoder
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="enumValue"></param>
        public void AddTypeDecoder<TType>(TEnum enumValue) where TType : IType, new()
        {
            _typeDecoders.Add(enumValue, (byteArray, p) =>
            {
                var typeInstance = new TType();
                typeInstance.Decode(byteArray, ref p);
                return new Tuple<IType, int>(typeInstance, p);
            });
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];
            p += 1;

            try
            {
                Value = (TEnum)Enum.Parse(typeof(TEnum), enumByte.ToString(), true);
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Invalid enum value: {enumByte}", ex);
            }

            if (_typeDecoders.TryGetValue(Value, out var decoder))
            {
                var result = decoder(byteArray, p);
                Value2 = result.Item1;
                p = result.Item2;
            } 
            else
            {
               throw new Exception($"No decoder found for enum byte {enumByte}");
            }

            TypeSize = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <summary>
        /// Create from enum and it's value
        /// </summary>
        /// <param name="t"></param>
        /// <param name="iType"></param>
        public void Create(TEnum t, IType iType)
        {
            var enumByte = Convert.ToByte(t);

            if (!_typeDecoders.ContainsKey(t))
            {
                throw new Exception($"No decoder found for enum byte {enumByte}, make sure to use BaseVoid, if there is no value.");
            }

            Value = t;
            Value2 = iType;

            // Encode the enum byte and IType
            var bytes = new List<byte> { enumByte };
            bytes.AddRange(iType.Encode());
            Bytes = bytes.ToArray();
        }

        /// <summary>
        /// Create from enum only with BaseVoid
        /// </summary>
        /// <param name="t"></param>
        public void Create(TEnum t)
        {
            Create(t, new BaseVoid());
        }

        /// <inheritdoc/>
        public TEnum Value { get; set; }
        /// <inheritdoc/>
        public IType Value2 { get; set; }
    }
}

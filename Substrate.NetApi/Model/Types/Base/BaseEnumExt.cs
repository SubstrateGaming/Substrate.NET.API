using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    public abstract class BaseEnumType : BaseType
    {
        public static IType DecodeType<T>(byte[] byteArray, ref int p) where T : IType, new()
        {
            if (typeof(T) == typeof(BaseVoid))
                return null;
            var result = new T();
            result.Decode(byteArray, ref p);
            return result;
        }
    }

    public class BaseEnumExt<T0, T1> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
    {
        public override string TypeName() => typeof(T0).Name;

        public override byte[] Encode()
        {
            return Bytes;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                default:
                    return null;
            }
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        public override string ToString() => JsonConvert.SerializeObject(Value);

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }
    }
}
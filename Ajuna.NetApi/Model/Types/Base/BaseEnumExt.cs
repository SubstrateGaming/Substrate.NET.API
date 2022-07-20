using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ajuna.NetApi.Model.Types.Base
{
    public abstract class BaseEnumType : BaseType
    {

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                case 0x16: result = new T23(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                case 0x16: result = new T23(); break;
                case 0x17: result = new T24(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                case 0x16: result = new T23(); break;
                case 0x17: result = new T24(); break;
                case 0x18: result = new T25(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                case 0x16: result = new T23(); break;
                case 0x17: result = new T24(); break;
                case 0x18: result = new T25(); break;
                case 0x19: result = new T26(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                case 0x16: result = new T23(); break;
                case 0x17: result = new T24(); break;
                case 0x18: result = new T25(); break;
                case 0x19: result = new T26(); break;
                case 0x1A: result = new T27(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

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

            Value = (T0)System.Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            IType result;
            switch (value)
            {
                case 0x00: result = new T1(); break;
                case 0x01: result = new T2(); break;
                case 0x02: result = new T3(); break;
                case 0x03: result = new T4(); break;
                case 0x04: result = new T5(); break;
                case 0x05: result = new T6(); break;
                case 0x06: result = new T7(); break;
                case 0x07: result = new T8(); break;
                case 0x08: result = new T9(); break;
                case 0x09: result = new T10(); break;
                case 0x0A: result = new T11(); break;
                case 0x0B: result = new T12(); break;
                case 0x0C: result = new T13(); break;
                case 0x0D: result = new T14(); break;
                case 0x0E: result = new T15(); break;
                case 0x0F: result = new T16(); break;
                case 0x10: result = new T17(); break;
                case 0x11: result = new T18(); break;
                case 0x12: result = new T19(); break;
                case 0x13: result = new T20(); break;
                case 0x14: result = new T21(); break;
                case 0x15: result = new T22(); break;
                case 0x16: result = new T23(); break;
                case 0x17: result = new T24(); break;
                case 0x18: result = new T25(); break;
                case 0x19: result = new T26(); break;
                case 0x1A: result = new T27(); break;
                case 0x1B: result = new T28(); break;
                default:
                    return null;
            }

            if (result.GetType().Name == "Void")
                return null;
            result.Decode(byteArray, ref p);
            return result;
        }

        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        public IType Value2 { get; set; }

    }
}
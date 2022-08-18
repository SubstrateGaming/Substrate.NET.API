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
                case 0x1C: result = new T29(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
                case 0x31: result = new T50(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
                case 0x31: result = new T50(); break;
                case 0x32: result = new T51(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
                case 0x31: result = new T50(); break;
                case 0x32: result = new T51(); break;
                case 0x33: result = new T52(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
                case 0x31: result = new T50(); break;
                case 0x32: result = new T51(); break;
                case 0x33: result = new T52(); break;
                case 0x34: result = new T53(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
                case 0x31: result = new T50(); break;
                case 0x32: result = new T51(); break;
                case 0x33: result = new T52(); break;
                case 0x34: result = new T53(); break;
                case 0x35: result = new T54(); break;
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
                case 0x1C: result = new T29(); break;
                case 0x1D: result = new T30(); break;
                case 0x1E: result = new T31(); break;
                case 0x1F: result = new T32(); break;
                case 0x20: result = new T33(); break;
                case 0x21: result = new T34(); break;
                case 0x22: result = new T35(); break;
                case 0x23: result = new T36(); break;
                case 0x24: result = new T37(); break;
                case 0x25: result = new T38(); break;
                case 0x26: result = new T39(); break;
                case 0x27: result = new T40(); break;
                case 0x28: result = new T41(); break;
                case 0x29: result = new T42(); break;
                case 0x2A: result = new T43(); break;
                case 0x2B: result = new T44(); break;
                case 0x2C: result = new T45(); break;
                case 0x2D: result = new T46(); break;
                case 0x2E: result = new T47(); break;
                case 0x2F: result = new T48(); break;
                case 0x30: result = new T49(); break;
                case 0x31: result = new T50(); break;
                case 0x32: result = new T51(); break;
                case 0x33: result = new T52(); break;
                case 0x34: result = new T53(); break;
                case 0x35: result = new T54(); break;
                case 0x36: result = new T55(); break;
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
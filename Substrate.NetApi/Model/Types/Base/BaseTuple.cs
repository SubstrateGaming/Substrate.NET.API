using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{
    public class BaseTuple : BaseType
    {
        public override string TypeName()
        {
            return "(" + ")";
        }

        public override byte[] Encode()
        {
            return new byte[0];
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            TypeSize = 0;
            Bytes = new byte[0];
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1> : BaseType
                            where T1 : IType, new()
    {
        public BaseTuple()
        { }

        public BaseTuple(T1 t1)
        {
            Create(t1);
        }

        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[1];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode()); byteList.ToArray();

            Value = new IType[1];
            Value[0] = t1;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
    {
        public BaseTuple()
        { }

        public BaseTuple(T1 t1, T2 t2)
        {
            Create(t1, t2);
        }

        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[2];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode()); byteList.ToArray();

            Value = new IType[2];
            Value[0] = t1;
            Value[1] = t2;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
                            where T3 : IType, new()
    {
        public BaseTuple()
        { }

        public BaseTuple(T1 t1, T2 t2, T3 t3)
        {
            Create(t1, t2, t3);
        }

        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[3];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode()); byteList.ToArray();

            Value = new IType[3];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
                            where T3 : IType, new()
                            where T4 : IType, new()
    {
        public BaseTuple()
        { }

        public BaseTuple(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            Create(t1, t2, t3, t4);
        }

        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[4];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode()); byteList.ToArray();

            Value = new IType[4];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
                            where T3 : IType, new()
                            where T4 : IType, new()
                            where T5 : IType, new()
    {
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[5];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode()); byteList.ToArray();

            Value = new IType[5];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
                            where T3 : IType, new()
                            where T4 : IType, new()
                            where T5 : IType, new()
                            where T6 : IType, new()
    {
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[6];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode()); byteList.ToArray();

            Value = new IType[6];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
                            where T3 : IType, new()
                            where T4 : IType, new()
                            where T5 : IType, new()
                            where T6 : IType, new()
                            where T7 : IType, new()
    {
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[7];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode()); byteList.ToArray();

            Value = new IType[7];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8> : BaseType
                            where T1 : IType, new()
                            where T2 : IType, new()
                            where T3 : IType, new()
                            where T4 : IType, new()
                            where T5 : IType, new()
                            where T6 : IType, new()
                            where T7 : IType, new()
                            where T8 : IType, new()
    {
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[8];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode()); byteList.ToArray();

            Value = new IType[8];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[9];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode()); byteList.ToArray();

            Value = new IType[9];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[10];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode()); byteList.ToArray();

            Value = new IType[10];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[11];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode()); byteList.ToArray();

            Value = new IType[11];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[12];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode()); byteList.ToArray();

            Value = new IType[12];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[13];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode()); byteList.ToArray();

            Value = new IType[13];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[14];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode()); byteList.ToArray();

            Value = new IType[14];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[15];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode()); byteList.ToArray();

            Value = new IType[15];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[16];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode()); byteList.ToArray();

            Value = new IType[16];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[17];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode()); byteList.ToArray();

            Value = new IType[17];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[18];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode()); byteList.ToArray();

            Value = new IType[18];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[19];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode()); byteList.ToArray();

            Value = new IType[19];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[20];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode()); byteList.ToArray();

            Value = new IType[20];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[21];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode()); byteList.ToArray();

            Value = new IType[21];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[22];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode()); byteList.ToArray();

            Value = new IType[22];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[23];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode()); byteList.ToArray();

            Value = new IType[23];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[24];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode()); byteList.ToArray();

            Value = new IType[24];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[25];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode()); byteList.ToArray();

            Value = new IType[25];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[26];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode()); byteList.ToArray();

            Value = new IType[26];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[27];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode()); byteList.ToArray();

            Value = new IType[27];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[28];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode()); byteList.ToArray();

            Value = new IType[28];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[29];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode()); byteList.ToArray();

            Value = new IType[29];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[30];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode()); byteList.ToArray();

            Value = new IType[30];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[31];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode()); byteList.ToArray();

            Value = new IType[31];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[32];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode()); byteList.ToArray();

            Value = new IType[32];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[33];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode()); byteList.ToArray();

            Value = new IType[33];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + "," +
                new T34().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[34];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33;
            var t34 = new T34();
            t34.Decode(byteArray, ref p);
            Value[33] = t34; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33, T34 t34)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode());
            byteList.AddRange(t34.Encode()); byteList.ToArray();

            Value = new IType[34];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;
            Value[33] = t34;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + "," +
                new T34().TypeName() + "," +
                new T35().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[35];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33;
            var t34 = new T34();
            t34.Decode(byteArray, ref p);
            Value[33] = t34;
            var t35 = new T35();
            t35.Decode(byteArray, ref p);
            Value[34] = t35; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33, T34 t34, T35 t35)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode());
            byteList.AddRange(t34.Encode());
            byteList.AddRange(t35.Encode()); byteList.ToArray();

            Value = new IType[35];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;
            Value[33] = t34;
            Value[34] = t35;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + "," +
                new T34().TypeName() + "," +
                new T35().TypeName() + "," +
                new T36().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[36];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33;
            var t34 = new T34();
            t34.Decode(byteArray, ref p);
            Value[33] = t34;
            var t35 = new T35();
            t35.Decode(byteArray, ref p);
            Value[34] = t35;
            var t36 = new T36();
            t36.Decode(byteArray, ref p);
            Value[35] = t36; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33, T34 t34, T35 t35, T36 t36)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode());
            byteList.AddRange(t34.Encode());
            byteList.AddRange(t35.Encode());
            byteList.AddRange(t36.Encode()); byteList.ToArray();

            Value = new IType[36];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;
            Value[33] = t34;
            Value[34] = t35;
            Value[35] = t36;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + "," +
                new T34().TypeName() + "," +
                new T35().TypeName() + "," +
                new T36().TypeName() + "," +
                new T37().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[37];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33;
            var t34 = new T34();
            t34.Decode(byteArray, ref p);
            Value[33] = t34;
            var t35 = new T35();
            t35.Decode(byteArray, ref p);
            Value[34] = t35;
            var t36 = new T36();
            t36.Decode(byteArray, ref p);
            Value[35] = t36;
            var t37 = new T37();
            t37.Decode(byteArray, ref p);
            Value[36] = t37; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33, T34 t34, T35 t35, T36 t36, T37 t37)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode());
            byteList.AddRange(t34.Encode());
            byteList.AddRange(t35.Encode());
            byteList.AddRange(t36.Encode());
            byteList.AddRange(t37.Encode()); byteList.ToArray();

            Value = new IType[37];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;
            Value[33] = t34;
            Value[34] = t35;
            Value[35] = t36;
            Value[36] = t37;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + "," +
                new T34().TypeName() + "," +
                new T35().TypeName() + "," +
                new T36().TypeName() + "," +
                new T37().TypeName() + "," +
                new T38().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[38];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33;
            var t34 = new T34();
            t34.Decode(byteArray, ref p);
            Value[33] = t34;
            var t35 = new T35();
            t35.Decode(byteArray, ref p);
            Value[34] = t35;
            var t36 = new T36();
            t36.Decode(byteArray, ref p);
            Value[35] = t36;
            var t37 = new T37();
            t37.Decode(byteArray, ref p);
            Value[36] = t37;
            var t38 = new T38();
            t38.Decode(byteArray, ref p);
            Value[37] = t38; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33, T34 t34, T35 t35, T36 t36, T37 t37, T38 t38)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode());
            byteList.AddRange(t34.Encode());
            byteList.AddRange(t35.Encode());
            byteList.AddRange(t36.Encode());
            byteList.AddRange(t37.Encode());
            byteList.AddRange(t38.Encode()); byteList.ToArray();

            Value = new IType[38];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;
            Value[33] = t34;
            Value[34] = t35;
            Value[35] = t36;
            Value[36] = t37;
            Value[37] = t38;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39> : BaseType
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
        public override string TypeName()
        {
            return "(" +
                new T1().TypeName() + "," +
                new T2().TypeName() + "," +
                new T3().TypeName() + "," +
                new T4().TypeName() + "," +
                new T5().TypeName() + "," +
                new T6().TypeName() + "," +
                new T7().TypeName() + "," +
                new T8().TypeName() + "," +
                new T9().TypeName() + "," +
                new T10().TypeName() + "," +
                new T11().TypeName() + "," +
                new T12().TypeName() + "," +
                new T13().TypeName() + "," +
                new T14().TypeName() + "," +
                new T15().TypeName() + "," +
                new T16().TypeName() + "," +
                new T17().TypeName() + "," +
                new T18().TypeName() + "," +
                new T19().TypeName() + "," +
                new T20().TypeName() + "," +
                new T21().TypeName() + "," +
                new T22().TypeName() + "," +
                new T23().TypeName() + "," +
                new T24().TypeName() + "," +
                new T25().TypeName() + "," +
                new T26().TypeName() + "," +
                new T27().TypeName() + "," +
                new T28().TypeName() + "," +
                new T29().TypeName() + "," +
                new T30().TypeName() + "," +
                new T31().TypeName() + "," +
                new T32().TypeName() + "," +
                new T33().TypeName() + "," +
                new T34().TypeName() + "," +
                new T35().TypeName() + "," +
                new T36().TypeName() + "," +
                new T37().TypeName() + "," +
                new T38().TypeName() + "," +
                new T39().TypeName() + ")";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new IType[39];

            var t1 = new T1();
            t1.Decode(byteArray, ref p);
            Value[0] = t1;
            var t2 = new T2();
            t2.Decode(byteArray, ref p);
            Value[1] = t2;
            var t3 = new T3();
            t3.Decode(byteArray, ref p);
            Value[2] = t3;
            var t4 = new T4();
            t4.Decode(byteArray, ref p);
            Value[3] = t4;
            var t5 = new T5();
            t5.Decode(byteArray, ref p);
            Value[4] = t5;
            var t6 = new T6();
            t6.Decode(byteArray, ref p);
            Value[5] = t6;
            var t7 = new T7();
            t7.Decode(byteArray, ref p);
            Value[6] = t7;
            var t8 = new T8();
            t8.Decode(byteArray, ref p);
            Value[7] = t8;
            var t9 = new T9();
            t9.Decode(byteArray, ref p);
            Value[8] = t9;
            var t10 = new T10();
            t10.Decode(byteArray, ref p);
            Value[9] = t10;
            var t11 = new T11();
            t11.Decode(byteArray, ref p);
            Value[10] = t11;
            var t12 = new T12();
            t12.Decode(byteArray, ref p);
            Value[11] = t12;
            var t13 = new T13();
            t13.Decode(byteArray, ref p);
            Value[12] = t13;
            var t14 = new T14();
            t14.Decode(byteArray, ref p);
            Value[13] = t14;
            var t15 = new T15();
            t15.Decode(byteArray, ref p);
            Value[14] = t15;
            var t16 = new T16();
            t16.Decode(byteArray, ref p);
            Value[15] = t16;
            var t17 = new T17();
            t17.Decode(byteArray, ref p);
            Value[16] = t17;
            var t18 = new T18();
            t18.Decode(byteArray, ref p);
            Value[17] = t18;
            var t19 = new T19();
            t19.Decode(byteArray, ref p);
            Value[18] = t19;
            var t20 = new T20();
            t20.Decode(byteArray, ref p);
            Value[19] = t20;
            var t21 = new T21();
            t21.Decode(byteArray, ref p);
            Value[20] = t21;
            var t22 = new T22();
            t22.Decode(byteArray, ref p);
            Value[21] = t22;
            var t23 = new T23();
            t23.Decode(byteArray, ref p);
            Value[22] = t23;
            var t24 = new T24();
            t24.Decode(byteArray, ref p);
            Value[23] = t24;
            var t25 = new T25();
            t25.Decode(byteArray, ref p);
            Value[24] = t25;
            var t26 = new T26();
            t26.Decode(byteArray, ref p);
            Value[25] = t26;
            var t27 = new T27();
            t27.Decode(byteArray, ref p);
            Value[26] = t27;
            var t28 = new T28();
            t28.Decode(byteArray, ref p);
            Value[27] = t28;
            var t29 = new T29();
            t29.Decode(byteArray, ref p);
            Value[28] = t29;
            var t30 = new T30();
            t30.Decode(byteArray, ref p);
            Value[29] = t30;
            var t31 = new T31();
            t31.Decode(byteArray, ref p);
            Value[30] = t31;
            var t32 = new T32();
            t32.Decode(byteArray, ref p);
            Value[31] = t32;
            var t33 = new T33();
            t33.Decode(byteArray, ref p);
            Value[32] = t33;
            var t34 = new T34();
            t34.Decode(byteArray, ref p);
            Value[33] = t34;
            var t35 = new T35();
            t35.Decode(byteArray, ref p);
            Value[34] = t35;
            var t36 = new T36();
            t36.Decode(byteArray, ref p);
            Value[35] = t36;
            var t37 = new T37();
            t37.Decode(byteArray, ref p);
            Value[36] = t37;
            var t38 = new T38();
            t38.Decode(byteArray, ref p);
            Value[37] = t38;
            var t39 = new T39();
            t39.Decode(byteArray, ref p);
            Value[38] = t39; TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, T33 t33, T34 t34, T35 t35, T36 t36, T37 t37, T38 t38, T39 t39)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.AddRange(t5.Encode());
            byteList.AddRange(t6.Encode());
            byteList.AddRange(t7.Encode());
            byteList.AddRange(t8.Encode());
            byteList.AddRange(t9.Encode());
            byteList.AddRange(t10.Encode());
            byteList.AddRange(t11.Encode());
            byteList.AddRange(t12.Encode());
            byteList.AddRange(t13.Encode());
            byteList.AddRange(t14.Encode());
            byteList.AddRange(t15.Encode());
            byteList.AddRange(t16.Encode());
            byteList.AddRange(t17.Encode());
            byteList.AddRange(t18.Encode());
            byteList.AddRange(t19.Encode());
            byteList.AddRange(t20.Encode());
            byteList.AddRange(t21.Encode());
            byteList.AddRange(t22.Encode());
            byteList.AddRange(t23.Encode());
            byteList.AddRange(t24.Encode());
            byteList.AddRange(t25.Encode());
            byteList.AddRange(t26.Encode());
            byteList.AddRange(t27.Encode());
            byteList.AddRange(t28.Encode());
            byteList.AddRange(t29.Encode());
            byteList.AddRange(t30.Encode());
            byteList.AddRange(t31.Encode());
            byteList.AddRange(t32.Encode());
            byteList.AddRange(t33.Encode());
            byteList.AddRange(t34.Encode());
            byteList.AddRange(t35.Encode());
            byteList.AddRange(t36.Encode());
            byteList.AddRange(t37.Encode());
            byteList.AddRange(t38.Encode());
            byteList.AddRange(t39.Encode()); byteList.ToArray();

            Value = new IType[39];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;
            Value[7] = t8;
            Value[8] = t9;
            Value[9] = t10;
            Value[10] = t11;
            Value[11] = t12;
            Value[12] = t13;
            Value[13] = t14;
            Value[14] = t15;
            Value[15] = t16;
            Value[16] = t17;
            Value[17] = t18;
            Value[18] = t19;
            Value[19] = t20;
            Value[20] = t21;
            Value[21] = t22;
            Value[22] = t23;
            Value[23] = t24;
            Value[24] = t25;
            Value[25] = t26;
            Value[26] = t27;
            Value[27] = t28;
            Value[28] = t29;
            Value[29] = t30;
            Value[30] = t31;
            Value[31] = t32;
            Value[32] = t33;
            Value[33] = t34;
            Value[34] = t35;
            Value[35] = t36;
            Value[36] = t37;
            Value[37] = t38;
            Value[38] = t39;

            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        public IType[] Value { get; internal set; }
    }
}
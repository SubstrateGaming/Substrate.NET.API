﻿using System;
using System.Collections.Generic;

namespace Ajuna.NetApi.Model.Types.Base
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
            Value[0] = t1;

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.ToArray();

            Value = new IType[1];
            Value[0] = t1;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2> : BaseType
                                                where T1 : IType, new()
                                                where T2 : IType, new()
    {
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
            Value[1] = t2;

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.ToArray();

            Value = new IType[2];
            Value[0] = t1;
            Value[1] = t2;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3> : BaseType
                                            where T1 : IType, new()
                                            where T2 : IType, new()
                                            where T3 : IType, new()
    {
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
            Value[2] = t3;

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.ToArray();

            Value = new IType[3];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
        }

        public IType[] Value { get; internal set; }
    }

    public class BaseTuple<T1, T2, T3, T4> : BaseType
                                            where T1 : IType, new()
                                            where T2 : IType, new()
                                            where T3 : IType, new()
                                            where T4 : IType, new()
    {
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
            Value[3] = t4;

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        public void Create(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            var byteList = new List<byte>();
            byteList.AddRange(t1.Encode());
            byteList.AddRange(t2.Encode());
            byteList.AddRange(t3.Encode());
            byteList.AddRange(t4.Encode());
            byteList.ToArray();

            Value = new IType[4];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
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
            Value[4] = t5;

            TypeSize = p - start;

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
            byteList.AddRange(t5.Encode());
            byteList.ToArray();

            Value = new IType[5];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
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
            Value[5] = t6;

            TypeSize = p - start;

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
            byteList.AddRange(t6.Encode());
            byteList.ToArray();

            Value = new IType[6];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
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
            Value[6] = t7;

            TypeSize = p - start;

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
            byteList.AddRange(t7.Encode());
            byteList.ToArray();

            Value = new IType[7];
            Value[0] = t1;
            Value[1] = t2;
            Value[2] = t3;
            Value[3] = t4;
            Value[4] = t5;
            Value[5] = t6;
            Value[6] = t7;

            TypeSize = byteList.Count;
            Bytes = byteList.ToArray();
        }

        public IType[] Value { get; internal set; }
    }
}
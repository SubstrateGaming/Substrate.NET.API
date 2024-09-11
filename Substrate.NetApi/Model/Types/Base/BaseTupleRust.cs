using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Base Tuple Rust, used to represent a tuple in Rust
    /// </summary>
    public class BaseTupleRust : BaseType
    {
        /// <summary>
        /// Tuple Types
        /// </summary>
        private Type[] _types;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseTupleRust()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public BaseTupleRust(params Type[] types)
        {
            _types = types;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iTypes"></param>
        public BaseTupleRust(params IType[] iTypes)
        {
            Create(iTypes);
        }

        /// <inheritdoc/>
        public override string TypeName()
        {
            return "(" + string.Join(",", Value.Select(v => v.TypeName())) + ")";
        }

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            Value = new IType[_types.Length];
            int o = p;
            for (int i = 0; i < _types.Length; i++)
            {
                var instance = (IType)Activator.CreateInstance(_types[i]);
                instance.Decode(byteArray, ref p);
                Value[i] = instance;
            }
            TypeSize = p - o;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, o, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// Create a new instance of BaseTupleRust
        /// </summary>
        /// <param name="elements"></param>
        public void Create(params IType[] elements)
        {
            Value = elements;
            var byteList = new List<byte>();
            var typeList = new List<Type>();
            foreach (var element in elements)
            {
                byteList.AddRange(element.Encode());
                typeList.Add(element.GetType());
            }
            _types = typeList.ToArray();
            Bytes = byteList.ToArray();
            TypeSize = Bytes.Length;
        }

        /// <summary>
        /// Tuple Value
        /// </summary>
        public IType[] Value { get; internal set; }
    }
}

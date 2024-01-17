using Newtonsoft.Json;

namespace Substrate.NetApi.Model.Types.Base
{
    /// <summary>
    /// Base Type
    /// </summary>
    public abstract class BaseType : IType
    {
        /// <summary>
        /// Type Name
        /// </summary>
        /// <returns></returns>
        public virtual string TypeName() => GetType().Name;

        /// <summary>
        /// Type Size
        /// </summary>
        [JsonIgnore]
        public virtual int TypeSize { get; set; }

        /// <summary>
        /// Bytes
        /// </summary>
        [JsonIgnore]
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Encode to Bytes
        /// </summary>
        /// <returns></returns>
        public abstract byte[] Encode();

        /// <summary>
        /// Decode from a byte array at certain position
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="p"></param>
        public abstract void Decode(byte[] byteArray, ref int p);

        /// <summary>
        /// Create from a string
        /// </summary>
        /// <param name="str"></param>
        public virtual void Create(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// Create from a byte array
        /// </summary>
        /// <param name="byteArray"></param>
        public virtual void Create(byte[] byteArray)
        {
            var p = 0;
            Bytes = byteArray;
            Decode(byteArray, ref p);
        }

        /// <summary>
        /// Create from JSON is used to deserialize in GenericTypeConverters, to automatically convert scale encoded JSON Rust types to C# types.
        /// </summary>
        /// <param name="str"></param>
        public virtual void CreateFromJson(string str) => Create(Utils.HexToByteArray(str));

        /// <summary>
        /// Create a new instance of the type, this uses the default constructor.
        /// </summary>
        /// <returns></returns>
        public IType New() => this;

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
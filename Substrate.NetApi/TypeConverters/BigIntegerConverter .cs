using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Numerics;

namespace Substrate.Integration.Helper
{

    /// <summary>
    /// BigIntegerConverter
    /// </summary>
    public class BigIntegerConverter : JsonConverter<BigInteger>
    {
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            return BigInteger.Parse(stringValue);
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
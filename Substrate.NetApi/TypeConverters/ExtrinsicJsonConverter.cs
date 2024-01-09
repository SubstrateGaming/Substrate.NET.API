using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Substrate.NetApi.Model.Extrinsics;

namespace Substrate.NetApi.TypeConverters
{
    /// <summary>
    /// Extrinsic Json Converter
    /// </summary>
    internal class ExtrinsicJsonConverter : JsonConverter<Extrinsic>
    {
        private readonly ChargeType _chargeType;

        public ExtrinsicJsonConverter(ChargeType chargeType)
        {
            _chargeType = chargeType;
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="Utf8JsonReader" /> to read from.</param>
        /// <param name="typeToConvert">Type of the object.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>The object value.</returns>
        public override Extrinsic Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Assuming the extrinsic is a string in the JSON
            string extrinsicValue = reader.GetString();
            return new Extrinsic(extrinsicValue, _chargeType);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The serializer options.</param>
        public override void Write(Utf8JsonWriter writer, Extrinsic value, JsonSerializerOptions options)
        {
            // Implement serialization logic here if needed
            throw new NotImplementedException();
        }
    }
}

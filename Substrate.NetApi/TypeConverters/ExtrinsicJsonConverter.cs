using Newtonsoft.Json;
using Substrate.NetApi.Model.Extrinsics;
using System;

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
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override Extrinsic ReadJson(JsonReader reader, Type objectType, Extrinsic existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            return new Extrinsic((string)reader.Value, _chargeType);
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, Extrinsic value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
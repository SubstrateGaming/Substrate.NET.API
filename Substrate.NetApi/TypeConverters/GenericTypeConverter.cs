using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Substrate.NetApi.Model.Types;

namespace Substrate.NetApi.TypeConverters
{
    public class GenericTypeConverter<T> : JsonConverter<T> where T : IType, new()
    {
        /// <summary>Gets the name of the type.</summary>
        /// <value>The name of the type.</value>
        public string TypeName { get; } = new T().TypeName();

        /// <summary>Creates a new object.</summary>
        /// <param name="value">The value.</param>
        /// <returns>An object.</returns>
        public object Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            var baseType = new T();
            baseType.Create(value);
            return baseType;
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:System.Text.Json.Utf8JsonReader" /> to read from.</param>
        /// <param name="typeToConvert">Type of the object.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>The object value.</returns>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var baseType = new T();
            baseType.CreateFromJson(reader.GetString());
            return baseType;
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:System.Text.Json.Utf8JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The serializer options.</param>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

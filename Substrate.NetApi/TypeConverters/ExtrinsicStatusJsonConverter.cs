using Newtonsoft.Json;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.TypeConverters
{
    public class ExtrinsicStatusJsonConverter : JsonConverter<ExtrinsicStatus>
    {
        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <exception cref="NotImplementedException">
        /// Unimplemented {reader.TokenType} of type '{reader.ValueType}' and value '{reader.Value}'.
        /// or
        /// Unimplemented {reader.TokenType} of type '{reader.ValueType}' and value '{reader.Value}'.
        /// </exception>
        public override ExtrinsicStatus ReadJson(JsonReader reader, Type objectType, ExtrinsicStatus existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var extrinsicStatus = hasExistingValue ? existingValue : new ExtrinsicStatus();

            if (reader.TokenType == JsonToken.String &&
                Enum.TryParse((string)reader.Value, true, out ExtrinsicState extrinsicState))
            {
                extrinsicStatus.ExtrinsicState = extrinsicState;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.EndObject)
                        break;

                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = reader.Value.ToString();
                        if (Enum.TryParse(propertyName, true, out extrinsicState))
                        {
                            extrinsicStatus.ExtrinsicState = extrinsicState;
                            reader.Read();

                            switch (extrinsicState)
                            {
                                case ExtrinsicState.Broadcast:
                                    var broadcastList = new List<string>();
                                    while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                                    {
                                        if (reader.TokenType == JsonToken.String)
                                            broadcastList.Add(reader.Value.ToString());
                                    }
                                    extrinsicStatus.Broadcast = broadcastList.ToArray();
                                    break;

                                case ExtrinsicState.InBlock:
                                case ExtrinsicState.Finalized:
                                case ExtrinsicState.FinalityTimeout:
                                case ExtrinsicState.Retracted:
                                case ExtrinsicState.Usurped:
                                    if (reader.TokenType == JsonToken.String)
                                        extrinsicStatus.Hash = new Hash(reader.Value.ToString());
                                    break;

                                default:
                                    throw new NotImplementedException(
                                        $"Unimplemented state {extrinsicState} with value '{reader.Value}'.");
                            }
                        }
                    }
                }
            }

            return extrinsicStatus;
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, ExtrinsicStatus value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
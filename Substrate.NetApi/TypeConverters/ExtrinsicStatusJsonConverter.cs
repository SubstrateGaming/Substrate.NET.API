﻿using System;
using System.Collections.Generic;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Newtonsoft.Json;

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
            var extrinsicStatus = new ExtrinsicStatus();

            if (reader.TokenType == JsonToken.String &&
                Enum.TryParse((string)reader.Value, true, out ExtrinsicState extrinsicState))
            {
                extrinsicStatus.ExtrinsicState = extrinsicState;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                reader.Read();

                while (reader.TokenType != JsonToken.EndObject)
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.PropertyName:

                            if (reader.ValueType == typeof(string))
                                switch (reader.Value)
                                {
                                    case "broadcast":
                                        reader.Read();
                                        if (reader.TokenType == JsonToken.StartArray)
                                        {
                                            var broadcastList = new List<string>();
                                            while (reader.TokenType != JsonToken.EndArray)
                                            {
                                                if (reader.ValueType == typeof(string))
                                                    broadcastList.Add((string)reader.Value);
                                                reader.Read();
                                            }

                                            extrinsicStatus.Broadcast = broadcastList.ToArray();
                                        }
                                        extrinsicStatus.ExtrinsicState = ExtrinsicState.Broadcast;
                                        break;

                                    case "inBlock":
                                        reader.Read();
                                        extrinsicStatus.Hash = new Hash((string)reader.Value);
                                        extrinsicStatus.ExtrinsicState = ExtrinsicState.InBlock;
                                        break;

                                    case "finalized":
                                        reader.Read();
                                        extrinsicStatus.Hash = new Hash((string)reader.Value);
                                        extrinsicStatus.ExtrinsicState = ExtrinsicState.Finalized;
                                        break;

                                    case "finalityTimeout":
                                        reader.Read();
                                        extrinsicStatus.Hash = new Hash((string)reader.Value);
                                        extrinsicStatus.ExtrinsicState = ExtrinsicState.FinalityTimeout;
                                        break;

                                    case "retracted":
                                        reader.Read();
                                        extrinsicStatus.Hash = new Hash((string)reader.Value);
                                        extrinsicStatus.ExtrinsicState = ExtrinsicState.Retracted;
                                        break;

                                    case "usurped":
                                        reader.Read();
                                        extrinsicStatus.Hash = new Hash((string)reader.Value);
                                        extrinsicStatus.ExtrinsicState = ExtrinsicState.Usurped;
                                        break;

                                    default:
                                        throw new NotImplementedException(
                                            $"Unimplemented {reader.TokenType} of type '{reader.ValueType}' and value '{reader.Value}'.");
                                }

                            break;

                        default:
                            throw new NotImplementedException(
                                $"Unimplemented {reader.TokenType} of type '{reader.ValueType}' and value '{reader.Value}'.");
                    }

                    reader.Read();
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
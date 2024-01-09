using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Serilog;
using System.Collections.Generic;

namespace Substrate.NetApi.TypeConverters
{
    public class TransactionEventJsonConverter : JsonConverter<TransactionEventInfo>
    {
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override TransactionEventInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var transactionEventStatus = new TransactionEventInfo();

            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;

                var eventName = root.GetProperty("event").GetString();
                if (Enum.TryParse(eventName, true, out TransactionEvent transactionEvent))
                {
                    transactionEventStatus.TransactionEvent = transactionEvent;

                    try
                    {
                        switch (transactionEvent)
                        {
                            case TransactionEvent.Validated:
                                break;

                            case TransactionEvent.Broadcasted:
                                transactionEventStatus.NumPeers = root.GetProperty("numPeers").GetUInt32();
                                break;

                            case TransactionEvent.BestChainBlockIncluded:
                            case TransactionEvent.Finalized:
                                transactionEventStatus.Hash = null;
                                transactionEventStatus.Index = null;
                                if (root.TryGetProperty("block", out JsonElement blockElement))
                                {
                                    transactionEventStatus.Hash = new Hash(blockElement.GetProperty("hash").GetString());
                                    transactionEventStatus.Index = blockElement.GetProperty("index").GetUInt32();
                                }
                                break;

                            case TransactionEvent.Error:
                            case TransactionEvent.Invalid:
                                transactionEventStatus.Error = root.GetProperty("error").GetString();
                                break;

                            case TransactionEvent.Dropped:
                                transactionEventStatus.Broadcasted = root.GetProperty("broadcasted").GetBoolean();
                                transactionEventStatus.Error = root.GetProperty("error").GetString();
                                break;

                            default:
                                throw new NotImplementedException(
                                    $"Unimplemented state {transactionEvent} with value '{eventName}'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Warning("TransactionEventInfo[{eventEnum}]: JSON: {json} - {error}", root.ToString(), transactionEvent, ex);
                    }
                }
            }

            return transactionEventStatus;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(Utf8JsonWriter writer, TransactionEventInfo value, JsonSerializerOptions options)
        {
            // Implement serialization logic here using Utf8JsonWriter
            throw new NotImplementedException();
        }
    }

    public class ExtrinsicStatusJsonConverter : JsonConverter<ExtrinsicStatus>
    {
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override ExtrinsicStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var extrinsicStatus = new ExtrinsicStatus();

            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;

                if (root.ValueKind == JsonValueKind.String)
                {
                    if (Enum.TryParse(root.GetString(), true, out ExtrinsicState extrinsicState))
                    {
                        extrinsicStatus.ExtrinsicState = extrinsicState;
                    }
                }
                else if (root.ValueKind == JsonValueKind.Object)
                {
                    foreach (var property in root.EnumerateObject())
                    {
                        if (Enum.TryParse(property.Name, true, out ExtrinsicState extrinsicState))
                        {
                            extrinsicStatus.ExtrinsicState = extrinsicState;

                            switch (extrinsicState)
                            {
                                case ExtrinsicState.Broadcast:
                                    var broadcastList = new List<string>();
                                    foreach (var item in property.Value.EnumerateArray())
                                    {
                                        if (item.ValueKind == JsonValueKind.String)
                                        {
                                            broadcastList.Add(item.GetString());
                                        }
                                    }
                                    extrinsicStatus.Broadcast = broadcastList.ToArray();
                                    break;

                                case ExtrinsicState.InBlock:
                                case ExtrinsicState.Finalized:
                                case ExtrinsicState.FinalityTimeout:
                                case ExtrinsicState.Retracted:
                                case ExtrinsicState.Usurped:
                                    if (property.Value.ValueKind == JsonValueKind.String)
                                    {
                                        extrinsicStatus.Hash = new Hash(property.Value.GetString());
                                    }
                                    break;

                                default:
                                    throw new NotImplementedException(
                                        $"Unimplemented state {extrinsicState} with value '{property.Value}'.");
                            }
                        }
                    }
                }
            }

            return extrinsicStatus;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(Utf8JsonWriter writer, ExtrinsicStatus value, JsonSerializerOptions options)
        {
            // Serialization logic for ExtrinsicStatus
            throw new NotImplementedException();
        }
    }
}
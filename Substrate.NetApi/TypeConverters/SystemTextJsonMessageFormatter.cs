using StreamJsonRpc;
using StreamJsonRpc.Protocol;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Buffers;
using System.Text.Json;

namespace Substrate.NetApi.TypeConverters
{
    public class SystemTextJsonMessageFormatter : IJsonRpcMessageFormatter
    {
        private JsonSerializerOptions _jsonSerializerOptions;

        public SystemTextJsonMessageFormatter(ChargeType chargeType)
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            // Add your converters
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<U8>());
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<U16>());
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<U8>());
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<U16>());
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<U32>());
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<U64>());
            _jsonSerializerOptions.Converters.Add(new GenericTypeConverter<Hash>());
            _jsonSerializerOptions.Converters.Add(new ExtrinsicJsonConverter(chargeType));
            _jsonSerializerOptions.Converters.Add(new ExtrinsicStatusJsonConverter());
            _jsonSerializerOptions.Converters.Add(new TransactionEventJsonConverter());
            // Add other converters...
        }

        public JsonRpcMessage Deserialize(ReadOnlySequence<byte> contentBuffer)
        {
            // Convert ReadOnlySequence<byte> to byte array
            byte[] array = contentBuffer.ToArray();

            // Deserialize the message
            return JsonSerializer.Deserialize<JsonRpcMessage>(array, _jsonSerializerOptions);
        }

        public object GetJsonText(JsonRpcMessage message)
        {
            // Serialize the message to JSON string
            return JsonSerializer.Serialize(message, _jsonSerializerOptions);
        }

        public void Serialize(IBufferWriter<byte> bufferWriter, JsonRpcMessage message)
        {
            using (var writer = new Utf8JsonWriter(bufferWriter, new JsonWriterOptions { Indented = true }))
            {
                JsonSerializer.Serialize(writer, message, _jsonSerializerOptions);
            }
        }
    }
}
﻿using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Exceptions;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Modules;
using Substrate.NetApi.TypeConverters;
using Microsoft.VisualStudio.Threading;
using Newtonsoft.Json.Linq;
using Serilog;
using StreamJsonRpc;

[assembly: InternalsVisibleTo("Substrate.NetApi.Test")]

namespace Substrate.NetApi
{
    /// <summary> A substrate client. </summary>
    /// <remarks> 19.09.2020. </remarks>
    /// <seealso cref="IDisposable" />
    public class SubstrateClient : IDisposable
    {
        /// <summary> The logger. </summary>
        private static readonly ILogger Logger = new LoggerConfiguration().CreateLogger();

        private readonly ExtrinsicJsonConverter _extrinsicJsonConverter;

        private readonly ExtrinsicStatusJsonConverter _extrinsicStatusJsonConverter;

        private readonly TransactionEventJsonConverter _transactionEventJsonConverter;

        /// <summary> The request token sources. </summary>
        private readonly ConcurrentDictionary<CancellationTokenSource, string> _requestTokenSourceDict;

        /// <summary> _URI of the resource. </summary>
        private readonly Uri _uri;

        /// <summary> The connect token source. </summary>
        private CancellationTokenSource _connectTokenSource;

        /// <summary> The JSON RPC. </summary>
        private JsonRpc _jsonRpc;

        /// <summary> The socket. </summary>
        private ClientWebSocket _socket;

        /// <summary>
        /// Bypass Remote Certificate Validation. Useful when testing with self-signed SSL certificates. 
        /// </summary>
        private readonly bool _bypassRemoteCertificateValidation;

        /// <summary>
        /// Substrate client
        /// </summary>
        /// <param name="uri">Uri of the node</param>
        /// <param name="chargeType">Charge type</param>
        /// <param name="bypassRemoteCertificateValidation">By default, the client will validate the SSL certificate of the node. Set this to true to bypass this validation.</param>
        public SubstrateClient(Uri uri, ChargeType chargeType, bool bypassRemoteCertificateValidation = false)
        {
            _uri = uri;
            _bypassRemoteCertificateValidation = bypassRemoteCertificateValidation;

            _extrinsicJsonConverter = new ExtrinsicJsonConverter(chargeType);
            _extrinsicStatusJsonConverter = new ExtrinsicStatusJsonConverter();
            _transactionEventJsonConverter = new TransactionEventJsonConverter();

            System = new Modules.System(this);
            Chain = new Chain(this);
            Payment = new Payment(this);
            State = new State(this);
            Author = new Author(this);
            Unstable = new UnstableCalls(this);

            _requestTokenSourceDict = new ConcurrentDictionary<CancellationTokenSource, string>();
        }

        /// <summary> Gets or sets information describing the meta. </summary>
        /// <value> Information describing the meta. </value>
        public MetaData MetaData { get; private set; }

        /// <summary> 
        /// Network runtime version
        /// </summary>
        public RuntimeVersion RuntimeVersion { get; private set; }

        /// <summary>
        /// Network propoerties
        /// </summary>
        public Properties Properties { get; private set; }

        /// <summary> Gets or sets the genesis hash. </summary>
        /// <value> The genesis hash. </value>
        public Hash GenesisHash { get; private set; }

        /// <summary> Gets the system. </summary>
        /// <value> The system. </value>
        public Modules.System System { get; }

        /// <summary> Gets the chain. </summary>
        /// <value> The chain. </value>
        public Chain Chain { get; }

        /// <summary> Gets the payment. </summary>
        /// <value> The payment. </value>
        public Payment Payment { get; }

        /// <summary> Gets the state. </summary>
        /// <value> The state. </value>
        public State State { get; }

        /// <summary> Gets the author. </summary>
        /// <value> The author. </value>
        public Author Author { get; }

        /// <summary>
        /// New Api 2
        /// </summary>
        public UnstableCalls Unstable { get; }

        public SubscriptionListener Listener { get; } = new SubscriptionListener();

        /// <summary> Gets a value indicating whether this object is connected. </summary>
        /// <value> True if this object is connected, false if not. </value>
        public bool IsConnected => _socket?.State == WebSocketState.Open && _jsonRpc != null;

        /// <summary>
        /// Sets the JSON-RPC logging level.
        /// </summary>
        /// <param name="sourceLevels"></param>
        /// <returns></returns>
        public bool SetJsonRPCTraceLevel(SourceLevels sourceLevels)
        {
            if (_jsonRpc == null)
            {
                return false;
            }
            _jsonRpc.TraceSource.Switch.Level = sourceLevels;
            return true;
        }

        /// <summary>
        /// Asynchronously connects to the node.
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            await ConnectAsync(true, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously connects to the node.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken token)
        {
            await ConnectAsync(true, token);
        }

        /// <summary>
        /// Asynchronously connects to the node.
        /// </summary>
        /// <param name="useMetaData">Parse metadata on connect.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        public async Task ConnectAsync(bool useMetaData, CancellationToken token)
        {
            await ConnectAsync(useMetaData, true, token);
        }

        /// <summary>
        /// Asynchronously connects to the node.
        /// </summary>
        /// <param name="useMetaData">Parse metadata on connect.</param>
        /// <param name="standardSubstrate">Get blocknumber and runtime information from standard susbtrate node.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        public async Task ConnectAsync(bool useMetaData, bool standardSubstrate, CancellationToken token)
        {
            if (_socket != null && _socket.State == WebSocketState.Open)
                return;

            if (_socket == null || _socket.State != WebSocketState.None)
            {
                _jsonRpc?.Dispose();
                _socket?.Dispose();
                _socket = new ClientWebSocket();

                // Set RemoteCertificateValidationCallback to return true
                if (_bypassRemoteCertificateValidation)
                {
#if NETSTANDARD2_0
                    throw new NotSupportedException("Bypass remote certification validation not supported in NETStandard2.0");
#elif NETSTANDARD2_1_OR_GREATER
                    _socket.Options.RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true;    
#endif
                }
            }

            _connectTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, _connectTokenSource.Token);
            await _socket.ConnectAsync(_uri, linkedTokenSource.Token);
            linkedTokenSource.Dispose();
            _connectTokenSource.Dispose();
            _connectTokenSource = null;
            Logger.Debug("Connected to Websocket.");

            var formatter = new JsonMessageFormatter();

            // adding converters to the formatter
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U8>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U16>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U32>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<U64>());
            formatter.JsonSerializer.Converters.Add(new GenericTypeConverter<Hash>());
            formatter.JsonSerializer.Converters.Add(_extrinsicJsonConverter);
            formatter.JsonSerializer.Converters.Add(_extrinsicStatusJsonConverter);
            formatter.JsonSerializer.Converters.Add(_transactionEventJsonConverter);

            _jsonRpc = new JsonRpc(new WebSocketMessageHandler(_socket, formatter));
            _jsonRpc.TraceSource.Listeners.Add(new SerilogTraceListener.SerilogTraceListener());
            _jsonRpc.TraceSource.Switch.Level = SourceLevels.Warning;
            _jsonRpc.AddLocalRpcTarget(Listener, new JsonRpcTargetOptions { AllowNonPublicInvocation = false });
            _jsonRpc.StartListening();
            Logger.Debug("Listening to websocket.");

            if (useMetaData)
            {
                var result = await State.GetMetaDataAsync(token);

                var mdv14 = new RuntimeMetadata();
                mdv14.Create(result);
                MetaData = new MetaData(mdv14, _uri.OriginalString);
                Logger.Debug("MetaData parsed.");
            }

            if (standardSubstrate)
            {
                var genesis = new BlockNumber();
                genesis.Create(0);
                GenesisHash = await Chain.GetBlockHashAsync(genesis, token);
                Logger.Debug("Genesis hash parsed.");

                RuntimeVersion = await State.GetRuntimeVersionAsync(token);
                Logger.Debug("Runtime version parsed.");

                Properties = await System.PropertiesAsync(token);
                Logger.Debug("Properties parsed.");
            }

            //_jsonRpc.TraceSource.Switch.Level = SourceLevels.All;
        }

        /// <summary>
        /// Gets the storage asynchronous for generated code.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual async Task<T> GetStorageAsync<T>(string parameters, CancellationToken token) where T : IType, new()
        {
            return await GetStorageAsync<T>(parameters, null, token);
        }

        /// <summary>
        /// Gets the storage asynchronous from a blockhash for generated code.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <param name="blockhash"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual async Task<T> GetStorageAsync<T>(string parameters, string blockhash, CancellationToken token) where T : IType, new()
        {
            var str = await InvokeAsync<string>("state_getStorage", new object[] { parameters, blockhash }, token);

            if (str == null || str.Length == 0)
            {
                return default;
            }

            T t = new T();
            t.Create(str);

            return t;
        }

        /// <summary>
        /// Subscribe to storage changes
        /// </summary>
        /// <param name="storageParams"></param>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ClientNotConnectedException"></exception>
        public virtual async Task<string> SubscribeStorageKeyAsync(string storageParams, Action<string, StorageChangeSet> callback, CancellationToken token)
        {
            if (_socket?.State != WebSocketState.Open)
                throw new ClientNotConnectedException($"WebSocketState is not open! Currently {_socket?.State}!");

            var subscriptionId =
                await InvokeAsync<string>("state_subscribeStorage", new object[] { new JArray { storageParams } }, token);

            Listener.RegisterCallBackHandler(subscriptionId, callback);

            return subscriptionId;
        }

        /// <summary>
        /// Get method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public async Task<T> GetMethodAsync<T>(string method)
        {
            return await GetMethodAsync<T>(method, CancellationToken.None);
        }

        /// <summary> Gets method asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method"> The method. </param>
        /// <param name="token">  A token that allows processing to be cancelled. </param>
        /// <returns> The method async&lt; t&gt; </returns>
        public async Task<T> GetMethodAsync<T>(string method, CancellationToken token)
        {
            return await InvokeAsync<T>(method, null, token);
        }

        /// <summary> Gets method asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method">    The method. </param>
        /// <param name="parameter"> The parameter. </param>
        /// <param name="token">     A token that allows processing to be cancelled. </param>
        /// <returns> The method async&lt; t&gt; </returns>
        public async Task<T> GetMethodAsync<T>(string method, string parameter, CancellationToken token)
        {
            return await InvokeAsync<T>(method, new object[] { parameter }, token);
        }

        /// <summary>
        /// Get extrinsic parameters
        /// </summary>
        /// <param name="method"></param>
        /// <param name="account"></param>
        /// <param name="charge"></param>
        /// <param name="lifeTime"></param>
        /// <param name="signed"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UnCheckedExtrinsic> GetExtrinsicParametersAsync(Method method, Account account, ChargeType charge, uint lifeTime, bool signed, CancellationToken token)
        {
            var nonce = await System.AccountNextIndexAsync(account.Value, token);

            Era era;
            Hash startEra;

            if (lifeTime == 0)
            {
                era = Era.Create(0, 0);
                startEra = GenesisHash;
            }
            else
            {
                startEra = await Chain.GetFinalizedHeadAsync(token);
                var finalizedHeader = await Chain.GetHeaderAsync(startEra, token);
                era = Era.Create(lifeTime, finalizedHeader.Number.Value);
            }

            var uncheckedExtrinsic = await RequestGenerator.SubmitExtrinsicAsync(signed, account, method, era, nonce, charge, GenesisHash, startEra, RuntimeVersion); ;

            return uncheckedExtrinsic;
        }

        /// <summary>
        ///     Executes the asynchronous on a different thread, and waits for the result.
        /// </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <exception cref="ClientNotConnectedException">
        ///     Thrown when a Client Not Connected error
        ///     condition occurs.
        /// </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="method">     The method. </param>
        /// <param name="parameters"> Options for controlling the operation. </param>
        /// <param name="token">      A token that allows processing to be cancelled. </param>
        /// <returns> A T. </returns>
        public virtual async Task<T> InvokeAsync<T>(string method, object parameters, CancellationToken token)
        {
            if (_socket?.State != WebSocketState.Open)
                throw new ClientNotConnectedException($"WebSocketState is not open! Currently {_socket?.State}!");

            Logger.Debug($"Invoking request[{method}, params: {parameters}] {MetaData?.Origin}");

            var requestTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            _requestTokenSourceDict.TryAdd(requestTokenSource, string.Empty);

            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, requestTokenSource.Token);
            var resultString =
                await _jsonRpc.InvokeWithParameterObjectAsync<T>(method, parameters, linkedTokenSource.Token);

            linkedTokenSource.Dispose();
            requestTokenSource.Dispose();

            _requestTokenSourceDict.TryRemove(requestTokenSource, out var _);

            return resultString;
        }

        /// <summary> Closes an asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <returns> An asynchronous result. </returns>
        public async Task CloseAsync()
        {
            await CloseAsync(CancellationToken.None);
        }

        /// <summary> Closes an asynchronous. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="token"> A token that allows processing to be cancelled. </param>
        /// <returns> An asynchronous result. </returns>
        public async Task CloseAsync(CancellationToken token)
        {
            _connectTokenSource?.Cancel();

            await Task.Run(() =>
            {
                // cancel remaining request tokens
                foreach (var key in _requestTokenSourceDict.Keys) key?.Cancel();
                _requestTokenSourceDict.Clear();

                if (_socket != null && _socket.State == WebSocketState.Open)
                {
                    _jsonRpc?.Dispose();
                    Logger.Debug("Client closed.");
                }
            });
        }

        #region IDisposable Support

        /// <summary> To detect redundant calls. </summary>
        private bool _disposedValue;

        /// <summary> This code added to correctly implement the disposable pattern. </summary>
        /// <remarks> 19.09.2020. </remarks>
        /// <param name="disposing">
        ///     True to release both managed and unmanaged resources; false to
        ///     release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    new JoinableTaskFactory(new JoinableTaskContext()).Run(CloseAsync);
                    _connectTokenSource?.Dispose();

                    // dispose remaining request tokens
                    foreach (var key in _requestTokenSourceDict.Keys) key?.Dispose();
                    _requestTokenSourceDict.Clear();

                    _jsonRpc?.Dispose();
                    _socket?.Dispose();
                    Logger.Debug("Client disposed.");
                }

                _disposedValue = true;
            }
        }

        /// <summary> This code added to correctly implement the disposable pattern. </summary>
        /// <remarks> 19.09.2020. </remarks>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}
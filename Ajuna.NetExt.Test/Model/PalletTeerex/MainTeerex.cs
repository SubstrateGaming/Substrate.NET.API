//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.PrimitiveTypes;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.TeerexPrimitives;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Ajuna.NetApi.Model.PalletTeerex
{
    
    
    public sealed class TeerexStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public TeerexStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Teerex", "EnclaveRegistry"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.Types.Primitive.U64), typeof(Ajuna.NetApi.Model.TeerexPrimitives.Enclave)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Teerex", "EnclaveCount"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Teerex", "EnclaveIndex"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.SpCore.AccountId32), typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Teerex", "ExecutedCalls"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Ajuna.NetApi.Model.PrimitiveTypes.H256), typeof(Ajuna.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Teerex", "AllowSGXDebugMode"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Ajuna.NetApi.Model.Types.Primitive.Bool)));
        }
        
        /// <summary>
        /// >> EnclaveRegistryParams
        /// </summary>
        public static string EnclaveRegistryParams(Ajuna.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("Teerex", "EnclaveRegistry", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> EnclaveRegistry
        /// </summary>
        public async Task<Ajuna.NetApi.Model.TeerexPrimitives.Enclave> EnclaveRegistry(Ajuna.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = TeerexStorage.EnclaveRegistryParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.TeerexPrimitives.Enclave>(parameters, token);
        }
        
        /// <summary>
        /// >> EnclaveCountParams
        /// </summary>
        public static string EnclaveCountParams()
        {
            return RequestGenerator.GetStorage("Teerex", "EnclaveCount", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> EnclaveCount
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> EnclaveCount(CancellationToken token)
        {
            string parameters = TeerexStorage.EnclaveCountParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> EnclaveIndexParams
        /// </summary>
        public static string EnclaveIndexParams(Ajuna.NetApi.Model.SpCore.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Teerex", "EnclaveIndex", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> EnclaveIndex
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> EnclaveIndex(Ajuna.NetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = TeerexStorage.EnclaveIndexParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> ExecutedCallsParams
        /// </summary>
        public static string ExecutedCallsParams(Ajuna.NetApi.Model.PrimitiveTypes.H256 key)
        {
            return RequestGenerator.GetStorage("Teerex", "ExecutedCalls", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ExecutedCalls
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.U64> ExecutedCalls(Ajuna.NetApi.Model.PrimitiveTypes.H256 key, CancellationToken token)
        {
            string parameters = TeerexStorage.ExecutedCallsParams(key);
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.U64>(parameters, token);
        }
        
        /// <summary>
        /// >> AllowSGXDebugModeParams
        /// </summary>
        public static string AllowSGXDebugModeParams()
        {
            return RequestGenerator.GetStorage("Teerex", "AllowSGXDebugMode", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> AllowSGXDebugMode
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Primitive.Bool> AllowSGXDebugMode(CancellationToken token)
        {
            string parameters = TeerexStorage.AllowSGXDebugModeParams();
            return await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Primitive.Bool>(parameters, token);
        }
    }
    
    public sealed class TeerexCalls
    {
        
        /// <summary>
        /// >> register_enclave
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RegisterEnclave(BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> ra_report, BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> worker_url)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(ra_report.Encode());
            byteArray.AddRange(worker_url.Encode());
            return new Method(19, "Teerex", 0, "register_enclave", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> unregister_enclave
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UnregisterEnclave()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(19, "Teerex", 1, "unregister_enclave", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> call_worker
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CallWorker(Ajuna.NetApi.Model.TeerexPrimitives.Request request)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(request.Encode());
            return new Method(19, "Teerex", 2, "call_worker", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> confirm_processed_parentchain_block
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ConfirmProcessedParentchainBlock(Ajuna.NetApi.Model.PrimitiveTypes.H256 block_hash, Ajuna.NetApi.Model.PrimitiveTypes.H256 trusted_calls_merkle_root)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(block_hash.Encode());
            byteArray.AddRange(trusted_calls_merkle_root.Encode());
            return new Method(19, "Teerex", 3, "confirm_processed_parentchain_block", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> shield_funds
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ShieldFunds(BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> incognito_account_encrypted, Ajuna.NetApi.Model.Types.Primitive.U128 amount, Ajuna.NetApi.Model.SpCore.AccountId32 bonding_account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(incognito_account_encrypted.Encode());
            byteArray.AddRange(amount.Encode());
            byteArray.AddRange(bonding_account.Encode());
            return new Method(19, "Teerex", 4, "shield_funds", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> unshield_funds
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method UnshieldFunds(Ajuna.NetApi.Model.SpCore.AccountId32 public_account, Ajuna.NetApi.Model.Types.Primitive.U128 amount, Ajuna.NetApi.Model.SpCore.AccountId32 bonding_account, Ajuna.NetApi.Model.PrimitiveTypes.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(public_account.Encode());
            byteArray.AddRange(amount.Encode());
            byteArray.AddRange(bonding_account.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(19, "Teerex", 5, "unshield_funds", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> AddedEnclave
    /// </summary>
    public sealed class EventAddedEnclave : BaseTuple<Ajuna.NetApi.Model.SpCore.AccountId32, BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>
    {
    }
    
    /// <summary>
    /// >> RemovedEnclave
    /// </summary>
    public sealed class EventRemovedEnclave : BaseTuple<Ajuna.NetApi.Model.SpCore.AccountId32>
    {
    }
    
    /// <summary>
    /// >> Forwarded
    /// </summary>
    public sealed class EventForwarded : BaseTuple<Ajuna.NetApi.Model.PrimitiveTypes.H256>
    {
    }
    
    /// <summary>
    /// >> ShieldFunds
    /// </summary>
    public sealed class EventShieldFunds : BaseTuple<BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>
    {
    }
    
    /// <summary>
    /// >> UnshieldedFunds
    /// </summary>
    public sealed class EventUnshieldedFunds : BaseTuple<Ajuna.NetApi.Model.SpCore.AccountId32>
    {
    }
    
    /// <summary>
    /// >> ProcessedParentchainBlock
    /// </summary>
    public sealed class EventProcessedParentchainBlock : BaseTuple<Ajuna.NetApi.Model.SpCore.AccountId32, Ajuna.NetApi.Model.PrimitiveTypes.H256, Ajuna.NetApi.Model.PrimitiveTypes.H256>
    {
    }
    
    public enum TeerexErrors
    {
        
        /// <summary>
        /// >> EnclaveSignerDecodeError
        /// Failed to decode enclave signer.
        /// </summary>
        EnclaveSignerDecodeError,
        
        /// <summary>
        /// >> SenderIsNotAttestedEnclave
        /// Sender does not match attested enclave in report.
        /// </summary>
        SenderIsNotAttestedEnclave,
        
        /// <summary>
        /// >> RemoteAttestationVerificationFailed
        /// Verifying RA report failed.
        /// </summary>
        RemoteAttestationVerificationFailed,
        
        /// <summary>
        /// >> RemoteAttestationTooOld
        /// </summary>
        RemoteAttestationTooOld,
        
        /// <summary>
        /// >> SgxModeNotAllowed
        /// The enclave cannot attest, because its building mode is not allowed.
        /// </summary>
        SgxModeNotAllowed,
        
        /// <summary>
        /// >> EnclaveIsNotRegistered
        /// The enclave is not registered.
        /// </summary>
        EnclaveIsNotRegistered,
        
        /// <summary>
        /// >> WrongMrenclaveForBondingAccount
        /// The bonding account doesn't match the enclave.
        /// </summary>
        WrongMrenclaveForBondingAccount,
        
        /// <summary>
        /// >> WrongMrenclaveForShard
        /// The shard doesn't match the enclave.
        /// </summary>
        WrongMrenclaveForShard,
        
        /// <summary>
        /// >> EnclaveUrlTooLong
        /// The worker url is too long.
        /// </summary>
        EnclaveUrlTooLong,
        
        /// <summary>
        /// >> RaReportTooLong
        /// The Remote Attestation report is too long.
        /// </summary>
        RaReportTooLong,
        
        /// <summary>
        /// >> EmptyEnclaveRegistry
        /// No enclave is registered.
        /// </summary>
        EmptyEnclaveRegistry,
    }
}

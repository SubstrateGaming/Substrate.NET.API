# Accounts Signature and Verification for Sr25519 

Substrate.NET.API provide full control on instanciating an account, sign a transaction, and then verify it
If you want an easier-to-use nuget package, please use [Substrate.NET.Wallet](https://github.com/SubstrateGaming/Substrate.NET.Wallet)

When creating an Sr25519 account here you first need the seed
The seed can be get from

|  | Substrate.NET.Wallet          | Substrate.NET.API |
| :--------------- |:---------------| :-----|
| Uri  |   [CreateFromUri](https://github.com/SubstrateGaming/Substrate.NET.Wallet/blob/master/Substrate.NET.Wallet/Keyring/Keyring.cs#L144)        | |
| Mnemonic phrase  | [CreateFromUri](https://github.com/SubstrateGaming/Substrate.NET.Wallet/blob/master/Substrate.NET.Wallet/Keyring/Keyring.cs#L144) | [GetSecretKeyFromMnemonic](https://github.com/SubstrateGaming/Substrate.NET.API/blob/master/Substrate.NetApi/Mnemonic.cs#L194) |

With the seed, we can now instanciate a new [MiniSecret](https://github.com/SubstrateGaming/Substrate.NET.Schnorrkel/blob/main/Substrate.NET.Schnorrkel/Keys/MiniSecret.cs) with expand mode



Then an account can be created by choosing one of this two options

| Private key  | Sign          | Verify |
| :--------------- |:---------------| :-----|
| miniSecret.ExpandToSecret().ToEd25519Bytes()  |   Sr25519v091.SignEd25519()        |  Sr25519v091.VerifyEd25519() |
| miniSecret.ExpandToSecret().ToBytes()  |   Sr25519v091.SignSimple()        |  Sr25519v091.Verify() |


Here is a full example of this two options :

```c#
/* 
 * Build an account with ExpandToSecret().ToHalfEd25519Bytes() => concatenate secret with MultiplyScalarBytesByCofactor + nonce
 */
var miniSecret_Ed25519Bytes = new Schnorrkel.Keys.MiniSecret(seed, Schnorrkel.Keys.ExpandMode.Ed25519);
var account_Ed25519Bytes = Account.Build(KeyType.Sr25519, miniSecret_Ed25519Bytes.ExpandToSecret().ToEd25519Bytes(), miniSecret_Ed25519Bytes.ExpandToPublic().Key);

string message = "this is a message";
// Sign
var signature_Ed25519 = Sr25519v091.SignEd25519(account_Ed25519Bytes.Bytes, account_Ed25519Bytes.PrivateKey, message.ToBytes());

// Verify
var isVerified = Sr25519v091.VerifyEd25519(signature_Ed25519, account_Ed25519Bytes.Bytes, message.ToBytes())
```

```c#
/* 
 * Build an account with ExpandToSecret().ToBytes() => concatenate secret + nonce
 */
var miniSecret_simple = new Schnorrkel.Keys.MiniSecret(seed, Schnorrkel.Keys.ExpandMode.Ed25519);
var account_simple = Account.Build(KeyType.Sr25519, miniSecret_simple.ExpandToSecret().ToBytes(), miniSecret_simple.ExpandToPublic().Key);

string message = "this is a message";
// Sign
var signature_simple_1 = Sr25519v091.SignSimple(account_simple.Bytes, account_simple.PrivateKey, message.ToBytes());

// Verify
Sr25519v091.Verify(signature_simple_1, account_simple.Bytes, message.ToBytes())
```
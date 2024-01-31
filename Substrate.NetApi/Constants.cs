namespace Substrate.NetApi
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The default era period
        /// </summary>
        public const ulong ExtrinsicEraPeriodDefault = 64;

        /// <summary>The extrinsic version</summary>
        public const byte ExtrinsicVersion = 4; // aka the 2. TRANSACTION_VERSION

        // https://github.com/paritytech/substrate/blob/c0cb70419798eb7fd38806da668bec05f8cfd7f1/primitives/runtime/src/generic/unchecked_extrinsic.rs#L33

        /// <summary>
        /// The address version
        ///  https://polkadot.js.org/docs/api/FAQ/
        ///  0 = AccountId (no prefix), 1 = IndicesLookup (0xFF), 2 = MutiAddress (https://github.com/paritytech/substrate/pull/7380)
        /// </summary>
        public static uint AddressVersion = 2;
    }
}
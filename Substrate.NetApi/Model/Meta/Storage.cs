namespace Substrate.NetApi.Model.Meta
{
    /// <summary>
    /// Storage
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Storage Type Enum
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Plain
            /// </summary>
            Plain,

            /// <summary>
            /// Map
            /// </summary>
            Map,

            /// <summary>
            /// Double Map
            /// </summary>
            DoubleMap,

            /// <summary>
            /// NMap
            /// </summary>
            NMap
        }

        /// <summary>
        /// Storage Modifier Enum
        /// </summary>
        public enum Modifier
        {
            /// <summary>
            /// Optional
            /// </summary>
            Optional,

            /// <summary>
            /// Default
            /// </summary>
            Default
        }

        /// <summary>
        /// Storage Hasher Enum
        /// </summary>
        public enum Hasher
        {
            /// <summary>
            /// None
            /// </summary>
            None = -1,

            /// <summary>
            /// Blake2 128
            /// </summary>
            BlakeTwo128,

            /// <summary>
            /// Blake2 256
            /// </summary>
            BlakeTwo256,

            /// <summary>
            /// Blake2 128 Concat
            /// </summary>
            BlakeTwo128Concat,

            /// <summary>
            /// Twox 128
            /// </summary>
            Twox128,

            /// <summary>
            /// Twox 256
            /// </summary>
            Twox256,

            /// <summary>
            /// Twox 64 Concat
            /// </summary>
            Twox64Concat,

            /// <summary>
            /// Identity
            /// </summary>
            Identity
        }
    }
}
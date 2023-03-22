﻿namespace Substrate.NetApi.Model.Meta
{
    public class Storage
    {
        public enum Type
        {
            Plain,
            Map,
            DoubleMap,
            NMap
        }

        public enum Modifier
        {
            Optional,
            Default
        }

        public enum Hasher
        {
            None = -1,
            BlakeTwo128,
            BlakeTwo256,
            BlakeTwo128Concat,
            Twox128,
            Twox256,
            Twox64Concat,
            Identity
        }
    }
}
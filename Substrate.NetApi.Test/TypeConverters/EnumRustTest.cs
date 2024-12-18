﻿using NUnit.Framework;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Tests
{
    public enum PhaseState
    {
        None = 0,
        Finalization = 1,
        Initialization = 2
    }

    [TestFixture]
    public class BaseEnumRustTests
    {
        [Test]
        public void ExtEnumEncodingTest()
        {
            var typeDecoderMap = new Dictionary<PhaseState, Type>
            {
                { PhaseState.None, typeof(U8) },
                { PhaseState.Finalization, typeof(BaseVoid) },
                { PhaseState.Initialization, typeof(BaseVoid) }
            };

            var extEnumType = new BaseEnumRust<PhaseState>(typeDecoderMap);

            int p = 0;
            extEnumType.Decode(new byte[] { 0x00, 0x01 }, ref p);

            Assert.AreEqual(PhaseState.None, extEnumType.Value);
            Assert.AreEqual("U8", extEnumType.Value2.GetType().Name);
            Assert.AreEqual(1, (extEnumType.Value2 as U8).Value);
        }

        [Test]
        public void ExtEnumDencodingTest()
        {
            var typeDecoderMap = new Dictionary<PhaseState, Type>
            {
                { PhaseState.None, typeof(U8) },
                { PhaseState.Finalization, typeof(BaseVoid) },
                { PhaseState.Initialization, typeof(BaseVoid) }
            };

            var extEnumType = new BaseEnumRust<PhaseState>(typeDecoderMap);

            int p = 0;
            extEnumType.Decode(new byte[] { 0x00, 0x01 }, ref p);

            Assert.AreEqual(PhaseState.None, extEnumType.Value);
            Assert.AreEqual("U8", extEnumType.Value2.GetType().Name);
            Assert.AreEqual(1, (extEnumType.Value2 as U8).Value);

            Assert.AreEqual(new byte[] { 0x00, 0x01 }, extEnumType.Bytes);
        }

        [Test]
        public void ExtEnumCreateTest()
        {
            var typeDecoderMap = new Dictionary<PhaseState, Type>
            {
                { PhaseState.None, typeof(U8) },
                { PhaseState.Finalization, typeof(BaseVoid) },
                { PhaseState.Initialization, typeof(BaseVoid) }
            };

            var u8 = new U8(1);
            var byValue = new BaseEnumRust<PhaseState>(typeDecoderMap);
            byValue.Create(PhaseState.None, u8);

            var byArray = new BaseEnumRust<PhaseState>();
            byArray.AddTypeDecoder<U8>(PhaseState.None);
            byArray.AddTypeDecoder<BaseVoid>(PhaseState.Finalization);
            byArray.AddTypeDecoder<BaseVoid>(PhaseState.Initialization);
            byArray.Create(new byte[] { 0, 1 });

            var byHex = new BaseEnumRust<PhaseState>();
            byHex.AddTypeDecoder<U8>(PhaseState.None);
            byHex.AddTypeDecoder<BaseVoid>(PhaseState.Finalization);
            byHex.AddTypeDecoder<BaseVoid>(PhaseState.Initialization);
            byHex.Create("0x0001");

            Assert.That(byValue.Bytes, Is.EqualTo(byArray.Bytes));
            Assert.That(byValue.Value, Is.EqualTo(byArray.Value));

            Assert.That(byValue.Bytes, Is.EqualTo(byHex.Bytes));
            Assert.That(byValue.Value, Is.EqualTo(byHex.Value));
        }
    }
}
using System;
using Substrate.NetApi.Model.Extrinsics;
using NUnit.Framework;

namespace Substrate.NetApi.Test.Extrinsic
{
    public class EraTest
    {
        private Random _random;

        [OneTimeSetUp]
        public void Setup()
        {
            _random = new Random();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void EraEncodeDecodeTest()
        {
            var era1 = Era.Decode(new byte[] { 58, 6 });
            Assert.AreEqual(2048, era1.Period);
            Assert.AreEqual(99, era1.Phase);
            Assert.AreEqual(new byte[] { 58, 6 }, era1.Encode());

            var era2 = Era.Decode(Utils.HexToByteArray("0x4503"));
            Assert.AreEqual(64, era2.Period);
            Assert.AreEqual(52, era2.Phase);
            Assert.AreEqual(new byte[] { 69, 3 }, era2.Encode());

            var era3 = Era.Decode(Utils.HexToByteArray("0xF502"));
            Assert.AreEqual(64, era3.Period);
            Assert.AreEqual(47, era3.Phase);
            Assert.AreEqual(new byte[] { 245, 2 }, era3.Encode());
        }

        [Test]
        [TestCase(64u, 49u, 1587u, 1585u)]
        [TestCase(64u, 45u, 21604404u, 21604397u)]
        public void EraBeginTest(ulong period, ulong phase, ulong currentBlock, ulong expectedBlock)
        {
            var era = new Era(period, phase, false);
            Assert.AreEqual(expectedBlock, era.EraStart(currentBlock));
        }

        [Test]
        [TestCase(64u, 49u, 1587u, 1649u)]
        [TestCase(64u, 45u, 21604404u, 21604461u)]
        public void EraEndTest(ulong period, ulong phase, ulong currentBlock, ulong expectedBlock)
        {
            var era = new Era(period, phase, false);
            Assert.AreEqual(expectedBlock, era.EraEnd(currentBlock));
        }

        [Test]
        public void EraCreateTest()
        {
            var era = Era.Create(12, 15686);
            Assert.AreEqual(16, era.Period);
            Assert.AreEqual(6, era.Phase);
        }
    }
}
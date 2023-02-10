using Ajuna.NetApi.Sign;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajuna.NetApi.Test.Keys
{
    public class WrapMessageTest
    {
        [Test]
        [TestCase("<Bytes>test</Bytes>")]
        [TestCase("<Bytes><byte>AlmostInception</byte></Bytes>")]
        public void MessageWrapped_ShouldBeDetected(string message)
        {
            Assert.That(WrapMessage.IsWrapped(message), Is.True);
        }

        [Test]
        [TestCase("IamNotWrapped")]
        [TestCase("<Byte>almostwrapped</Bytes>")]
        [TestCase("<bytes>casesentitive</bytes>")]
        public void UnwrapMessage_ShouldBeDetected(string message)
        {
            Assert.That(WrapMessage.IsWrapped(message), Is.False);
        }

        [Test]
        public void UnwrapMessage_ShouldBeWrapped()
        {
            var message = "test";
            var messageWrapped = new byte[]
            {
                60, 66, 121, 116, 101, 115, 62, 116, 101, 115, 116, 60, 47, 66, 121, 116, 101, 115, 62
            };

            Assert.That(WrapMessage.IsWrapped(message), Is.False);
            Assert.That(WrapMessage.Wrap(message), Is.EqualTo(messageWrapped));
        }

        [Test]
        public void WrapMessage_ShouldBeUnwrap()
        {
            var message = "<Bytes>test</Bytes>";
            var messageUnwrapped = new byte[]
            {
                116, 101, 115, 116
            };

            Assert.That(WrapMessage.IsWrapped(message), Is.True);
            Assert.That(WrapMessage.Unwrap(message), Is.EqualTo(messageUnwrapped));
        }

        [Test]
        public void MultipleWrapAndUnwrap_ShouldBeUntouched()
        {
            var message = "IAmAMessage";
            Assert.That(WrapMessage.Wrap(WrapMessage.Wrap(WrapMessage.Wrap(WrapMessage.Wrap(message)))), Is.EqualTo(WrapMessage.Wrap(message)));
            Assert.That(WrapMessage.Unwrap(WrapMessage.Unwrap(WrapMessage.Unwrap(WrapMessage.Unwrap(message)))), Is.EqualTo(WrapMessage.Unwrap(message)));
        }
    }
}

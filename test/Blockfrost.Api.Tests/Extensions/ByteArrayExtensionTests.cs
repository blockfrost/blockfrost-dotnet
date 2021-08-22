using Blockfrost.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Extensions
{
    [TestClass]
    [TestCategory(nameof(Blockfrost.Api))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Extensions))]
    public class ByteArrayExtensionTests
    {
        [TestMethod]
        public void LastBits_Returns_LastNBits()
        {
            byte b = 0x83;
            var last = b.LastBits(4);
            Assert.AreEqual(0x3, last);
        }
    }
}
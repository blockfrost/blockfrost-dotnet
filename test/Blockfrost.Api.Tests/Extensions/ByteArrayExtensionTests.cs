// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using Blockfrost.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Extensions
{
    [TestClass]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Extensions))]
    public class ByteArrayExtensionTests
    {
        [TestMethod]
        public void LastBits_Returns_LastNBits()
        {
            byte b = 0x83;
            int last = b.LastBits(4);
            Assert.AreEqual(0x3, last);
        }
    }
}

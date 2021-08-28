// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using Blockfrost.Cli.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Commands
{

    [TestClass]
    [TestCategory(nameof(Cli))]
    [TestCategory(nameof(Cli.Commands))]
    public class TestCommands
    {
        [TestMethod]
        public void TestMethod()
        {
            var command = new ShowVersionCommand();
            Assert.IsNotNull(command);
        }
    }
}

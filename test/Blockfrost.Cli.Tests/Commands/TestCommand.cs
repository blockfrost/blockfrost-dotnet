using System;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.Cli.Commands;

namespace Blockfrost.Cli.Tests.Commands
{

    [TestClass]
    [TestCategory(nameof(Blockfrost.Cli))]
    [TestCategory(nameof(Blockfrost.Cli.Commands))]
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
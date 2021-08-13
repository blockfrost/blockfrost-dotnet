using System;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockfrost.ConsoleTool.Commands;

namespace Blockfrost.Cli.Tests
{

    [TestClass]
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
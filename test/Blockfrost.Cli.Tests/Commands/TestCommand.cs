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

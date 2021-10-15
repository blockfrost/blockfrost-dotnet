using System.Threading.Tasks;
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
        public void ShowVersionCommand()
        {
            var command = new ShowVersionCommand();
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public async Task IpfsCommand_Execute()
        {
            var command = new Cli.Commands.Ipfs.IpfsCommand();
            Assert.IsNotNull(command);
            var result = await command.ExecuteAsync(System.Threading.CancellationToken.None);
            Assert.AreEqual(CommandOutcome.Success, result.Outcome);
        }
    }
}

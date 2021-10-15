using System.Threading.Tasks;
using Blockfrost.Cli.Commands;
using Blockfrost.Cli.Commands.Ipfs;
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
        public async Task IpfsCommand_Execute_Without_CID()
        {
            CommandParser.Network = "ipfs";
            var command = CommandParser.Parse(new[] { "ipfs", "pins" });
            Assert.IsNotNull(command);
            Assert.AreEqual(typeof(IpfsCommand), command.GetType());
            var result = await command.ExecuteAsync(System.Threading.CancellationToken.None);
            Assert.AreEqual(CommandOutcome.Success, result.Outcome);
        }

        [TestMethod]
        public async Task IpfsCommand_Execute_Pins_With_CID()
        {
            var command = CommandParser.Parse(new[] { "ipfs", "pins", "--cid", " " });
            Assert.IsNotNull(command);
            Assert.AreEqual(typeof(IpfsCommand), command.GetType());
            var result = await command.ExecuteAsync(System.Threading.CancellationToken.None);
            Assert.AreEqual(CommandOutcome.Success, result.Outcome);
        }
    }
}

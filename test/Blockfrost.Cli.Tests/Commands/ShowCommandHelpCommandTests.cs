using Blockfrost.Cli.Commands;
using Blockfrost.Cli.Commands.Cardano.Addresses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Commands
{
    [TestClass]
    [TestCategory(nameof(Cli))]
    [TestCategory(nameof(Cli.Commands))]
    public partial class ShowCommandHelpCommandTests
    {
        [TestMethod]
        public void AddressesCommandHelpCommandTest()
        {
            var command = new ShowCommandHelpCommand<AddressesCommand>();
            Assert.AreEqual("addresses", command.CommandName);
        }
    }
}

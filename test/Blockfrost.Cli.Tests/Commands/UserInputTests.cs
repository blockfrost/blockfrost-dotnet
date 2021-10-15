using Blockfrost.Cli.Commands;
using Blockfrost.Cli.Commands.Cardano.Accounts;
using Blockfrost.Cli.Commands.Cardano.Addresses;
using Blockfrost.Cli.Commands.Cardano.Assets;
using Blockfrost.Cli.Commands.Cardano.Blocks;
using Blockfrost.Cli.Commands.Cardano.Epochs;
using Blockfrost.Cli.Commands.Cardano.Ledger;
using Blockfrost.Cli.Commands.Cardano.Metadata;
using Blockfrost.Cli.Commands.Cardano.Network;
using Blockfrost.Cli.Commands.Cardano.Pools;
using Blockfrost.Cli.Commands.Cardano.Scripts;
using Blockfrost.Cli.Commands.Cardano.Transactions;
using Blockfrost.Cli.Commands.Ipfs;
using Blockfrost.Cli.Tests.Attributes.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Commands
{
    [TestClass]
    [TestCategory(nameof(Cli))]
    [TestCategory(nameof(Cli.Commands))]
    public partial class UserInputTests
    {
        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("accounts")]
        public void AccountsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<AccountsCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("addresses")]
        public void AddressesCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<AddressesCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("assets")]
        public void AssetsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<AssetsCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("blocks")]
        public void BlocksCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<BlocksCommand>), command.GetType());
        }

        [Ignore("The command has only value type parameters which are initialized with valid default values")]
        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("epochs")]
        public void EpochsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<EpochsCommand>), command.GetType());
        }

        [Ignore("The command has no parameters and will therefore ignore (missing) parameters")]
        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("ledger")]
        public void LedgerCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<LedgerCommand>), command.GetType());
        }

        //[Ignore("The command has no parameters and will therefore ignore (missing) parameters")]
        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("metadata")]
        public void MetadataCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<MetadataCommand>), command.GetType());
        }

        [Ignore("The command has no parameters and will therefore ignore (missing) parameters")]
        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("network")]
        public void NetworkCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<NetworkCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("pools")]
        public void PoolsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<PoolsCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("scripts")]
        public void ScriptsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<ScriptsCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Cardano))]
        [UserInput("transactions")]
        public void TransactionsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<TransactionsCommand>), command.GetType());
        }

        [TestMethod]
        [TestCategory(nameof(Cli.Commands.Ipfs))]
        [UserInput("ipfs")]
        public void IpfsCommand_Invalid(string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(typeof(ShowCommandHelpCommand<IpfsCommand>), command.GetType());
        }
    }
}

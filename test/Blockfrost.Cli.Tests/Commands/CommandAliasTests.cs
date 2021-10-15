using System;
using Blockfrost.Cli.Commands;
using Blockfrost.Cli.Commands.Cardano.Accounts;
using Blockfrost.Cli.Commands.Cardano.Addresses;
using Blockfrost.Cli.Commands.Cardano.Blocks;
using Blockfrost.Cli.Commands.Cardano.Transactions;
using Blockfrost.Cli.Tests.Attributes.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Commands
{
    [TestClass]
    [TestCategory(nameof(Cli))]
    [TestCategory(nameof(Cli.Commands))]
    public partial class CommandAliasTests
    {
        [CommandTestMethod(typeof(AddressesCommand))]
        [UserInput("addr {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        [UserInput("address {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        [UserInput("addresses {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        public void AddressesCommand_Aliases(Type expected, string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(expected, command.GetType());
        }

        [CommandTestMethod(typeof(AccountsCommand))]
        [UserInput("acct {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        [UserInput("accts {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        [UserInput("account {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        [UserInput("accounts {0}", "addr_test1vpf8knz7v9yaz35hjcxhuzu6fh5fgr3mpk7waufk0dcv6ygvetsnm")]
        public void AccountsCommand_Aliases(Type expected, string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(expected, command.GetType());
        }

        [CommandTestMethod(typeof(BlocksCommand))]
        [UserInput("blk {0}", "76b3927a3547178fc8dc63f5bba5c580b47c349f2c74eb778b00142ed63904ca")]
        [UserInput("block {0}", "76b3927a3547178fc8dc63f5bba5c580b47c349f2c74eb778b00142ed63904ca")]
        [UserInput("blocks {0}", "76b3927a3547178fc8dc63f5bba5c580b47c349f2c74eb778b00142ed63904ca")]
        public void BlocksCommand_Aliases(Type expected, string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(expected, command.GetType());
        }

        private const string TransactionHash = "5f29ad730c29c202a61d7e7970ad6faa15d88fb5b6dfd219140dcd36ca1a08b8";
        [CommandTestMethod(typeof(TransactionsCommand))]
        [UserInput("tx {0}", TransactionHash)]
        [UserInput("txs {0}", TransactionHash)]
        [UserInput("txn {0}", TransactionHash)]
        [UserInput("txns {0}", TransactionHash)]
        [UserInput("trx {0}", TransactionHash)]
        [UserInput("trxs {0}", TransactionHash)]
        [UserInput("trxn {0}", TransactionHash)]
        [UserInput("trxns {0}", TransactionHash)]
        [UserInput("transactions {0}", TransactionHash)]
        public void TransactionsCommand_Aliases(Type expected, string[] args)
        {
            var command = CommandParser.Parse(args);
            Assert.AreEqual(expected, command.GetType());
        }
    }
}

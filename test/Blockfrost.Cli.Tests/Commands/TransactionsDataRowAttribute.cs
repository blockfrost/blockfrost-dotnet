using Blockfrost.Cli.Commands.Cardano.Addresses;
using Blockfrost.Cli.Commands.Cardano.Blocks;
using Blockfrost.Cli.Commands.Cardano.Transactions;
using Blockfrost.Cli.Commands.Common.Health;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Commands
{

    internal class AddressesDataRowAttribute : DataRowAttribute
    {
        public AddressesDataRowAttribute(params string[] args) : base(typeof(AddressesCommand), args)
        {
        }
    }

    internal class BlocksDataRowAttribute : DataRowAttribute
    {
        public BlocksDataRowAttribute(params string[] args) : base(typeof(BlocksCommand), args)
        {
        }
    }

    internal class HealthDataRowAttribute : DataRowAttribute
    {
        public HealthDataRowAttribute(params string[] args) : base(typeof(HealthCommand), args)
        {
        }
    }

    internal class TransactionsDataRowAttribute : DataRowAttribute
    {

        public TransactionsDataRowAttribute(string input) : base(typeof(TransactionsCommand), input.Split(" "))
        {
        }
    }
}

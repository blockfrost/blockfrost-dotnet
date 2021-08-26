using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using CardanoSharp.Wallet.Extensions;
using CardanoSharp.Wallet.Extensions.Models.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Blockfrost.Extensions.CardanoSharp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            
            IServiceCollection services = new ServiceCollection()
                .AddBlockfrost("Blockfrost.Net.Sdk-testnet")
                .AddCardanoSharp();

            var provider = services.BuildServiceProvider();

            var css = provider.GetRequiredService<ICardanoSharpService>();
            var bft = provider.GetRequiredService<ITransactionService>();

            var tx = await css.BuildTransaction();
            var cborHex = tx.Serialize().ToStringHex();
            Console.WriteLine(cborHex);
        }
    }
}

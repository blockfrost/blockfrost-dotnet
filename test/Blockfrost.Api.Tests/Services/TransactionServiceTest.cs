using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public class TransactionServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET);
        }

        [TestMethod]
        public void TestSubmitAsyncExists()
        {
            var service = Provider.GetRequiredService<ITransactionService>();
            Assert.IsNotNull(nameof(service.SubmitAsync));
        }
    }

}

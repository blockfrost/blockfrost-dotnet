using System.Collections.Generic;
using System.Threading.Tasks;
using Blockfrost.Api.Tests.Attributes;
using Blockfrost.Api.Migrate.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public class UtxosAllTests : AddressServiceMethodTestBase<ICollection<AddressUTxOResponse>>
    {
        public UtxosAllTests() : base(nameof(IAddressService.UtxosAllAsync)) { }

        public override ICollection<AddressUTxOResponse> Content => new List<AddressUTxOResponse>() { new AddressUTxOResponse() };

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET, context);
        }

        [TestMethod]
        public override void Validate_Service_Method() => AssertMethodExists();

        // TODO: [PermutePaginationTestMethod(1,-1,0,1,typeof(ESortOrder))]
        [PaginationTestMethod(-1, -1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(-1, 0, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(-1, 1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(0, -1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(0, 0, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(0, 1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(1, -1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(1, 0, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(1, 1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(-1, -1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(-1, 0, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(-1, 1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(0, -1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(0, 0, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(0, 1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(1, -1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(1, 0, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(1, 1, ESortOrder.Desc, expected: 1)]
        public async Task PaginationTests(int count, int page, ESortOrder order, int expected)
        {

            string addr = "addr_test1vrgvgwfx4xyu3r2sf8nphh4l92y84jsslg5yhyr8xul29rczf3alu";

            // Act
            var utxos = await ServiceUnderTest.UtxosAllAsync(addr, count, page, order);

            // Assert
            Assert.AreEqual(expected, utxos.Count);
        }
    }
}

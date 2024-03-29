﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Blockfrost.Api.Models;
using Blockfrost.Api.Services;
using Blockfrost.Api.Tests.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    [TestCategory(nameof(Api))]
    [TestCategory(nameof(Services))]
    public class UtxosAllTests : AddressServiceMethodTestBase<AddressUtxoContentResponseCollection>
    {
        public UtxosAllTests() : base(nameof(IAddressesService.GetUtxosAsync)) { }

        public override ICollection<Api.Models.AddressUtxoContentResponse> Content => new List<Api.Models.AddressUtxoContentResponse>() { new Api.Models.AddressUtxoContentResponse() };

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
            var utxos = await ServiceUnderTest.GetUtxosAsync(addr, count, page, order);

            // Assert
            Assert.AreEqual(expected, utxos.Count);
        }
    }
}

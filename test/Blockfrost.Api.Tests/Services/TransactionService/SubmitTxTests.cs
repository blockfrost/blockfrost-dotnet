using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CardanoSharp.Wallet.Extensions;
using Blockfrost.Api.Tests.Attributes;
using System.Net;

namespace Blockfrost.Api.Tests.Services
{

    [TestClass]
    public class SubmitTxTests : AServiceMethodTestBase<ITransactionService, string>
    {
        public SubmitTxTests() : base(nameof(ITransactionService.SubmitAsync), HttpStatusCode.Accepted)
        {
        }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET);
        }

        public override string Content => TestVector.DummyHash;

        [TestMethod]
        public override void Validate_Service_Method()
        {
            AssertMethodExists();
        }

        /// <summary>
        /// Tracker https://github.com/blockfrost/blockfrost-dotnet/issues/36 
        /// </summary>
        /// <param name="vectorId"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED_RAW)]
        public async Task SubmitAsync_Bytes(byte[] bytes)
        {
            // Arrange
            using var stream = new MemoryStream(bytes);
            var cbroHex = bytes.ToStringHex();

            // Act
            var txId = await ServiceUnderTest.SubmitAsync(bytes);

            // Assert
            Assert.AreEqual(TestVector.DummyHash, txId);
        }

        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED)]
        public async Task SubmitAsync_Cbor_Hex(string content)
        {
            // Arrange
            ((TransactionService)ServiceUnderTest).ReadResponseAsString = true;

            // Act
            var txId = await ServiceUnderTest.SubmitAsync(content);

            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED_RAW)]
        public async Task SubmitAsync_Cbor_Raw(byte[] cborRaw)
        {
            // Act
            var txId = await ServiceUnderTest.SubmitAsync(cborRaw);
            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        [VectorTestMethod(TestVector.V01, TestVector.TX_DRAFT_RAW)]
        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED_RAW)]
        public void ReadCBORRaw(TestVector vector, string filename)
        {
#if NET
            var cborHex = vector.GetFileBytes(filename);

            // Arrange
            var reader = new System.Formats.Cbor.CborReader(cborHex, System.Formats.Cbor.CborConformanceMode.Strict, false);

            // Act
            var arrLength = reader.ReadStartArray();
            var mapLength = reader.ReadStartMap();

            // Assert
            Assert.AreEqual(arrLength, mapLength);
            for (uint i = 0; i < arrLength; i++)
            {
                var value = reader.ReadUInt32();
                Assert.AreEqual(i, value);

                if (i != 2)
                {
                    // we will not validate the individual values
                    reader.SkipValue();
                }
                else
                {
                    // except for the transaction fee... we can validate that
                    var fee = reader.ReadUInt32();
                    Assert.IsTrue(fee >= vector.CalculateMinFee(cborHex));
                }
            }
#else
            Assert.Fail("Not supported on the current framework");
#endif
        }
    }
}

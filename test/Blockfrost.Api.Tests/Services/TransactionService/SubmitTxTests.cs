// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Blockfrost.Api.Tests.Attributes;
using CardanoSharp.Wallet.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{

    [TestClass]
    public class SubmitTxTests : AServiceMethodTestBase<ITransactionService, string>
    {
        public SubmitTxTests() : base(nameof(ITransactionService.SubmitAsync), HttpStatusCode.Accepted)
        {
        }

        [ClassInitialize]
        [System.Obsolete]
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
            string cbroHex = bytes.ToStringHex();

            // Act
            string txId = await ServiceUnderTest.SubmitAsync(bytes);

            // Assert
            Assert.AreEqual(TestVector.DummyHash, txId);
        }

        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED)]
        public async Task SubmitAsync_Cbor_Hex(string content)
        {
            // Arrange
            ((TransactionService)ServiceUnderTest).ReadResponseAsString = true;

            // Act
            string txId = await ServiceUnderTest.SubmitAsync(content);

            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED_RAW)]
        public async Task SubmitAsync_Cbor_Raw(byte[] cborRaw)
        {
            // Act
            string txId = await ServiceUnderTest.SubmitAsync(cborRaw);
            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        [VectorTestMethod(TestVector.V01, TestVector.TX_DRAFT_RAW)]
        [VectorTestMethod(TestVector.V01, TestVector.TX_SIGNED_RAW)]
        public void ReadCBORRaw(TestVector vector, string filename)
        {
#if NET
            byte[] cborHex = vector.GetFileBytes(filename);

            // Arrange
            var reader = new System.Formats.Cbor.CborReader(cborHex, System.Formats.Cbor.CborConformanceMode.Strict, false);

            // Act
            int? arrLength = reader.ReadStartArray();
            int? mapLength = reader.ReadStartMap();

            // Assert
            Assert.AreEqual(arrLength, mapLength);
            for (uint i = 0; i < arrLength; i++)
            {
                uint value = reader.ReadUInt32();
                Assert.AreEqual(i, value);

                if (i != 2)
                {
                    // we will not validate the individual values
                    reader.SkipValue();
                }
                else
                {
                    // except for the transaction fee... we can validate that
                    uint fee = reader.ReadUInt32();
                    Assert.IsTrue(fee >= vector.CalculateMinFee(cborHex));
                }
            }
#else
            Assert.Fail("Not supported on the current framework");
#endif
        }
    }
}

using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CardanoSharp.Wallet.Extensions;
using CardanoSharp.Wallet.Models.Transactions;
using CardanoSharp.Wallet.Models.Keys;
using CardanoSharp.Wallet.Extensions.Models;
using CardanoSharp.Wallet.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Tests.Attributes;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public class UtxosAllTests : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET);
        }

        [TestMethod]
        public void UtxosAsync_Exists()
        {
            var service = Provider.GetRequiredService<IAddressService>();
            Assert.IsNotNull(nameof(service.UtxosAllAsync));
        }

        // TODO: [PermutePaginationTestMethod(1,-1,0,1,typeof(ESortOrder))]
        [PaginationTestMethod(-1,-1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(-1, 0, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(-1, 1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(0, -1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(0,  0, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(0,  1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(1, -1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(1,  0, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(1,  1, ESortOrder.Asc, expected: 1)]
        [PaginationTestMethod(-1,-1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(-1, 0, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(-1, 1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(0, -1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(0,  0, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(0,  1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(1, -1, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(1,  0, ESortOrder.Desc, expected: 1)]
        [PaginationTestMethod(1,  1, ESortOrder.Desc, expected: 1)]
        public async Task PaginationTests(int count, int page, ESortOrder order, int expected)
        {
            var addressService = Provider.GetRequiredService<IAddressService>();
            var addr = "addr_test1vrgvgwfx4xyu3r2sf8nphh4l92y84jsslg5yhyr8xul29rczf3alu";

            // Act
            var utxos = await addressService.UtxosAllAsync(addr, count, page, order);

            // Assert
            Assert.AreEqual(expected, utxos.Count);
        }
    }

    [TestClass]
    public class SubmitTxTests : AServiceTestBase
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

        /// <summary>
        /// Tracker https://github.com/blockfrost/blockfrost-dotnet/issues/36 
        /// </summary>
        /// <param name="vectorId"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        //[DataRow("01", "tx.draft")]
        //[DataRow("01", "tx.cddl")]  
        [VectorTestMethod("01", "tx.signed.raw")]
        public async Task TestSubmitAsyncStream(byte[] bytes)
        {
            // Arrange
            var transactionService = Provider.GetRequiredService<ITransactionService>();
            using var stream = new MemoryStream(bytes);

            // Act
            var txId = await transactionService.SubmitAsync(stream);

            // Assert
            Assert.AreEqual(Blake2Fast.Blake2b.ComputeHash(32, bytes), txId);
        }

        [VectorTestMethod("01", "tx.signed")]
        [VectorTestMethod("02", "tx.signed")]
        public async Task TestSubmitCborHexAsyncString(string content)
        {
            // Arrange
            var transactionService = Provider.GetRequiredService<ITransactionService>();
            ((TransactionService)transactionService).ReadResponseAsString = true;

            // Act
            var txId = await transactionService.SubmitAsync(content);

            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        [VectorTestMethod("01", "tx.signed.raw")]
        public async Task TestSubmitCborAsyncString(TestVector v, string filename)
        {
            // Arrange
            var transactionService = Provider.GetRequiredService<ITransactionService>();
            // Act
            var txId = await transactionService.SubmitAsync("");
            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        class CardanoCliTransaction
        {
            [JsonPropertyName("type")]
            string Type { get; set; }

            [JsonPropertyName("description")]
            string Description { get; set; }

            [JsonPropertyName("cborHex")]
            string CBORHex { get; set; }
        }

        [VectorTestMethod("01", "tx.signed.raw")]
        public async Task TestSubmitCardanoCliTransactionAsyncString(string vectorId, string filename)
        {
            // Arrange
            string json = TestVector.Load(vectorId).GetFileText(filename);

            var transactionService = Provider.GetRequiredService<ITransactionService>();

            // Act
            var txId = await transactionService.SubmitAsync(json);

            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        private static string GetSampleTestVectorById(string vectorId, string filename)
        {
            
            var obj = new
            {
                type = "TxBodyMary",
                description = "",
                cborHex = "83a3008182582098035740ab68cad12cb4d8281d10ce1112ef0933dc84920b8937c3e80d78d12000018282581d60d0c43926a989c88d5049e61bdebf2a887aca10fa284b9067373ea28f0082581d603b75186909c120a97f6f0ee6822701f075e5136f3b9a08604a63dce700020080f6"
            };
            var json = JsonSerializer.Serialize(obj);
            var tx = JsonSerializer.Deserialize<CardanoCliTransaction>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            json = JsonSerializer.Serialize(tx);
            return json;
        }

        /// <summary>
        /// This MUST construct a transaction defined in one of the test vectors
        /// </summary>
        /// <returns></returns>
        private static Transaction CreateTransactionFromTestVector(string vectorId)
        {
            Assert.IsNotNull(vectorId, "This MUST construct a transaction defined in one of the test vectors");
            var testVector = TestVector.Load(vectorId);

            // I'll leave this here for now... 

            var scwKeyService = new CardanoSharp.Wallet.KeyService();
            var cswAddressService = new CardanoSharp.Wallet.AddressService();
            int size = 24;

            Mnemonic mnemonic = scwKeyService.Generate(size, WordLists.English);
            PrivateKey masterKey = mnemonic.GetRootKey();

            string paymentPath = $"m/1852'/1815'/0'/0/0";
            PrivateKey paymentPrv = masterKey.Derive(paymentPath);
            PublicKey paymentPub = paymentPrv.GetPublicKey(false);

            string stakePath = $"m/1852'/1815'/0'/2/0";
            var stakePrv = masterKey.Derive(stakePath);
            var stakePub = stakePrv.GetPublicKey(false);

            var addr = cswAddressService.GetAddress(paymentPub, stakePub, NetworkType.Testnet, AddressType.Base);
            
            return new Transaction()
            {
                TransactionBody = new TransactionBody()
                {
                    TransactionInputs = new List<TransactionInput>()
                {
                    new TransactionInput()
                    {
                        TransactionIndex = 0,
                        TransactionId = new byte[32]
                    }
                },
                    TransactionOutputs = new List<TransactionOutput>()
                {
                    new TransactionOutput()
                    {
                        Address = addr.GetBytes(),
                        Value = new TransactionOutputValue()
                        {
                            Coin = 1
                        }
                    }
                },
                    Ttl = 10,
                    Fee = 0
                },
                TransactionWitnessSet = new TransactionWitnessSet()
                {
                    VKeyWitnesses = new List<VKeyWitness>()
                {
                    new VKeyWitness()
                    {
                        VKey = paymentPub,
                        SKey = paymentPrv
                    }
                }
                }
            };
        }
    }
}

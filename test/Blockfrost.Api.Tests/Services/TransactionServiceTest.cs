using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using System.Security.Cryptography;

using CardanoSharp.Wallet.Extensions;
using CardanoSharp.Wallet.Models.Transactions;
using CardanoSharp.Wallet.Extensions.Models.Transactions;
using CardanoSharp.Wallet.Models.Keys;
using CardanoSharp.Wallet.Extensions.Models;
using CardanoSharp.Wallet.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        [TestMethod]
        public async Task TestSubmitAsyncStream()
        {
            // Arrange
            var transactionService = Provider.GetRequiredService<ITransactionService>();

            var file = "/path/to/test/vector/with/cborHex/for/testing";
            var signedTxSerialized = File.ReadAllBytes(file);

            var hex = signedTxSerialized.ToStringHex();
            var raw = ByteArrayExtensions.HexToByteArray(hex);

            // Act
            using MemoryStream stream = new MemoryStream(raw);
            var txId = await transactionService.SubmitAsync(stream);

            // Assert
            Assert.AreEqual(SHA256.HashData(raw).ToStringHex().Length, txId.Length);
        }

        [TestMethod]
        public async Task TestSubmitCborHexAsyncString()
        {
            // Arrange
            var transactionService = Provider.GetRequiredService<ITransactionService>();
            // Act
            var txId = await transactionService.SubmitAsync("");
            // Assert
            Assert.AreEqual(SHA256.HashData(new byte[] { 0x00 }).ToStringHex().Length, txId.Length);
        }

        [TestMethod]
        public async Task TestSubmitCborAsyncString()
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

        [TestMethod]
        public async Task TestSubmitCardanoCliTransactionAsyncString()
        {
            // Arrange
            string json = TestVector.Load("01").GetFileText("tx.draft");

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

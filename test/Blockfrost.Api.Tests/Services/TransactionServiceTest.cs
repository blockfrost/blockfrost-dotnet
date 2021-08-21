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
            var raw = hex.HexToByteArray();

            // Act
            using MemoryStream stream = new MemoryStream(raw);
            var txId = await transactionService.SubmitAsync(stream);

            // Assert
            Assert.AreEqual(SHA256.HashData(raw).ToStringHex().Length, txId.Length);
        }

        [TestMethod]
        public async Task TestSubmitAsyncString()
        {
            Assert.Fail();
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

namespace Blockfrost.Api.Tests
{
    class TestVector
    {
        internal static TestVector Load(string vectorId)
        {
            throw new System.NotImplementedException();
        }
    }
}
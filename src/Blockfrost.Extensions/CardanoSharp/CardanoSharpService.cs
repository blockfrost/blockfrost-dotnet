using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BF = Blockfrost.Api;
using BFO = Blockfrost.Api.Options;
using CST = CardanoSharp.Wallet.Models.Transactions;
using CSA = CardanoSharp.Wallet.Models.Addresses;
using CSTB = CardanoSharp.Wallet.TransactionBuilding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Blockfrost.Extensions.CardanoSharp.Utils;
using CardanoSharp.Wallet.Extensions;

namespace Blockfrost.Extensions.CardanoSharp
{
    public interface ICardanoSharpService
    {
        Task<CST.Transaction> BuildTransaction();
    }

    public class CardanoSharpService : ICardanoSharpService
    {
        private BFO.BlockfrostOptions _project;
        private readonly BF.IAddressService _blockfrostAddressService;
        private readonly IConfiguration _config;
        private readonly IOptions<BFO.BlockfrostOptions> _blockfrostOptions;
        private readonly IOptionsMonitor<CardanoSharpExtensionOptions> _optionsMonitor;

        public CardanoSharpExtensionOptions Options => _optionsMonitor.CurrentValue;

        public CardanoSharpService(
            BF.IAddressService addressService,
            IConfiguration config,
            IOptions<BFO.BlockfrostOptions> blockfrostOptions,
            IOptionsMonitor<CardanoSharpExtensionOptions> optionsMonitor)
        {
            _blockfrostAddressService = addressService;
            _config = config;
            _blockfrostOptions = blockfrostOptions;
            _optionsMonitor = optionsMonitor;
        }

        public async Task<CST.Transaction> BuildTransaction()
        {
            uint fee = Options.Fee;
            uint amount = Options.Amount;
            var pay = new CSA.Address(Options.Sender);
            var rcv = new CSA.Address(Options.Receiver);
            var utxos = await _blockfrostAddressService.AddressUtxoAsync(Options.Sender, Options.UtxoSpendLimit, 0, BF.ESortOrder.Desc, CancellationToken.None);

            if (amount > Options.SpendingLimit)
            {
                throw new InvalidOperationException("Increase spending limit");
            }

            if (utxos.SumAmounts(Options.Unit) < amount && Options.UtxoSpendLimit > utxos.Count())
            {
                throw new InvalidOperationException("Not enough lovelace");
            }

            uint change = 0;
            uint index = 0;
            var txbody = CSTB.TransactionBodyBuilder.Create;

            foreach (var utxo in utxos)
            {
                change += utxo.ToUint32(Options.Unit);
                txbody = txbody.AddInput(utxo.Tx_hash.HexToByteArray(), index++);
                if ((change - fee) >= amount) break;
            }

            change -= (amount + fee);

            var tx = CSTB.TransactionBuilder.Create.SetBody(txbody
                .AddOutput(pay.GetBytes(), change)
                .AddOutput(rcv.GetBytes(), amount)
                .SetFee(fee)).Build();

            return tx;
        }
    }
}

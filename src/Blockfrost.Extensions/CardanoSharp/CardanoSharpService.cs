using BFApi = Blockfrost.Api;
using BFOpt = Blockfrost.Api.Options;
using BFUtils = Blockfrost.Extensions.CardanoSharp.Utils;
using CSTxs = CardanoSharp.Wallet.Models.Transactions;
using CSAddr = CardanoSharp.Wallet.Models.Addresses;

using CardanoSharp.Wallet.TransactionBuilding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardanoSharp.Wallet.Extensions;
using Blockfrost.Extensions.CardanoSharp.Utils;

namespace Blockfrost.Extensions.CardanoSharp
{
    public interface ICardanoSharpService
    {
        Task<CSTxs.Transaction> BuildTransaction();
    }

    public class CardanoSharpService : ICardanoSharpService
    {
        private BFOpt.BlockfrostOptions _project;
        private readonly BFApi.IAddressService _blockfrostAddressService;
        private readonly IConfiguration _config;
        private readonly IOptions<BFOpt.BlockfrostOptions> _blockfrostOptions;
        private readonly IOptionsMonitor<CardanoSharpExtensionOptions> _optionsMonitor;

        public CardanoSharpExtensionOptions Options => _optionsMonitor.CurrentValue;

        public CardanoSharpService(
            BFApi.IAddressService addressService,
            IConfiguration config,
            IOptions<BFOpt.BlockfrostOptions> blockfrostOptions,
            IOptionsMonitor<CardanoSharpExtensionOptions> optionsMonitor)
        {
            _blockfrostAddressService = addressService;
            _config = config;
            _blockfrostOptions = blockfrostOptions;
            _optionsMonitor = optionsMonitor;
        }

        public async Task<CSTxs.Transaction> BuildTransaction()
        {
            uint fee = Options.Fee;
            uint amount = Options.Amount;
            var pay = new CSAddr.Address(Options.Sender);
            var rcv = new CSAddr.Address(Options.Receiver);
            var utxos = await _blockfrostAddressService.AddressUtxoAsync(Options.Sender, Options.UtxoSpendLimit, 0, BFApi.ESortOrder.Desc, CancellationToken.None);

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
            var txbody = TransactionBodyBuilder.Create;

            foreach (var utxo in utxos)
            {
                change += utxo.ToUint32(Options.Unit);
                txbody = txbody.AddInput(utxo.Tx_hash.HexToByteArray(), index++);
                if ((change - fee) >= amount) break;
            }

            change -= (amount + fee);

            var tx = TransactionBuilder.Create.SetBody(txbody
                .AddOutput(pay.GetBytes(), change)
                .AddOutput(rcv.GetBytes(), amount)
                .SetFee(fee)).Build();

            return tx;
        }
    }
}

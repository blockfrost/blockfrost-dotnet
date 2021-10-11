using System;
using System.Threading;
using System.Threading.Tasks;
using BF = Blockfrost.Api;
using CST = CardanoSharp.Wallet.Models.Transactions;
using CSA = CardanoSharp.Wallet.Models.Addresses;
using CSTB = CardanoSharp.Wallet.TransactionBuilding;
using Microsoft.Extensions.Options;
using Blockfrost.Extensions.CardanoSharp.Utils;
using CardanoSharp.Wallet.Extensions;
using Blockfrost.Api.Services;

namespace Blockfrost.Extensions.CardanoSharp
{
    public interface ICardanoSharpService
    {
        Task<CST.Transaction> BuildTransaction();
    }

    public class CardanoSharpService : ICardanoSharpService
    {
        private readonly IAddressesService _blockfrostAddressService;
        private readonly IOptionsMonitor<CardanoSharpExtensionOptions> _optionsMonitor;

        public CardanoSharpExtensionOptions Options => _optionsMonitor.CurrentValue;

        public CardanoSharpService(
            IAddressesService addressService,
            IOptionsMonitor<CardanoSharpExtensionOptions> optionsMonitor)
        {
            _blockfrostAddressService = addressService;
            _optionsMonitor = optionsMonitor;
        }

        public async Task<CST.Transaction> BuildTransaction()
        {
            uint fee = Options.Fee;
            uint amount = Options.Amount;
            var pay = new CSA.Address(Options.Sender);
            var rcv = new CSA.Address(Options.Receiver);
            var utxos = await _blockfrostAddressService.GetUtxosAsync(Options.Sender, Options.UtxoSpendLimit, 0, BF.ESortOrder.Desc, CancellationToken.None);

            if (amount > Options.SpendingLimit)
            {
                throw new InvalidOperationException("Increase spending limit");
            }

            if (utxos.SumAmounts(Options.Unit) < amount && Options.UtxoSpendLimit > utxos.Count)
            {
                throw new InvalidOperationException("Not enough lovelace");
            }

            uint change = 0;
            uint index = 0;
            var txbody = CSTB.TransactionBodyBuilder.Create;

            foreach (var utxo in utxos)
            {
                change += utxo.ToUint32(Options.Unit);
                txbody = txbody.AddInput(utxo.TxHash.HexToByteArray(), index++);
                if ((change - fee) >= amount)
                {
                    break;
                }
            }

            change -= amount + fee;

            var tx = CSTB.TransactionBuilder.Create.SetBody(txbody
                .AddOutput(pay.GetBytes(), change)
                .AddOutput(rcv.GetBytes(), amount)
                .SetFee(fee)).Build();

            return tx;
        }
    }
}

using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;
using Blockfrost.Api.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;

ICardanoService cardano = new ServiceCollection()
    .AddBlockfrost("testnet", "kL2vAF27FpfuzrnhSofc1JawdlL0BNkh")
    .BuildServiceProvider()
    .GetRequiredService<ICardanoService>();

// get hash of latest block
//string hash = (await cardano.Blocks.GetLatestAsync()).Hash;
string hash = "6325dc90573acc37397aeb4c685989fea33cc9b522dc2abb392f945997a303f1"; // https://explorer.cardano-testnet.iohkdev.io/en/block?id=6325dc90573acc37397aeb4c685989fea33cc9b522dc2abb392f945997a303f1

// load the txs from latest block
var transactions = await cardano.Blocks.GetTxsAsync(hash);

// get all the utxos
var txsUtxoCollection = await cardano.Transactions.GetUtxosAsync(transactions);

// print them all
var opt = new System.Text.Json.JsonSerializerOptions() { WriteIndented = true };
foreach (var txUtxos in txsUtxoCollection)
{
    System.Console.Write(txUtxos.ToJson(opt));
}

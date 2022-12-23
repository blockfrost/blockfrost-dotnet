using System.IO;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Models.Extensions;
using Blockfrost.Api.Services;
using Blockfrost.Api.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;

/*
 * Parameters
 */
string apiKey = "YOUR_BLOCKFROST_PROJECT_ID";
string network = "NETWORK_OF_THE_PROJECT_ID";
string sender_address = "SENDER_ADDR";
string receiver_address = "RECEIVER_ADDR";
string signedTx = File.ReadAllText("path/to/your/signed/transaction");

/*
 * Init Services using apiKey and network
 */
var cardano = new ServiceCollection()
    .AddBlockfrost(network, apiKey)
    .BuildServiceProvider()
    .GetRequiredService<ICardanoService>();

/*
 * Show metrics for your account
 */
var metrics = await cardano.Metrics.GetMetricsAsync();
var opt = new System.Text.Json.JsonSerializerOptions() { WriteIndented = true };
System.Console.WriteLine($"Metrics: {metrics.ToJson(opt)}");

/*
 * Show sender UTxO
 */
var utxoSender = await cardano.Addresses.GetUtxosAsync(sender_address);
long totalSender = utxoSender.SumAmounts("lovelace");
System.Console.WriteLine($"Sender Total: {totalSender} lovelace");

/*
 * Sum receiver UTxO
 */
var utxoReceiver = await cardano.Addresses.GetUtxosAsync(receiver_address);
long totalReceiver = utxoReceiver.SumAmounts("lovelace");
System.Console.WriteLine($"Receiver Total: {totalReceiver} lovelace");

/*
 * Query tip
 */
var tip = await cardano.Blocks.GetLatestAsync();
long? latestSlot = tip.Slot;

System.Console.WriteLine($"Tip now at Epoch {tip.Epoch} Slot {tip.Slot} Block {tip.Height}");

/*
 * Send submit tx
 */
System.Console.WriteLine(signedTx);
string txid = await cardano.Transactions.PostTxSubmitAsync(signedTx);

System.Console.WriteLine($"Your Transaction was transmitted to the {network}");
System.Console.WriteLine($"https://explorer.cardano-{network}.iohkdev.io/en/transaction?id={txid}");

/*
 * Wait two blocks
 */
tip = await cardano.Blocks.WaitAsync(
    count: 2,
    interval: System.TimeSpan.FromSeconds(5),
    callback: latest => System.Console.WriteLine(latest.Slot),
    cancellationToken: System.Threading.CancellationToken.None
);
System.Console.WriteLine($"Tip now at Epoch {tip.Epoch} Slot {tip.Slot} Block {tip.Height}");

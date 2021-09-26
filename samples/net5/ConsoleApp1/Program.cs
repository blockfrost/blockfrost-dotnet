using System.IO;
using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Models.Extensions;
using Blockfrost.Api.Services;
using Blockfrost.Api.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

/*
 * Parameters
 */
string apiKey = "YOUR_BLOCKFROST_PROJECT_ID";
string network = "NETWORK_OF_THE_PROJECT_ID";
string sender_address = "SENDER_ADDR";
string receiver_address = "RECEIVER_ADDR";
string signedTx = File.ReadAllText("path/to/your/signed/transaction");

/*
 * Init Services
 */
var provider = new ServiceCollection().AddBlockfrost(network, apiKey).BuildServiceProvider();
var cardano = provider.GetRequiredService<ICardanoService>();

/*
 * Show sender UTxO
 */
var utxoSender = await cardano.Addresses.GetUtxosAsync(sender_address, 100, 0, ESortOrder.Asc);
long totalSender = utxoSender.SumAmounts("lovelace");
System.Console.WriteLine($"Sender Total: {totalSender} lovelace");

/*
 * Sum receiver UTxO
 */
var utxoReceiver = await cardano.Addresses.GetUtxosAsync(receiver_address, 100, 0, ESortOrder.Asc);
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
tip = await cardano.Blocks.Wait(
    count: 2,
    queryInterval: System.TimeSpan.FromSeconds(3),
    inspectLatest: latest => System.Console.WriteLine($"Tip: {tip.Slot}"),
    cancellationToken: CancellationToken.None
);
System.Console.WriteLine($"Tip now at Epoch {tip.Epoch} Slot {tip.Slot} Block {tip.Height}");

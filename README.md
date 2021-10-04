[![.NET](https://github.com/blockfrost/blockfrost-dotnet/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/blockfrost/blockfrost-dotnet/actions/workflows/dotnet.yml)
<br/>

<img src="https://blockfrost.io/images/logo.svg" width="250" align="right" height="90">

# blockfrost-dotnet

<br/>

<p align="center">.NET SDK for Blockfrost.io API.</p>
<p align="center">
  <a href="#getting-started">Getting started</a> •
  <a href="#installation">Installation</a> •
  <a href="#usage">Usage</a>
</p>
<br>

### Migration to v1

*The current release of blockfrost-dotnet introduced major API changes breaking existing implementations.*

*See the [migration guide](https://github.com/blockfrost/blockfrost-dotnet/wiki/Migration-Guide) to resolve these issues.*

## Getting started

To use this SDK, first go to [blockfrost.io](https://blockfrost.io) and create your project to retrive your API token.

<img src="https://i.imgur.com/smY12ro.png">

<br/>

### Configure environment variables (optional)

`blocfrost-dotnet` supports two environment variables.

```ps
$> $env:BFCLI_NETWORK
testnet

$> $env:BFCLI_API_KEY
yourawesomeapikeyforblockfrostio
```

> Make sure you have configured them if you add `blockfrost-dotnet` using `services.AddBlockfrost();`
>
> There are other extension methods to configure `blockfrost-dotnet` where the environment variables are not required. We will look at one of them in the sample below.

### Setup

The SDK is hosted on [nuget.org](https://www.nuget.org/packages/Blockfrost.Api/latest), so you can directly import it using your favorite package manager.

```sh
$> dotnet new console -n blockfrost-client
$> cd blockfrost-client
$> dotnet add package Blockfrost.Api --version 0.3.0
$> dotnet add package Blockfrost.Extensions --version 0.3.0
```

🚧🚧🚧 ***Please report any issues you find [here](https://github.com/blockfrost/blockfrost-dotnet/issues/new)*** 👍

### Usage

Using the SDK is pretty straight-forward as you can see from the following example.

#### Cardano Services

```cs
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
```

### Run the sample

```sh
$ dotnet run
Metrics: [
  {
    "time": 1631750400,
    "calls": 3
  },
  ...
]
Sender Total: 988258310 lovelace
Receiver Total: 10000000 lovelace
Tip now at Epoch 160 Slot 38978334 Block 2965005

Your Transaction was transmitted to the testnet
https://explorer.cardano-testnet.iohkdev.io/en/transaction?id=2b1ca81b94c5dd737fe939444264046c6fbbe96ff403e49ee99e8022b0e512bb
Tip: 38978334
Tip: 38978334
Tip: 38978334
Tip: 38978334
Tip: 38978334
Tip now at Epoch 160 Slot 38978436 Block 2965007
```

### Command line tool

Before you install the command line tool, make sure the environment variables `BFCLI_API_KEY` and `BFCLI_NETWORK` exist.

```ps
$> $env:BFCLI_NETWORK
testnet

$> $env:BFCLI_API_KEY
yourawesomeapikeyforblockfrostio
```

#### Install the command line tool

```ps
$> pwd
{$SolutionDir}\src\Blockfrost.Cli

$> dotnet tool install bfcli --add-source nupkg --version 0.2.1
Tool 'bfcli' (version '0.2.1') was successfully installed.

$> dotnet bfcli -v
bfcli v0.2.1
A .NET Cross Platform Tool / Console App for interacting with Blockfrost API.

USAGE: bfcli (OPTION | COMMAND)

Available options:
    -v, --version   Show the bfcli version
    -h, --help      Show this help text

Available commands:
    health

$> dotnet bfcli health | ConvertFrom-Json

is_healthy
----------
      True
```

<!--

### IPFS

```cs
// TODO
```

For a more detailed list of possibilities, [check out the wiki](https://github.com/blockfrost/blockfrost-dotnet/wiki).

-->

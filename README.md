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

## Getting started

To use this SDK, you first need login into to [blockfrost.io](https://blockfrost.io) create your project to retrive your API token.

<img src="https://i.imgur.com/smY12ro.png">

<br/>

## Installation

###  Add package

The SDK is hosted on [nuget.org](https://www.nuget.org/packages/Blockfrost.Api/latest), so you can directly import it using your favorite package manager.

```console
$ dotnet new console -n blockfrost-client
$ cd blockfrost-client
$ dotnet add package Blockfrost.Api --version 0.0.4
```

🚧🚧🚧 ***Please report any issues you find [here](https://github.com/blockfrost/blockfrost-dotnet/issues/new)*** 👍

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

$> dotnet tool install bfcli --add-source nupkg --version 0.0.xyz
<!-- $> dotnet tool install bfcli --version 0.0.4 -->
Tool 'bfcli' (version '0.0.xyz') was successfully installed.

$> dotnet bfcli -v
bfcli v0.0.xyz
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

## Usage

Using the SDK is pretty straight-forward as you can see from the following example.

### Cardano

```cs
using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;

var network = "YOUR_PROJECT_NETWORK"; // testnet, mainnet
var apiKey = "YOUR_API_KEY";

var services = new ServiceCollection()
    .AddBlockfrost(network, apiKey);

var service = services.BuildServiceProvider()
    .GetRequiredService<IBlockfrostService>();

var health = await service.GetHealthAsync();

System.Console.WriteLine(health.IsHealthy);
```

```sh
$ dotnet run
True
```

<!--

### IPFS

```cs
// TODO
```

For a more detailed list of possibilities, [check out the wiki](https://github.com/blockfrost/blockfrost-dotnet/wiki).

-->

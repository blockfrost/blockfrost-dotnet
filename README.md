[![master build ci](https://github.com/tweakch/blockfrost-dotnet/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/tweakch/blockfrost-dotnet/actions/workflows/dotnet.yml)

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

The SDK is hosted on [nuget.com](https://www.nuget.com/package/@blockfrost/blockfrost-dotnet), so you can directly import it using your favorite package manager.

```console
$ dotnet new console blockfrost-client
$ cd blockfrost-client
$ dotnet add package blockfrost-dotnet
```

<br/>

## Usage

Using the SDK is pretty straight-forward as you can see from the following examples.

### Cardano

```cs
using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;

string network = "YOUR_PROJECT_NETWORK"; // testnet, mainnet or ipfs
string apiKey = "YOUR_API_KEY";

IServiceCollection services = new ServiceCollection()
    .AddBlockfrost(network, apiKey);

var service = services.BuildServiceProvider()
    .GetRequiredService<BlockfrostService>();

var health = await service.HealthAsync();

System.Console.WriteLine(health.IsHealthy);
```

```sh
$ dotnet run
True
```

### IPFS

```cs
// TODO
```

For a more detailed list of possibilities, [check out the wiki](https://github.com/blockfrost/blockfrost-dotnet/wiki).


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

### 🏗️ Add package (coming soon) 🚧

The SDK will be hosted on [nuget.org](https://www.nuget.org/).

<!-- 
The SDK is hosted on [nuget.org](https://www.nuget.org/packages/Blockfrost.Api), so you can directly import it using your favorite package manager.

```console
$ dotnet new console -n blockfrost-client
$ cd blockfrost-client
$ dotnet add package Blockfrost.Api --prerelease
```

<br/>
-->

### Add as reference

```console
git clone https://github.com/blockfrost/blockfrost-dotnet
dotnet new console -n blockfrost-client
cd blockfrost-client
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add reference ../blockfrost-dotnet/src/Blockfrost.Api/Blockfrost.Api.csproj
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
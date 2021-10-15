# Test Vector Reference

## Overview

This file defines the Blockfrost.Api Test Vectors.

### Contributing

[see Appendix C]

### Structure

```bash
┆
├╌┬╌ Blockfrost.Api.Tests/
┆ │
  ├╌ Attributes/
  │
  ├╌┬╌╌ dat/
  │ ├╌┬ 01/
  │ │ ├╌╌ reference.draft       
  │ │ ├╌╌ reference.draft.cddl  
  │ │ ├╌╌ reference.draft.raw   
  │ │ ├╌╌ reference.signed
  │ │ ├╌╌ reference.signed.cddl
  │ │ ├╌╌ reference.signed.raw
  │ │ ├╌╌ tx.draft              
  │ │ ├╌╌ tx.draft.cddl         
  │ │ ├╌╌ tx.draft.raw          
  │ │ ├╌╌ tx.signed
  │ │ ├╌╌ tx.signed.cddl
  │ │ └╌╌ tx.signed.raw
  │ ├╌┬ 02/
  │ │ ├╌╌ ...
  │ │ └╌╌ ...
  ┆ ┆ 
  │ ├╌┬ keys/
  │ │ ├╌╌ payment1.addr
  │ │ ├╌╌ payment1.skey
  │ │ ├╌╌ payment1.vkey
  │ │ ├╌╌ payment2.addr
  │ │ ├╌╌ payment2.skey
  │ │ └╌╌ payment2.vkey
  │ │
  │ ├╌╌ protocol.json (protocol parameters)
  │ └╌╌ Vectors.md    (this file)  
  │
  ├╌ Extensions/
  │
  ├╌ Integrations/
  │
  ├╌ Services/
  │
  └╌ AServiceTestBase.cs
  
```

### Keys

In order to ensure consitant test results we define the following keys and addresses to be used within tests.

|Key|Value|Comment|
|-|-|-|
|payment1.addr|`addr_test1vrgvgwfx4xyu3r2sf8nphh4l92y84jsslg5yhyr8xul29rczf3alu`|Address of Wallet A|
|payment1.skey|`5820e260af648b5710bfabd978816b8e73720698926cec799ef9c0a5671b396b9202`|Private Key of Wallet A|
|payment1.vkey|`58200bc7720123b3fd7bc8c0573bbd7df6577cef1a3385ab79959d1319d373f5ebe1`|Public Key of Wallet A|
|payment2.addr|`addr_test1vqah2xrfp8qjp2tldu8wdq38q8c8tegnduae5zrqff3aeec7g467q`|Address of Wallet B|
|payment2.skey|`5820b1c3ffe27415ed97870a0a399e62f2396185925700c7e8058f775bf63ba9caf4`|Private Key of Wallet B|
|payment2.vkey|`58200b41b2f0cd92448ead8fe43e8a0b2b10e1ce6aceffcc6d5543479a5ffa52d149`|Public Key of Wallet B|

## Test Vectors

| Id        | Category        | Description                     | Reference(s) |
|-----------|:---------------:|:--------------------------------|-|
| [01](#01) | Transactions    | Serialize `Transaction` to CBOR | |
| [02](#02) | ...             | ...                             | |
| [99](#99) | IPFS (Add)      | Add IPFS object                 | |


### 01

#### Generate reference

```bash
$ pwd
blockfrost-dotnet/test/Blockfrost.Api.Tests/dat

$ cardano-cli version
cardano-cli 1.28.0 - linux-x86_64 - ghc-8.10
git rev e99393d10bb8f01ad43065627c21a33aa2a024c9

$ cardano-cli transaction build-raw \
--tx-in 98035740ab68cad12cb4d8281d10ce1112ef0933dc84920b8937c3e80d78d120#0 \
--tx-out $(cat keys/payment1.addr)+0 \
--tx-out $(cat keys/payment2.addr)+0 \
--fee 0 \
--out-file 01/reference.draft
```

#### JSON

```json
{
  "type": "TxBodyMary",
  "description": "",
  "cborHex": "83a3008182582098035740ab68cad12cb4d8281d10ce1112ef0933dc84920b8937c3e80d78d12000018282581d60d0c43926a989c88d5049e61bdebf2a887aca10fa284b9067373ea28f0082581d603b75186909c120a97f6f0ee6822701f075e5136f3b9a08604a63dce70002009ffff6"
}
```

#### CDDL

<http://cbor.me>

```cddl
[
    {
        0: [
            [h'98035740AB68CAD12CB4D8281D10CE1112EF0933DC84920B8937C3E80D78D120',
                0
            ]
        ],
        1: [
            [h'60D0C43926A989C88D5049E61BDEBF2A887ACA10FA284B9067373EA28F',
                0
            ],
            [h'603B75186909C120A97F6F0EE6822701F075E5136F3B9A08604A63DCE7',
                0
            ]
        ],
        2: 0
    },
    [],
    null
]
```

### 02

#### Generate reference

```bash
$ pwd
blockfrost-dotnet/test/Blockfrost.Api.Tests/dat

$ cardano-cli version
cardano-cli 1.28.0 - linux-x86_64 - ghc-8.10
git rev e99393d10bb8f01ad43065627c21a33aa2a024c9
```

#### JSON

```json

```

#### CDDL

```cddl

```

### 99

#### Generate reference

```bash
QmR8x7pEQUr1CGxstkd48ZPKi2y1bBBtq7ozZRJWLpbA1M
```

#### JSON

```json

```

#### CDDL

```cddl
```

## Appendix C

Thank you for taking the time to contribute to this document.

### Prerequisites

#### cardano-cli

Make sure `cardano-cli` is in version `1.27` or above.

```sh
$ cardano-cli --version
cardano-cli 1.28.0 - linux-x86_64 - ghc-8.10
git rev e99393d10bb8f01ad43065627c21a33aa2a024c9
```

#### cardano-node

Make sure you have `cardano-node` running and synced on the `testnet`

```sh
$ cardano-cli query tip --testnet-magic 1097911063
{
    "epoch": 151,
    "hash": "6cd9f629c5a6873247495fecd2f809dbdfa7edcad20378eab55d34f038ffe047",
    "slot": 35261594,
    "block": 2851214,
    "era": "Mary"
}
```

### Requirements

To add a test vector to this document, make sure it adheres to the following requirements.

* Vectors are numbered from 01 to XX.
* Each vector MUST define the means of how it was generated in the [table](#test-vectors) below.
* Each vector MUST provide one or many `reference` files.

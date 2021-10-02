// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Fixtures
{
    [TestClass]
    public class DeserializeTransactionUtxosFixture
    {
        [TestMethod]
        public void Test()
        {
            string json = @"
{
    ""hash"": ""241889398bc4ac9e0cc6141f162650daafed7c34410bb6ddcba8a5c40c640f48"",
    ""inputs"":
        [
            {
                ""address"": ""addr_test1qpf95844zzeanvvgdw6ltpmed40efa73kda0zm5l9u3x42g54fq0pmwp8ndmlp6x63xz7kvdd8v7scnmph4m0fjystss270xn8"",
                ""amount"": [{ ""unit"": ""lovelace"", ""quantity"": ""713909154"" }],
                ""tx_hash"": ""18a58eb373dbcfa52cececcd3b646b7e493d2d9c58b2a93f642f5caf0f33b909"",
                ""output_index"": 0,
                ""collateral"": false,
                ""data_hash"": null,
            },
            {
                ""address"": ""addr_test1wpfyv7sf65u6ejrttwnwvuq6n3yjrgr3xrtuczd60z829gsvf274g"",
                ""amount"":
                    [
                        { ""unit"": ""lovelace"", ""quantity"": ""2000000"" },
                        {
                            ""unit"": ""76331a18becab0a74faa61e8c75c88016c6790ba829b40f80b4bd46d43334e6f64654e4654"",
                            ""quantity"": ""1"",
                        },
                    ],
                ""tx_hash"": ""18a58eb373dbcfa52cececcd3b646b7e493d2d9c58b2a93f642f5caf0f33b909"",
                ""output_index"": 1,
                ""collateral"": false,
                ""data_hash"": ""cad5702913dcda8e084a06550ba82d00e986426203757f7a1aeb8833a07e330f"",
            },
            {
                ""address"": ""addr_test1qpf95844zzeanvvgdw6ltpmed40efa73kda0zm5l9u3x42g54fq0pmwp8ndmlp6x63xz7kvdd8v7scnmph4m0fjystss270xn8"",
                ""amount"": [{ ""unit"": ""lovelace"", ""quantity"": ""713909154"" }],
                ""tx_hash"": ""18a58eb373dbcfa52cececcd3b646b7e493d2d9c58b2a93f642f5caf0f33b909"",
                ""output_index"": 0,
                ""collateral"": true,
                ""data_hash"": null,
            },
        ],
    ""outputs"":
        [
            {
                ""address"": ""addr_test1qpf95844zzeanvvgdw6ltpmed40efa73kda0zm5l9u3x42g54fq0pmwp8ndmlp6x63xz7kvdd8v7scnmph4m0fjystss270xn8"",
                ""amount"": [{ ""unit"": ""lovelace"", ""quantity"": ""713325103"" }],
                ""output_index"": 0,
                ""data_hash"": null,
            },
            {
                ""address"": ""addr_test1wpfyv7sf65u6ejrttwnwvuq6n3yjrgr3xrtuczd60z829gsvf274g"",
                ""amount"":
                    [
                        { ""unit"": ""lovelace"", ""quantity"": ""2000000"" },
                        {
                            ""unit"": ""76331a18becab0a74faa61e8c75c88016c6790ba829b40f80b4bd46d43334e6f64654e4654"",
                            ""quantity"": ""1"",
                        },
                    ],
                ""output_index"": 1,
                ""data_hash"": ""cad5702913dcda8e084a06550ba82d00e986426203757f7a1aeb8833a07e330f"",
            },
        ],
}";
            var model = JsonSerializer.Deserialize<Api.Models.TxContentUtxoResponse>(json, new JsonSerializerOptions() { AllowTrailingCommas = true });
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void DeserializeTxContentUtxoResponseInputs()
        {
            string json = @"
{
    ""address"": ""addr_test1wpfyv7sf65u6ejrttwnwvuq6n3yjrgr3xrtuczd60z829gsvf274g"",
    ""amount"":
        [
            { ""unit"": ""lovelace"", ""quantity"": ""2000000"" },
            { ""unit"": ""76331a18becab0a74faa61e8c75c88016c6790ba829b40f80b4bd46d43334e6f64654e4654"",""quantity"": ""1"",},
        ],
    ""tx_hash"": ""18a58eb373dbcfa52cececcd3b646b7e493d2d9c58b2a93f642f5caf0f33b909"",
    ""output_index"": 1,
    ""collateral"": false,
    ""data_hash"": ""cad5702913dcda8e084a06550ba82d00e986426203757f7a1aeb8833a07e330f"",
}";
            var model = JsonSerializer.Deserialize<Api.Models.TxContentUtxoResponseInputs>(json,  new JsonSerializerOptions() { AllowTrailingCommas = true });
            Assert.IsNotNull(model);
        }

    }
}

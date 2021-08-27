// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace Blockfrost.Api.Utils
{
    public class ProtocolParameters
    {
        [JsonPropertyName("txFeePerByte")]
        public long TxFeePerByte { get; set; }

        [JsonPropertyName("minUTxOValue")]
        public long MinUTxOValue { get; set; }

        [JsonPropertyName("stakePoolDeposit")]
        public long StakePoolDeposit { get; set; }

        [JsonPropertyName("utxoCostPerWord")]
        public object UtxoCostPerWord { get; set; }

        [JsonPropertyName("decentralization")]
        public long Decentralization { get; set; }

        [JsonPropertyName("poolRetireMaxEpoch")]
        public long PoolRetireMaxEpoch { get; set; }

        [JsonPropertyName("extraPraosEntropy")]
        public object ExtraPraosEntropy { get; set; }

        [JsonPropertyName("collateralPercentage")]
        public object CollateralPercentage { get; set; }

        [JsonPropertyName("stakePoolTargetNum")]
        public long StakePoolTargetNum { get; set; }

        [JsonPropertyName("maxBlockBodySize")]
        public long MaxBlockBodySize { get; set; }

        [JsonPropertyName("maxTxSize")]
        public long MaxTxSize { get; set; }

        [JsonPropertyName("treasuryCut")]
        public double TreasuryCut { get; set; }

        [JsonPropertyName("minPoolCost")]
        public long MinPoolCost { get; set; }

        [JsonPropertyName("maxCollateralInputs")]
        public object MaxCollateralInputs { get; set; }

        [JsonPropertyName("maxValueSize")]
        public object MaxValueSize { get; set; }

        [JsonPropertyName("maxBlockExecutionUnits")]
        public object MaxBlockExecutionUnits { get; set; }

        [JsonPropertyName("maxBlockHeaderSize")]
        public long MaxBlockHeaderSize { get; set; }

        [JsonPropertyName("costModels")]
        public CostModels CostModels { get; set; }

        [JsonPropertyName("maxTxExecutionUnits")]
        public object MaxTxExecutionUnits { get; set; }

        [JsonPropertyName("protocolVersion")]
        public ProtocolVersion ProtocolVersion { get; set; }

        [JsonPropertyName("txFeeFixed")]
        public long TxFeeFixed { get; set; }

        [JsonPropertyName("stakeAddressDeposit")]
        public long StakeAddressDeposit { get; set; }

        [JsonPropertyName("monetaryExpansion")]
        public double MonetaryExpansion { get; set; }

        [JsonPropertyName("poolPledgeInfluence")]
        public double PoolPledgeInfluence { get; set; }

        [JsonPropertyName("executionUnitPrices")]
        public object ExecutionUnitPrices { get; set; }
    }
}

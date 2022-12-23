using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    public partial class AssetResponseMetadata : IEquatable<AssetResponseMetadata>
    {
        /// <summary>Number of decimal places of the asset unit</summary>
        [JsonPropertyName("decimals")]
        [Range(int.MinValue, 255)]
        public int? Decimals { get; set; }

        /// <summary>Asset description</summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        /// <summary>Base64 encoded logo of the asset</summary>
        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        /// <summary>Asset name</summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        /// <summary>Asset website</summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public bool Equals(AssetResponseMetadata other) => GetHashCode() == other.GetHashCode();

        public override bool Equals(object obj)
        {
            return Equals(obj as AssetResponseMetadata);
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Decimals);
            hashCode.Add(Description);
            hashCode.Add(Logo);
            hashCode.Add(Name);
            hashCode.Add(Ticker);
            hashCode.Add(Url);
            hashCode.Add(Decimals);
            return hashCode.ToHashCode();
        }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The amound of a UTxO
    /// </summary>
    public partial class InputAmount : IEquatable<Amount>
    {
        /// <summary>The quantity of the unit</summary>
        [JsonPropertyName("quantity")]
        [Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        /// <summary>The unit of the value</summary>
        [JsonPropertyName("unit")]
        [Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The hash of the transaction output datum</summary>
        [JsonPropertyName("data_hash")]
        [Required(AllowEmptyStrings = true)]
        public string DataHash { get; set; }

        public bool Equals(Amount other) => GetHashCode() == other.GetHashCode();

        public override bool Equals(object obj)
        {
            return Equals(obj as Amount);
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Quantity);
            hashCode.Add(Unit);
            return hashCode.GetHashCode();
        }
    }

    /// <summary>
    /// The amound of a UTxO
    /// </summary>
    public partial class OutputAmount : IEquatable<Amount>
    {
        /// <summary>The quantity of the unit</summary>
        [JsonPropertyName("quantity")]
        [Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        /// <summary>The unit of the value</summary>
        [JsonPropertyName("unit")]
        [Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

        /// <summary>The hash of the transaction output datum</summary>
        [JsonPropertyName("data_hash")]
        [Required(AllowEmptyStrings = true)]
        public string DataHash { get; set; }

        public bool Equals(Amount other) => GetHashCode() == other.GetHashCode();

        public override bool Equals(object obj)
        {
            return Equals(obj as Amount);
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Quantity);
            hashCode.Add(Unit);
            return hashCode.GetHashCode();
        }
    }
}


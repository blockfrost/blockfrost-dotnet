using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    public partial class Amount : IEquatable<Amount>
    {
        /// <summary>The quantity of the unit</summary>
        [JsonPropertyName("quantity")]
        [Required(AllowEmptyStrings = true)]
        public string Quantity { get; set; }

        /// <summary>The unit of the value</summary>
        [JsonPropertyName("unit")]
        [Required(AllowEmptyStrings = true)]
        public string Unit { get; set; }

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


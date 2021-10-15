using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PinStateContentResponse" />
    /// </summary>
    public partial class PinStateContentResponse : IEquatable<PinStateContentResponse>
    {
        public PinStateContentResponse()
        {
        }

        [Required]
        [JsonPropertyName("ipfs_hash")]
        public string IpfsHash { get; set; }

        [Required]
        [JsonPropertyName("state")]
        public string State { get; set; }

        public bool Equals(PinStateContentResponse other)
        {
            return other is not null
                && (ReferenceEquals(this, other)
                || (string.Equals(IpfsHash, other.IpfsHash, StringComparison.Ordinal) && string.Equals(State, other.State, StringComparison.Ordinal)));
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return obj is not null
                   && (ReferenceEquals(this, obj)
                   || (obj.GetType() != GetType() && Equals((PinStateContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(IpfsHash);
            hashCode.Add(State);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PinStateContentResponse left, PinStateContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PinStateContentResponse left, PinStateContentResponse right)
        {
            return !Equals(left, right);
        }

    }
}


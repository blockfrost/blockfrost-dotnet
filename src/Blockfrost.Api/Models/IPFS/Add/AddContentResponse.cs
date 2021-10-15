using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AddContentResponse" />
    /// </summary>
    public partial class AddContentResponse : IEquatable<AddContentResponse>
    {
        public AddContentResponse()
        {
        }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("ipfs_hash")]
        public string IpfsHash { get; set; }

        [Required]
        [JsonPropertyName("size")]
        public string Size { get; set; }

        public bool Equals(AddContentResponse other)
        {
            return other is not null
                && (ReferenceEquals(this, other)
                || (string.Equals(Name, other.Name, StringComparison.Ordinal) && string.Equals(IpfsHash, other.IpfsHash, StringComparison.Ordinal) && Size == other.Size));
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
                   || (obj.GetType() != GetType() && Equals((PoolResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Name);
            hashCode.Add(IpfsHash);
            hashCode.Add(Size);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AddContentResponse left, AddContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddContentResponse left, AddContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}


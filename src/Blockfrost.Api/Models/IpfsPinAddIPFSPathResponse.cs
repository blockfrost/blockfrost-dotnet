using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="IpfsPinAddIPFSPathResponse"/>
    /// </summary>
    public partial class IpfsPinAddIPFSPathResponse : IEquatable<IpfsPinAddIPFSPathResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpfsPinAddIPFSPathResponse" /> class.
        /// </summary>
        public IpfsPinAddIPFSPathResponse()
        {
        }

        /// <summary>
        /// Gets or sets the IpfsHash
        /// </summary>
        /// <returns>
        /// IPFS hash of the pinned object
        /// </returns>
        [Required]
        [JsonPropertyName("ipfs_hash")]
        public string IpfsHash { get; set; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        /// <returns>
        /// State of the pin action
        /// </returns>
        [Required]
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return ToJson();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson(JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(this, options);
        }
        /// <summary>
        /// Returns true if IpfsPinAddIPFSPathResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of IpfsPinAddIPFSPathResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IpfsPinAddIPFSPathResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (IpfsHash == other.IpfsHash && State == other.State));
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
                   || (obj.GetType() != GetType() && Equals((IpfsPinAddIPFSPathResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(IpfsHash);
            hashCode.Add(State);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(IpfsPinAddIPFSPathResponse left, IpfsPinAddIPFSPathResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IpfsPinAddIPFSPathResponse left, IpfsPinAddIPFSPathResponse right)
        {
            return !Equals(left, right);
        }
    }
}


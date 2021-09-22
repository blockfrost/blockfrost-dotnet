using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="IpfsPinListIPFSPathResponse"/>
    /// </summary>
    public partial class IpfsPinListIPFSPathResponse : IEquatable<IpfsPinListIPFSPathResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpfsPinListIPFSPathResponse" /> class.
        /// </summary>
        public IpfsPinListIPFSPathResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TimeCreated
        /// </summary>
        /// <returns>
        /// Time of the creation of the IPFS object on our backends
        /// </returns>
        [Required]
        [JsonPropertyName("time_created")]
        public long TimeCreated { get; set; }

        /// <summary>
        /// Gets or sets the TimePinned
        /// </summary>
        /// <returns>
        /// Time of the pin of the IPFS object on our backends
        /// </returns>
        [Required]
        [JsonPropertyName("time_pinned")]
        public long TimePinned { get; set; }

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
        /// Gets or sets the Size
        /// </summary>
        /// <returns>
        /// Size of the object in Bytes
        /// </returns>
        [Required]
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        /// <returns>
        /// State of the pinned object. We define 5 states: `queued`, `pinned`, `unpinned`, `failed`, `gc`.When the object is pending retrieval (i.e. after `/ipfs/pin/add/{IPFS_path}`), the state is `queued`.If the object is already successfully retrieved, state is changed to `pinned` or `failed` otherwise.When object is unpinned (i.e. after `/ipfs/pin/remove/{IPFS_path}`) it is marked for garbage collection.State `gc` means that a previously `unpinned` item has been garbage collected due to account being over storage quota.
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
        /// Returns true if IpfsPinListIPFSPathResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of IpfsPinListIPFSPathResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IpfsPinListIPFSPathResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TimeCreated == other.TimeCreated && TimePinned == other.TimePinned && IpfsHash == other.IpfsHash && Size == other.Size && State == other.State));
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
                   || (obj.GetType() != GetType() && Equals((IpfsPinListIPFSPathResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TimeCreated);
            hashCode.Add(TimePinned);
            hashCode.Add(IpfsHash);
            hashCode.Add(Size);
            hashCode.Add(State);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(IpfsPinListIPFSPathResponse left, IpfsPinListIPFSPathResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IpfsPinListIPFSPathResponse left, IpfsPinListIPFSPathResponse right)
        {
            return !Equals(left, right);
        }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="IpfsPinListResponse"/>
    /// </summary>
    public partial class IpfsPinListResponse : IEquatable<IpfsPinListResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpfsPinListResponse" /> class.
        /// </summary>
        public IpfsPinListResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TimeCreated
        /// </summary>
        /// <returns>
        /// Creation time of the IPFS object on our backends
        /// </returns>
        [Required]
        [JsonPropertyName("time_created")]
        public long TimeCreated { get; set; }

        /// <summary>
        /// Gets or sets the TimePinned
        /// </summary>
        /// <returns>
        /// Pin time of the IPFS object on our backends
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
        /// State of the pinned object, which is `queued` when we are retriving object. If thisis successful the state is changed to `pinned` or `failed` if not. The state `gc` means thepinned item has been garbage collected due to account being over storage quota or after it hasbeen moved to `unpinned` state by removing the object pin.
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
        /// Returns true if IpfsPinListResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of IpfsPinListResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IpfsPinListResponse other)
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
                   || (obj.GetType() != GetType() && Equals((IpfsPinListResponse)obj)));
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

        public static bool operator ==(IpfsPinListResponse left, IpfsPinListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IpfsPinListResponse left, IpfsPinListResponse right)
        {
            return !Equals(left, right);
        }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="IpfsAddResponse"/>
    /// </summary>
    public partial class IpfsAddResponse : IEquatable<IpfsAddResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpfsAddResponse" /> class.
        /// </summary>
        public IpfsAddResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        /// <returns>
        /// Name of the file
        /// </returns>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IpfsHash
        /// </summary>
        /// <returns>
        /// IPFS hash of the file
        /// </returns>
        [Required]
        [JsonPropertyName("ipfs_hash")]
        public string IpfsHash { get; set; }

        /// <summary>
        /// Gets or sets the Size
        /// </summary>
        /// <returns>
        /// IPFS node size in Bytes
        /// </returns>
        [Required]
        [JsonPropertyName("size")]
        public string Size { get; set; }

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
        /// Returns true if IpfsAddResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of IpfsAddResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IpfsAddResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Name == other.Name && IpfsHash == other.IpfsHash && Size == other.Size));
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
                   || (obj.GetType() != GetType() && Equals((IpfsAddResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Name);
            hashCode.Add(IpfsHash);
            hashCode.Add(Size);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(IpfsAddResponse left, IpfsAddResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IpfsAddResponse left, IpfsAddResponse right)
        {
            return !Equals(left, right);
        }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="PoolRelaysResponse"/>
    /// </summary>
    public partial class PoolRelaysResponse : IEquatable<PoolRelaysResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolRelaysResponse" /> class.
        /// </summary>
        public PoolRelaysResponse()
        {
        }

        /// <summary>
        /// Gets or sets the Ipv4
        /// </summary>
        /// <returns>
        /// IPv4 address of the relay
        /// </returns>
        [Required]
        [JsonPropertyName("ipv4")]
        public string Ipv4 { get; set; }

        /// <summary>
        /// Gets or sets the Ipv6
        /// </summary>
        /// <returns>
        /// IPv6 address of the relay
        /// </returns>
        [Required]
        [JsonPropertyName("ipv6")]
        public string Ipv6 { get; set; }

        /// <summary>
        /// Gets or sets the Dns
        /// </summary>
        /// <returns>
        /// DNS name of the relay
        /// </returns>
        [Required]
        [JsonPropertyName("dns")]
        public string Dns { get; set; }

        /// <summary>
        /// Gets or sets the DnsSrv
        /// </summary>
        /// <returns>
        /// DNS SRV entry of the relay
        /// </returns>
        [Required]
        [JsonPropertyName("dns_srv")]
        public string DnsSrv { get; set; }

        /// <summary>
        /// Gets or sets the Port
        /// </summary>
        /// <returns>
        /// Network port of the relay
        /// </returns>
        [Required]
        [JsonPropertyName("port")]
        public long Port { get; set; }

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
        /// Returns true if PoolRelaysResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PoolRelaysResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PoolRelaysResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (Ipv4 == other.Ipv4 && Ipv6 == other.Ipv6 && Dns == other.Dns && DnsSrv == other.DnsSrv && Port == other.Port));
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
                   || (obj.GetType() != GetType() && Equals((PoolRelaysResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(Ipv4);
            hashCode.Add(Ipv6);
            hashCode.Add(Dns);
            hashCode.Add(DnsSrv);
            hashCode.Add(Port);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(PoolRelaysResponse left, PoolRelaysResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PoolRelaysResponse left, PoolRelaysResponse right)
        {
            return !Equals(left, right);
        }
    }
}


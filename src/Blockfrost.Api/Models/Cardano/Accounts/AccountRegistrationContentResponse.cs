﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockfrost.Api.Utils;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// The <see cref="AccountRegistrationContentResponse"/>
    /// </summary>
    public partial class AccountRegistrationContentResponse : IEquatable<AccountRegistrationContentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRegistrationContentResponse" /> class.
        /// </summary>
        public AccountRegistrationContentResponse()
        {
        }

        /// <summary>
        /// Gets or sets the TxHash
        /// </summary>
        /// <returns>
        /// Hash of the transaction containing the (de)registration certificate
        /// </returns>
        [Required]
        [JsonPropertyName("tx_hash")]
        public string TxHash { get; set; }

        /// <summary>
        /// Gets or sets the Action
        /// </summary>
        /// <returns>
        /// Action in the certificate
        /// </returns>
        [Required]
        [JsonPropertyName("action")]
        public string Action { get; set; }

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
        /// Returns true if AccountRegistrationContentResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountRegistrationContentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountRegistrationContentResponse other)
        {
            return other is not null
                   && (ReferenceEquals(this, other)
                   || (TxHash == other.TxHash && Action == other.Action));
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
                   || (obj.GetType() != GetType() && Equals((AccountRegistrationContentResponse)obj)));
        }

        public override int GetHashCode()
        {
            var hashCode = new BlockfrostHashCode();
            hashCode.Add(TxHash);
            hashCode.Add(Action);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(AccountRegistrationContentResponse left, AccountRegistrationContentResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccountRegistrationContentResponse left, AccountRegistrationContentResponse right)
        {
            return !Equals(left, right);
        }
    }
}


﻿using System.Collections.ObjectModel;
using System.Text.Json;

namespace Blockfrost.Api.Models
{
    /// <summary>
    /// A collection of <see cref="EpochStakeContentResponse"/>
    /// </summary>
    public partial class EpochStakeContentResponseCollection : Collection<EpochStakeContentResponse>
    {
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
    }
}


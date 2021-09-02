using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using Blockfrost.Api.Http;

namespace Blockfrost.Api.Services.Cardano
{
    public partial interface ILedgerService 
    {

        /// <summary>Blockchain genesis</summary>
        /// <remarks>Route template: /genesis</remarks>
        /// <returns>Return the genesis parameters.</returns>
        [Get("/genesis","0.1.26")]
        Task<LedgerGetGenesisResponse> GetGenesisAsync();

        /// <summary>Blockchain genesis</summary>
        /// <remarks>Route template: /genesis</remarks>
        /// <returns>Return the genesis parameters.</returns>
        [Get("/genesis","0.1.26")]
        Task<LedgerGetGenesisResponse> GetGenesisAsync(CancellationToken token);
    }
    
    public partial class LedgerService : ILedgerService 
    {

        /// <summary>Blockchain genesis</summary>
        /// <remarks>Route template: /genesis</remarks>
        /// <returns>Return the genesis parameters.</returns>
        [Get("/genesis","0.1.26")]
        public Task<LedgerGetGenesisResponse> GetGenesisAsync()
        {
            return GetGenesisAsync(CancellationToken.None);
        }

        /// <summary>Blockchain genesis</summary>
        /// <remarks>Route template: /genesis</remarks>
        /// <returns>Return the genesis parameters.</returns>
        [Get("/genesis","0.1.26")]
        public Task<LedgerGetGenesisResponse> GetGenesisAsync(CancellationToken token)
        {
            throw new NotImplementedException(); 
        }
    }
}


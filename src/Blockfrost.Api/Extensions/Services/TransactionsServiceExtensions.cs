using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Http;
using Blockfrost.Api.Models;
using CardanoSharp.Wallet.Extensions;

namespace Blockfrost.Api.Services.Extensions
{
    public static class TransactionsServiceExtensions
    {
        /// <summary>
        ///     Transaction UTXOs <c>/txs/{hash}/utxos</c>
        /// </summary>
        /// <remarks>
        ///     See also <seealso href="https://docs.blockfrost.io/#tag/Cardano-Transactions/paths/~1txs~1{hash}~1utxos/get">/txs/{hash}/utxos</seealso> on docs.blockfrost.io
        /// </remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of all the transactions in <paramref name="hashes"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Null referemce parameter is not accepted.</exception>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [Get("/txs/{hash}/utxos", "0.1.28")]
        public static async Task<IEnumerable<Models.TxContentUtxoResponse>> GetUtxosAsync(this ITransactionsService service, StringCollection hashes, CancellationToken cancellationToken = default)
        {
            var responses = new List<Models.TxContentUtxoResponse>();

            foreach (string hash in hashes)
            {
                responses.Add(await service.GetUtxosAsync(hash, cancellationToken));
            }
            return responses;
        }

        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public static Task<string> PostTxSubmitAsync(this ITransactionsService service, string content)
        {
            return service.PostTxSubmitAsync(content, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public static async Task<string> PostTxSubmitAsync(this ITransactionsService service, string content, CancellationToken cancellationToken)
        {
            // we expect cbor in hex
            if (!Regex.IsMatch(content, "^[0-9a-f]+$", RegexOptions.IgnoreCase))
            {
                //   we can assume it is either CDDL or JSON
                try
                {
                    throw new NotSupportedException("CDDL is not supported");
                }
                catch
                {
                    // Assume its a cardano cli transaction
                    content = JsonDocument.Parse(content).RootElement.GetProperty("cborHex").GetString();
                    return await service.PostTxSubmitAsync(content, cancellationToken);
                }
            }

            // Send as byte
            return await service.PostTxSubmitAsync(content.HexToByteArray(), cancellationToken);
        }

        public static Task<string> PostTxSubmitAsync(this ITransactionsService service, byte[] rawCbor)
        {
            return service.PostTxSubmitAsync(rawCbor, CancellationToken.None);
        }

        public static async Task<string> PostTxSubmitAsync(this ITransactionsService service, byte[] rawCbor, CancellationToken cancellationToken)
        {
#if NET5_0_OR_GREATER
            byte[] cborHex = rawCbor;
            var reader = new System.Formats.Cbor.CborReader(cborHex, System.Formats.Cbor.CborConformanceMode.Strict, false);

            int? arrLength = reader.ReadStartArray();

            for (uint i = 0; i < arrLength; i++)
            {
                if (reader.PeekState() == System.Formats.Cbor.CborReaderState.Null)
                {
                    reader.SkipValue();
                    continue;
                }

                int? mapLength = reader.ReadStartMap();
                for (uint j = 0; j < mapLength; j++)
                {
                    uint value = reader.ReadUInt32();
                    if (value != j)
                    {
                        throw new ArgumentException("The provided transaction is invalid", nameof(rawCbor));
                    }
                    // we will not validate the individual values
                    reader.SkipValue();
                }

                reader.ReadEndMap();
            }

            reader.ReadEndArray();

            if (reader.BytesRemaining != 0)
            {
                throw new ArgumentException("The provided transaction is invalid", nameof(rawCbor));
            }
#else
            bool notArray = rawCbor[0] >> 4 != 4; // CBOR MajorType 4 = array 
            bool notMap = rawCbor[1] >> 4 != 5;   // CBOR MajorType 5 = map (txbody is a map)
            if (notArray || notMap || (rawCbor[0] & 0xf0) != 3) // '3' because we expect 'three' sections (txbody, scripts and metadata)
            {
                throw new ArgumentException("The provided transaction is invalid", nameof(rawCbor));
            }
            // this is really all we can do without parsing it
#endif
            using var stream = new MemoryStream(rawCbor);
            return await service.PostTxSubmitAsync(stream, cancellationToken);
        }
    }
}

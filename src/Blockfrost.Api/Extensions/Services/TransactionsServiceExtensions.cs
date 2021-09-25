// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;
using CardanoSharp.Wallet.Extensions;

namespace Blockfrost.Api.Extensions.Services
{
    public static class TransactionsServiceExtensions
    {
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
                    throw new NotSupportedException("We don't support CDDL for now");
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

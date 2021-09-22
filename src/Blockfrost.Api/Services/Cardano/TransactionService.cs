using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Extensions;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial class TransactionService : ABlockfrostService, ITransactionService
    {
        public ITransactionsService V1 { get; set; }

        public TransactionService(ITransactionsService service, HttpClient httpClient) : base(httpClient)
        {
            V1 = service;
        }
        public TransactionService(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>Transaction metadata in CBOR</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash)
        {
            return CborAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction metadata in CBOR</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/metadata/cbor");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxMetadataCborResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction delegation certificates</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxDelegation>> DelegationsAsync(string hash)
        {
            return DelegationsAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction delegation certificates</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about delegation certificates of a specific transaction</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxDelegation>> DelegationsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/delegations");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxDelegation>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction metadata</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash)
        {
            return MetadataAllAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction metadata</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Obtain information about stake pool retirements within a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/metadata");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxMetadataResponse>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction MIRs</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxMir>> MirsAsync(string hash)
        {
            return MirsAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction MIRs</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxMir>> MirsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/mirs");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxMir>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction stake addresses certificates</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxStakeAddress>> Stakes3Async(string hash)
        {
            return Stakes3Async(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction stake addresses certificates</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about (de)registration of stake addresses within a transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxStakeAddress>> Stakes3Async(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/stakes");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxStakeAddress>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Specific transaction</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<TxContentResponse> TxsAsync(string hash)
        {
            return TxsAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific transaction</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<TxContentResponse> TxsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<TxContentResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction UTXOs</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<TxContentUTxOResponse> UtxosAsync(string hash)
        {
            return UtxosAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction UTXOs</summary>
        /// <param name="hash">Hash of the requested transaction</param>
        /// <returns>Return the contents of the transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<TxContentUTxOResponse> UtxosAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/utxos");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<TxContentUTxOResponse>(urlBuilder_, cancellationToken);
        }

        /// <summary>Transaction withdrawal</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash)
        {
            return WithdrawalsAsync(hash, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Transaction withdrawal</summary>
        /// <param name="hash">Hash of the requested transaction.</param>
        /// <returns>Obtain information about withdrawals of a specific transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash, CancellationToken cancellationToken)
        {
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/txs/{hash}/withdrawals");
            _ = urlBuilder_.Replace("{hash}", Uri.EscapeDataString(ConvertToString(hash, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<ICollection<TxWithdawal>>(urlBuilder_, cancellationToken);
        }

        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<string> SubmitAsync(string content)
        {
            return SubmitAsync(content, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<string> SubmitAsync(string content, CancellationToken cancellationToken)
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
                    return await SubmitAsync(content, cancellationToken);
                }
            }

            // Send as byte
            return await SubmitAsync(content.HexToByteArray(), cancellationToken);
        }

        public Task<string> SubmitAsync(byte[] rawCbor)
        {
            return SubmitAsync(rawCbor, CancellationToken.None);
        }

        public async Task<string> SubmitAsync(byte[] rawCbor, CancellationToken cancellationToken)
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
            return await SubmitAsync(stream, cancellationToken);
        }

        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<string> SubmitAsync(Stream content)
        {
            return SubmitAsync(content, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Submit a transaction</summary>
        /// <returns>Return the ID of the submitted transaction.</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<string> SubmitAsync(Stream content, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            _ = urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/tx/submit");

            return await SendPostRequestAsync<string>(content, urlBuilder_, cancellationToken);
        }
    }
}

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"


using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace Blockfrost.Api
{
    public partial class BlockfrostService : IBlockfrostService
    { /// <summary>Assets</summary>
      /// <param name="count">The number of results displayed on one page.</param>
      /// <param name="page">The page number for listing the results.</param>
      /// <param name="order">The ordering of items from the point of view of the blockchain,
      /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
      /// <returns>Return list of assets</returns>
      /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order)
        {
            return AssetsAll2Async(count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Assets</summary>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return list of assets</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetsResponse>> AssetsAll2Async(int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets?");
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetsResponse>>(urlBuilder_, cancellationToken);
          
        }

        /// <summary>Specific asset</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<AssetResponse> AssetsAsync(string asset)
        {
            return AssetsAsync(asset, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Specific asset</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<AssetResponse> AssetsAsync(string asset, CancellationToken cancellationToken)
        {
            if (asset == null)
                throw new System.ArgumentNullException("asset");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}");
            urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));

            return await SendGetRequestAsync<AssetResponse>(urlBuilder_, cancellationToken);
        }
        /// <summary>Asset history</summary>
         /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
         /// <param name="count">The number of results displayed on one page.</param>
         /// <param name="page">The page number for listing the results.</param>
         /// <param name="order">The ordering of items from the point of view of the blockchain,
         /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
         /// <returns>Return the information about the history of a specific asset</returns>
         /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return History3Async(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset history</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetHistoryResponse>> History3Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
                throw new System.ArgumentNullException("asset");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/history?");
            urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetHistoryResponse>>(urlBuilder_, cancellationToken);
            
        }
        
        /// <summary>Asset transactions</summary>
         /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
         /// <param name="count">The number of results displayed on one page.</param>
         /// <param name="page">The page number for listing the results.</param>
         /// <param name="order">The ordering of items from the point of view of the blockchain,
         /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
         /// <returns>Return the information about the history of a specific asset</returns>
         /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete]
        public Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return TxsAll4Async(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset transactions</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        [System.Obsolete]
        public async Task<ICollection<string>> TxsAll4Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
                throw new System.ArgumentNullException("asset");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/txs?");
            urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<string>>(urlBuilder_, cancellationToken);
          
        }/// <summary>Asset transactions</summary>
         /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
         /// <param name="count">The number of results displayed on one page.</param>
         /// <param name="page">The page number for listing the results.</param>
         /// <param name="order">The ordering of items from the point of view of the blockchain,
         /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
         /// <returns>Return the information about the history of a specific asset</returns>
         /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order)
        {
            return Transactions2Async(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset transactions</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetTransactionResponse>> Transactions2Async(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
                throw new System.ArgumentNullException("asset");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/transactions?");
            urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetTransactionResponse>>(urlBuilder_, cancellationToken);

        }

        /// <summary>Asset addresses</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order)
        {
            return GetAssetAddressesAsync(asset, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Asset addresses</summary>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about the history of a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetAddressesResponse>> GetAssetAddressesAsync(string asset, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (asset == null)
                throw new System.ArgumentNullException("asset");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/{asset}/addresses?");
            urlBuilder_.Replace("{asset}", System.Uri.EscapeDataString(ConvertToString(asset, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetAddressesResponse>>(urlBuilder_, cancellationToken);
         
        }

        /// <summary>Assets of a specific policy</summary>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order)
        {
            return PolicyAsync(policy_id, count, page, order, CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Assets of a specific policy</summary>
        /// <param name="policy_id">Specific policy_id</param>
        /// <param name="count">The number of results displayed on one page.</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain,
        /// <br/>not the page listing itself. By default, we return oldest first, newest last.</param>
        /// <returns>Return the information about a specific asset</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<AssetPolicyResponse>> PolicyAsync(string policy_id, int? count, int? page, ESortOrder? order, CancellationToken cancellationToken)
        {
            if (policy_id == null)
                throw new System.ArgumentNullException("policy_id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/assets/policy/{policy_id}?");
            urlBuilder_.Replace("{policy_id}", System.Uri.EscapeDataString(ConvertToString(policy_id, System.Globalization.CultureInfo.InvariantCulture)));
            if (count != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("count") + "=").Append(System.Uri.EscapeDataString(ConvertToString(count, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (order != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("order") + "=").Append(System.Uri.EscapeDataString(ConvertToString(order, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            return await SendGetRequestAsync<ICollection<AssetPolicyResponse>>(urlBuilder_, cancellationToken);
           
        }

    }
}


#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016
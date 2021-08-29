using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface INutlinkService : IBlockfrostService
    {
        Task<NutlinkAddress> NutlinkAsync(string address);

        Task<NutlinkAddress> NutlinkAsync(string address, CancellationToken cancellationToken);

        Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count,
            int? page, ESortOrder? order);

        Task<ICollection<NutlinkAddressTickerResponse>> Tickers2Async(string address, string ticker, int? count,
            int? page, ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<NutlinkTickersTickerResponse>> Tickers3Async(string ticker, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page,
                            ESortOrder? order);

        Task<ICollection<NutlinkAddressTickersResponse>> TickersAsync(string address, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);
    }
}

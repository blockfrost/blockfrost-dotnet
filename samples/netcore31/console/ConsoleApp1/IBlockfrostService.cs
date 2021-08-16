using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    /// <summary>
    /// Specifies basic functionality for services interacting with the Blockfrost API
    /// </summary>
    public interface IBlockfrostService
    {
        string Network { get; }
        

        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricResponse>> GetMetricsAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Blockfrost usage metrics</summary>
        /// <returns>Return the last 30 days of metrics</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<MetricResponse>> GetMetricsAsync(CancellationToken cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface INetworkService : IServiceMigration<Services.INetworkService>
    {
        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<NetworkResponse> NetworkAsync();

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<NetworkResponse> NetworkAsync(CancellationToken cancellationToken);
    }
}

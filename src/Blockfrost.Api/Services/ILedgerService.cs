using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface ILedgerService : IServiceMigration<Services.ILedgerService>
    {
        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<GenesisContentResponse> GenesisAsync();

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<GenesisContentResponse> GenesisAsync(CancellationToken cancellationToken);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Services;

namespace Blockfrost.Api
{
    public partial interface IEpochService : IServiceMigration<IEpochsService>
    {
        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<string>> EpochBlocks(int number, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<string>> EpochBlocksByPool(int number, string pool_id, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochParamContent> EpochParameters(int number, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochContentResponse> EpochsAsync(int number);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochContentResponse> EpochsAsync(int number, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<EpochStakesResponse>> EpochStakesAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page,
            CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochContentResponse> Latest2Async();

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochContentResponse> Latest2Async(CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<EpochContentResponse>> NextEpochAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochParamContent> Parameters2Async(int number);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochParamContent> ParametersAsync();

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<EpochParamContent> ParametersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<EpochContentResponse>> PreviousEpochAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page);
    }
}

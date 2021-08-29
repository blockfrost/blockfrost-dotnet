using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface IEpochService : IBlockfrostService
    {
        Task<ICollection<string>> BlocksAll2Async(int number, string pool_id, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> BlocksAllAsync(int number, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> EpochBlocks(int number, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<string>> EpochBlocksByPool(int number, string pool_id, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<EpochParamContent> EpochParameters(int number, CancellationToken cancellationToken);

        Task<EpochContentResponse> EpochsAsync(int number);

        Task<EpochContentResponse> EpochsAsync(int number, CancellationToken cancellationToken);

        Task<ICollection<EpochStakesResponse>> EpochStakesAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page);

        Task<ICollection<Anonymous2>> EpochStakesByPool(int number, string pool_id, int? count, int? page,
            CancellationToken cancellationToken);

        Task<EpochContentResponse> Latest2Async();

        Task<EpochContentResponse> Latest2Async(CancellationToken cancellationToken);

        Task<ICollection<EpochContentResponse>> Next2Async(int number, int? count, int? page);

        Task<ICollection<EpochContentResponse>> NextEpochAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<EpochParamContent> Parameters2Async(int number);

        Task<EpochParamContent> ParametersAsync();

        Task<EpochParamContent> ParametersAsync(CancellationToken cancellationToken);

        Task<ICollection<EpochContentResponse>> Previous2Async(int number, int? count, int? page);

        Task<ICollection<EpochContentResponse>> PreviousEpochAsync(int number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<EpochStakesResponse>> StakesAsync(int number, int? count, int? page);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface IBlockService : IBlockfrostService
    {
        Task<BlockContentResponse> GetBlocksAsync(string hash_or_number);

        Task<BlockContentResponse> GetBlocksAsync(string hash_or_number, CancellationToken cancellationToken);

        Task<BlockContentResponse> GetLatestBlockAsync();

        Task<BlockContentResponse> GetLatestBlockAsync(CancellationToken cancellationToken);

        Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page);

        Task<ICollection<BlockContentResponse>> GetNextBlockAsync(string hash_or_number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number);

        Task<BlockContentResponse> GetSlotAsync(int epoch_number, int slot_number, CancellationToken cancellationToken);

        Task<BlockContentResponse> GetSlotAsync(int slot_number);

        Task<BlockContentResponse> GetSlotAsync(int slot_number, CancellationToken cancellationToken);

        Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page);

        Task<ICollection<BlockContentResponse>> PreviousAsync(string hash_or_number, int? count, int? page,
            CancellationToken cancellationToken);

        Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> TxsAll2Async(string hash_or_number, int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<string>> TxsAllAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);
    }
}

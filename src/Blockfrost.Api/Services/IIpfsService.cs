using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface IIpfsService : IBlockfrostService
    {
        Task<IpfsAddResponse> AddIpfsAsync();

        Task<IpfsAddResponse> AddIpfsAsync(CancellationToken cancellationToken);

        Task GatewayAsync(string iPFS_path);

        Task GatewayAsync(string iPFS_path, CancellationToken cancellationToken);

        Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<Anonymous32>> ListAllAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);

        Task<IpfsPinListResponse> ListAsync(string iPFS_path);

        Task<IpfsPinListResponse> ListAsync(string iPFS_path, CancellationToken cancellationToken);

        Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path);

        Task<IpfsPinAddResponse> PostPinAsync(string iPFS_path, CancellationToken cancellationToken);

        Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path);

        Task<IpfsPinRemoveResponse> RemoveAsync(string iPFS_path, CancellationToken cancellationToken);

        Task<string> SubmitAsync(EContentType content_Type);

        Task<string> SubmitAsync(EContentType content_Type, CancellationToken cancellationToken);
    }
}

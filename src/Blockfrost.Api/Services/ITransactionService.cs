using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface ITransactionService : IBlockfrostService
    {
        Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash);

        Task<ICollection<TxMetadataCborResponse>> CborAsync(string hash, CancellationToken cancellationToken);

        Task<ICollection<TxDelegation>> DelegationsAsync(string hash);

        Task<ICollection<TxDelegation>> DelegationsAsync(string hash, CancellationToken cancellationToken);

        Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash);

        Task<ICollection<TxMetadataResponse>> MetadataAllAsync(string hash, CancellationToken cancellationToken);

        Task<ICollection<TxMir>> MirsAsync(string hash);

        Task<ICollection<TxMir>> MirsAsync(string hash, CancellationToken cancellationToken);

        Task<ICollection<TxStakeAddress>> Stakes3Async(string hash);

        Task<ICollection<TxStakeAddress>> Stakes3Async(string hash, CancellationToken cancellationToken);

        Task<TxContentResponse> TxsAsync(string hash);

        Task<TxContentResponse> TxsAsync(string hash, CancellationToken cancellationToken);

        Task<TxContentUTxOResponse> UtxosAsync(string hash);

        Task<TxContentUTxOResponse> UtxosAsync(string hash, CancellationToken cancellationToken);

        Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash);

        Task<ICollection<TxWithdawal>> WithdrawalsAsync(string hash, CancellationToken cancellationToken);

        Task<string> SubmitAsync(string content);

        Task<string> SubmitAsync(string content, CancellationToken cancellationToken);

        Task<string> SubmitAsync(byte[] rawCbor);
        Task<string> SubmitAsync(byte[] rawCbor, CancellationToken cancellationToken);

        Task<string> SubmitAsync(Stream stream);

        Task<string> SubmitAsync(Stream stream, CancellationToken cancellationToken);
    }
}

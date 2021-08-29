using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface IMetadataService : IBlockfrostService
    {
        Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page,
            ESortOrder? order);

        Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order);

        Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);
    }
}

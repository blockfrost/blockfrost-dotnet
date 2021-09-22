using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial interface IMetadataService : IServiceMigration<Services.IMetadataService>
    {
        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page,
            ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<TxMetadataLabelCBORResponse>> Cbor2Async(string label, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page,
            ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<TxMetadataLabelJsonResponse>> Labels2Async(string label, int? count, int? page,
            ESortOrder? order, CancellationToken cancellationToken);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order);

        /// <summary>
        /// Use <see cref="IBlockfrostService.InserMethodName"/> instead
        /// </summary>
        //[System.Obsolete("Service methods without 'Get' prefix will be no longer supported. See comments for details.")]
        Task<ICollection<TxMetadataLabelResponse>> LabelsAsync(int? count, int? page, ESortOrder? order,
            CancellationToken cancellationToken);
    }
}

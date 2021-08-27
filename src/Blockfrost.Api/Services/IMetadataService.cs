// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public interface IMetadataService : IBlockfrostService
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

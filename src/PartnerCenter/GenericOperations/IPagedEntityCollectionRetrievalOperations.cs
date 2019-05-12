﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Represents paged entity retrieval operations.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TResourceCollection">The entity collection type.</typeparam>
    public interface IPagedEntityCollectionRetrievalOperations<T, TResourceCollection> where T : ResourceBase where TResourceCollection : ResourceCollection<T>
    {
        /// <summary>
        /// Retrieves a subset of entities.
        /// </summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of entities to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested entities subset.</returns>
        Task<TResourceCollection> GetAsync(int offset, int size, CancellationToken cancellationToken = default);
    }
}
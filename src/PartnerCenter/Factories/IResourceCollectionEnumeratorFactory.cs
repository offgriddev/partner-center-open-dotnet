﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Factories
{
    using Enumerators;
    using Models;

    /// <summary>
    /// Creates resource collection enumerators which can enumerate through resource collections.
    /// </summary>
    /// <typeparam name="T">The collection type.</typeparam>
    public interface IResourceCollectionEnumeratorFactory<T> where T : ResourceBaseWithLinks<StandardResourceCollectionLinks>
    {
        /// <summary>
        /// Creates a resource collection enumerator capable of traversing the input collection.
        /// </summary>
        /// <param name="resourceCollection">The initial resource collection to start from.</param>
        /// <returns>A resource collection enumerator capable of traversing the resource objects within the collection.</returns>
        IResourceCollectionEnumerator<T> Create(T resourceCollection);
    }
}
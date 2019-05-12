﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on availabilities.
    /// </summary>
    public interface IAvailabilityCollection : IPartnerComponent<Tuple<string, string, string>>, IEntireEntityCollectionRetrievalOperations<Availability, ResourceCollection<Availability>>, IEntitySelector<string, IAvailability>
    {
        /// <summary>
        /// Gets the operations that can be applied on availabilities filtered by a specific target segment.
        /// </summary>
        /// <param name="targetSegment">The availability segment filter.</param>
        /// <returns>The availability collection operations by target segment.</returns>
        IAvailabilityCollectionByTargetSegment ByTargetSegment(string targetSegment);
    }
}
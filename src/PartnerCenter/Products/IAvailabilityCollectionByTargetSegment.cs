﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on availabilities for a specific target segment.
    /// </summary>
    public interface IAvailabilityCollectionByTargetSegment : IPartnerComponent<Tuple<string, string, string, string>>, IEntireEntityCollectionRetrievalOperations<Availability, ResourceCollection<Availability>>
    {
    }
}

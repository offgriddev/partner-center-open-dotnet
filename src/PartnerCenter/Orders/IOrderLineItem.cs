﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;

    /// <summary>
    /// Represents the available order line item operations.
    /// </summary>
    public interface IOrderLineItem : IPartnerComponent<Tuple<string, string, int>>
    {
        /// <summary>
        /// Gets the available customer order line item activation link operations.
        /// </summary>
        IOrderLineItemActivationLink ActivationLink { get; }
    }
}
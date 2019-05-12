﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using System;
    using Models.ServiceCosts;

    /// <summary>
    ///  Holds the operations related to a customer's service costs.
    /// </summary>
    public interface IServiceCostsCollection : IPartnerComponent<Tuple<string, ServiceCostsBillingPeriod>>
    {
        /// <summary>
        /// Gets the customer's service cost line items.
        /// </summary>
        IServiceCostLineItemsCollection LineItems { get; }

        /// <summary>
        /// Gets the customer's service cost summary.
        /// </summary>
        IServiceCostSummary Summary { get; }
    }
}
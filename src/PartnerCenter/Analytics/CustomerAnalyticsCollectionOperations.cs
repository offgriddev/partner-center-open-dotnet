﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Analytics
{
    using Extensions;

    /// <summary>
    /// Implements the operations on a Customer analytics collection.
    /// </summary>
    internal class CustomerAnalyticsCollectionOperations : BasePartnerComponent<string>, ICustomerAnalyticsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAnalyticsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer id of the customer</param>
        public CustomerAnalyticsCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));

            Licenses = new CustomerLicensesAnalyticsCollectionOperations(rootPartnerOperations, customerId);
        }

        /// <summary>
        /// Gets the operations on a customer licenses analytics collection.
        /// </summary>
        public ICustomerLicensesAnalyticsCollection Licenses { get; }
    }
}
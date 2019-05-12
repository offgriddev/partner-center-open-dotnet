﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Entitlements
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.Entitlements;

    /// <summary>
    /// Entitlement collection operations implementation class.
    /// </summary>
    internal class EntitlementCollectionOperations : BasePartnerComponent<string>, IEntitlementCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitlementCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        public EntitlementCollectionOperations(IPartner rootPartnerOperations, string customerId)
            : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets the operations that can be applied on entitlements with a given entitlement type.
        /// </summary>
        /// <param name="entitlementType">The Entitlement Type.</param>
        /// <returns>The entitlement collection operations by entitlement type.</returns>
        public IEntitlementCollectionByEntitlementType ByEntitlementType(string entitlementType)
        {
            return new EntitlementCollectionByEntitlementTypeOperations(Partner, Context, entitlementType);
        }

        /// <summary>
        /// Gets entitlement collection.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entitlement collection with the given entitlement type.</returns>
        public async Task<ResourceCollection<Entitlement>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync(false, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets entitlement collection.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entitlement collection with the given entitlement type.</returns>
        public async Task<ResourceCollection<Entitlement>> GetAsync(bool showExpiry, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                 {
                    PartnerService.Instance.Configuration.Apis.GetEntitlements.Parameters.ShowExpiry,
                    showExpiry.ToString(CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Entitlement>>(
              new Uri(
                  string.Format(
                      CultureInfo.InvariantCulture,
                      $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetEntitlements.Path}",
                      Context),
                  UriKind.Relative),
              parameters,
              cancellationToken).ConfigureAwait(false);
        }
    }
}

﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.DevicesDeployment;

    /// <summary>
    /// Implements operations that apply to device collections.
    /// </summary>
    internal class CustomerDevicesCollectionOperations : BasePartnerComponent<string>, ICustomerDeviceCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDevicesCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerDevicesCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Updates the devices with configuration policies.
        /// </summary>
        /// <param name="entity">The device policy update request with devices to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location of the status to track the update.</returns>
        public async Task<string> UpdateAsync(DevicePolicyUpdateRequest entity, CancellationToken cancellationToken = default)
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<DevicePolicyUpdateRequest, string>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateDevicesWithPolicies.Path}",
                        Context),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
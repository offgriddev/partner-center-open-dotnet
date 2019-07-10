﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.DevicesDeployment;
    using Models.JsonConverters;

    /// <summary>
    /// Implements operations that apply to devices batch collection.
    /// </summary>
    internal class DevicesBatchCollectionOperations : BasePartnerComponent<string>, IDevicesBatchCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesBatchCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public DevicesBatchCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a specific customer's devices batch behavior.
        /// </summary>
        /// <param name="id">The devices batch identifier.</param>
        /// <returns>The customer devices batch operations.</returns>
        public IDevicesBatch this[string id] => ById(id);

        /// <summary>
        /// Gets a specific customer's devices batch behavior.
        /// </summary>
        /// <param name="id">The devices batch identifier.</param>
        /// <returns>The customer devices batch operations.</returns>
        public IDevicesBatch ById(string id)
        {
            return new DevicesBatchOperations(Partner, Context, id);
        }

        /// <summary>
        /// Creates a new devices batch along with the devices.
        /// </summary>
        /// <param name="newEntity">The new devices batch.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location to track the status of the create.</returns>
        public async Task<string> CreateAsync(DeviceBatchCreationRequest newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            HttpResponseMessage response = await Partner.ServiceClient.PostAsync<DeviceBatchCreationRequest, HttpResponseMessage>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateDeviceBatch.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);

            return response.Headers.Location != null ? response.Headers.Location.ToString() : string.Empty;
        }

        /// <summary>
        /// Gets devices batches associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of devices batches.</returns>
        public async Task<ResourceCollection<DeviceBatch>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<DeviceBatch>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetDeviceBatches.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<DeviceBatch>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
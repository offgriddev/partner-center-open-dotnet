﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.DevicesDeployment;
    using Models.JsonConverters;

    /// <summary>
    /// Implements operations that apply to device collections.
    /// </summary>
    internal class DeviceCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IDeviceCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="deviceBatchId">The devices batch identifier.</param>
        public DeviceCollectionOperations(IPartner rootPartnerOperations, string customerId, string deviceBatchId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, deviceBatchId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            deviceBatchId.AssertNotEmpty(nameof(deviceBatchId));
        }

        /// <summary>
        /// Gets the customer's device operations.
        /// </summary>
        /// <param name="id">The device identifier.</param>
        /// <returns>The customer's device operations.</returns>
        public IDevice this[string id] => ById(id);

        /// <summary>
        /// Gets the customer's device operations.
        /// </summary>
        /// <param name="id">The device identifier.</param>
        /// <returns>The customer's device operations.</returns>
        public IDevice ById(string id)
        {
            return new DeviceOperations(Partner, Context.Item1, Context.Item2, id);
        }

        /// <summary>
        /// Adds devices to existing devices batch.
        /// </summary>
        /// <param name="newEntity">The new devices to be created.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status of the create request.</returns>
        public async Task<string> CreateAsync(IEnumerable<Device> newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            HttpResponseMessage response = await Partner.ServiceClient.PostAsync<IEnumerable<Device>, HttpResponseMessage>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.AddDevicestoDeviceBatch.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);

            return response.Headers.Location != null ? response.Headers.Location.ToString() : string.Empty;
        }

        /// <summary>
        /// Gets the devices associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of devices.</returns>
        public async Task<ResourceCollection<Device>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Device>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetDevices.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<Device>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
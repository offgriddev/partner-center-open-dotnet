﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.ServiceRequests;

    /// <summary>
    /// Implements operations that can be performed on a single partner's service requests.
    /// </summary>
    internal class PartnerServiceRequestOperations : BasePartnerComponent<Tuple<string, string>>, IServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerServiceRequestOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="serviceRequestId">The service request identifier.</param>
        public PartnerServiceRequestOperations(IPartner rootPartnerOperations, string serviceRequestId)
          : base(rootPartnerOperations, new Tuple<string, string>(serviceRequestId, string.Empty))
        {
            serviceRequestId.AssertNotEmpty(nameof(serviceRequestId));
        }

        /// <summary>
        /// Get the specified service request.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested service request.</returns>
        public async Task<ServiceRequest> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ServiceRequest>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetServiceRequestPartner.Path}",
                        Context.Item1),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the service request.
        /// </summary>
        /// <param name="entity">The service request to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service request that was just updated.</returns>
        public async Task<ServiceRequest> PatchAsync(ServiceRequest entity, CancellationToken cancellationToken = default)
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<ServiceRequest, ServiceRequest>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateServiceRequestPartner.Path}",
                        Context.Item1),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
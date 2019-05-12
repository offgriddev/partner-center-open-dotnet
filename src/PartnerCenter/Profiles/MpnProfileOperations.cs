﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Partners;

    /// <summary>
    /// The Microsoft Partner Network (MPN) profile operations implementation.
    /// </summary>
    internal class MpnProfileOperations : BasePartnerComponent<string>, IMpnProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MpnProfileOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public MpnProfileOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves a partner's MPN profile by identifier.
        /// </summary>
        /// <param name="mpnId">The MPN identifier.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner's MPN profile.</returns>
        public async Task<MpnProfile> GetAsync(string mpnId, CancellationToken cancellationToken = default)
        {
            mpnId.AssertNotEmpty(nameof(mpnId));

            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetMpnProfile.Parameters.MpnId,
                    mpnId
                }
            };

            return await Partner.ServiceClient.GetAsync<MpnProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetMpnProfile.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the MPN profile for the authenticated partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The MPN profile for the authenticated partner.</returns>
        public async Task<MpnProfile> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<MpnProfile>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetMpnProfile.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}

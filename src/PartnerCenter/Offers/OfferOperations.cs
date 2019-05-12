﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Offers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Offers;

    /// <summary>
    /// Single offer operations implementation.
    /// </summary>
    internal class OfferOperations : BasePartnerComponent<Tuple<string, string>>, IOffer
    {
        /// <summary>The offer add on operations.</summary>
        private readonly Lazy<IOfferAddOns> addOns;

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="offerId">The offer Id.</param>
        /// <param name="country">The country on which to base the offer.</param>
        public OfferOperations(IPartner rootPartnerOperations, string offerId, string country)
          : base(rootPartnerOperations, new Tuple<string, string>(offerId, country))
        {
            addOns = new Lazy<IOfferAddOns>(() => new OfferAddOnsOperations(rootPartnerOperations, offerId, country));
        }

        /// <summary>
        /// Gets the operations for the current offer's add-ons.
        /// </summary>
        public IOfferAddOns AddOns => addOns.Value;

        /// <summary>
        /// Retrieves the offer details.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The offer details.</returns>
        public async Task<Offer> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOffer.Parameters.Country,
                    Context.Item2
                }
            };

            return await Partner.ServiceClient.GetAsync<Offer>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOffer.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
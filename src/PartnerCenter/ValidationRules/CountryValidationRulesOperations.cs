﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.ValidationRules
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.ValidationRules;

    /// <summary>
    /// The country validation rules operations implementation.
    /// </summary>
    internal class CountryValidationRulesOperations : BasePartnerComponent<string>, ICountryValidationRules
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryValidationRulesOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="country">The country.</param>
        public CountryValidationRulesOperations(IPartner rootPartnerOperations, string country)
          : base(rootPartnerOperations, country)
        {
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the market specific validation data by country.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The market specific validation data operations.</returns>
        public async Task<CountryValidationRules> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<CountryValidationRules>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCountryValidationRulesByCountry.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.ValidationRules
{
    /// <summary>
    /// Country validation rules collection operations implementation class.
    /// </summary>
    internal class CountryValidationRulesCollectionOperations : BasePartnerComponent<string>, ICountryValidationRulesCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryValidationRulesCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public CountryValidationRulesCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Obtains a specific behavior for country validation rules.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>The country validation rules operations.</returns>
        public ICountryValidationRules ByCountry(string country)
        {
            return new CountryValidationRulesOperations(this.Partner, country);
        }
    }
}

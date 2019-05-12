// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    /// <summary>
    /// Represents the terms for an availability.
    /// </summary>
    public sealed class AvailabilityTerm
    {
        /// <summary>
        /// Gets or sets the description for the term.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ISO standard representation of this term's duration.
        /// </summary>
        /// <remarks>Example: P1M, P1Y, P3Y</remarks>
        public string Duration { get; set; }
    }
}

﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// The billing cycle for a SKU.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum BillingCycleType
    {
        /// <summary>
        /// Enum initializer
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the partner will be charged monthly.
        /// </summary>
        Monthly,

        /// <summary>
        /// Indicates that the partner will be charged annually.
        /// </summary>
        Annual,

        /// <summary>
        /// Indicates that the partner will not be charged.
        /// </summary>
        /// <remarks>
        /// This value is used for trial offers.
        /// </remarks>
        None,

        /// <summary>
        /// Indicates that the partner will be charged one time.
        /// </summary>
        /// <remarks>
        /// This value is used for modern product skus.
        /// </remarks>
        OneTime,
    }
}

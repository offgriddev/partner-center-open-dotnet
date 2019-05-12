﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the available states for a subscription.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum SubscriptionStatus
    {
        /// <summary>
        /// Does not indicate anything, this is used as an initialzer.
        /// </summary>
        None = 0,
        /// <summary>
        /// Indicates the subscription is active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Indicates the subscription is suspended.
        /// </summary>
        Suspended = 2,
        /// <summary>
        /// Indicates the subscription has been deleted.
        /// </summary>
        Deleted = 3
    }
}
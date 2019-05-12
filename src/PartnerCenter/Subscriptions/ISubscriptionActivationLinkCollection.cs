﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Orders;

    /// <summary>
    /// Represents the subscription activation link opreations.
    /// </summary>
    public interface ISubscriptionActivationLinkCollection : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<ResourceCollection<OrderLineItemActivationLink>>
    {
    }
}
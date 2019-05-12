﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Collections.Generic;
    using GenericOperations;
    using Models;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's devices.
    /// </summary>
    public interface IDeviceCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Device, ResourceCollection<Device>>, IEntityCreateOperations<IEnumerable<Device>, string>, IEntitySelector<string, IDevice>
    {
    }
}
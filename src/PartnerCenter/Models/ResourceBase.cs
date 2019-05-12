﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models
{
    public abstract class ResourceBase
    {
        /// <summary>
        /// Intializes a new instance of the <see cref="ResourceBase" /> class.
        /// </summary>
        protected ResourceBase()
        {
            Attributes = new ResourceAttributes(GetType());
        }

        /// <summary>
        /// Initializes a enw instance of the <see cref="ResourceBase" /> class.
        /// </summary>
        /// <param name="objectType">The type of object.</param>
        protected ResourceBase(string objectType) : this()
        {
            Attributes.ObjectType = objectType;
        }

        /// <summary>
        /// Gets or sets the resource attributes.
        /// </summary>
        public ResourceAttributes Attributes { get; }
    }
}
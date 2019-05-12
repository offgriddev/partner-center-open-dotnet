﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models
{
    using System;
    using Newtonsoft.Json;

    public abstract class ResourceBaseWithLinks<TLinks> : ResourceBase where TLinks : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceBaseWithLinks{TLinks}" /> class.
        /// </summary>
        protected ResourceBaseWithLinks()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceBaseWithLinks{TLinks}" /> class.
        /// </summary>
        /// <param name="objectType">The type of object.</param>
        protected ResourceBaseWithLinks(string objectType)
          : base(objectType)
        {
            Links = Activator.CreateInstance<TLinks>();
        }

        /// <summary>
        /// Gets or sets the resource links.
        /// </summary>
        [JsonProperty]
        public TLinks Links { get; set; }
    }
}
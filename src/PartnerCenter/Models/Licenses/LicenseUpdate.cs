﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models.Licenses
{
    using System.Collections.Generic;

    /// <summary>
    /// Model for assigning and removing licenses to user.
    /// </summary>
    public sealed class LicenseUpdate : ResourceBase
    {
        /// <summary>
        /// Gets or sets the list of licenses to be assigned.
        /// </summary>
        public IEnumerable<LicenseAssignment> LicensesToAssign { get; set; }

        /// <summary>
        /// Gets or sets the list of license identifiers to be removed.
        /// </summary>
        public IEnumerable<string> LicensesToRemove { get; set; }

        /// <summary>
        /// Gets list of warnings that occurred during license assignment. 
        /// </summary>
        public IEnumerable<LicenseWarning> LicenseWarnings { get; private set; }
    }
}

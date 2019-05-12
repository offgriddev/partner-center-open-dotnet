﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Relationships
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Query;
    using Models.Relationships;

    /// <summary>
    /// This interface represents the operations that can be done on a partner's relationships.
    /// </summary>
    public interface IRelationshipCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets all the partner relationships.
        /// </summary>
        /// <param name="partnerRelationshipType">The type of partner relationship.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner relationships.</returns>
        Task<ResourceCollection<PartnerRelationship>> GetAsync(PartnerRelationshipType partnerRelationshipType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries partner relationships associated to the partner.
        /// - Only <see cref="SimpleQuery" /> with a <see cref="SimpleFieldFilter" /> is supported.
        /// - This query supports a <see cref="FieldFilterOperation.Substring" /> search of the partner. Check <see cref="PartnerRelationshipSearchField" /> for
        /// the list of supported search fields.
        /// </summary>
        /// <param name="partnerRelationshipType">The type of partner relationship.</param>
        /// <param name="query">A query to apply onto partner relationships. Check <see cref="QueryFactory" /> to see how
        /// to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner relationships that match the given query.</returns>
        Task<ResourceCollection<PartnerRelationship>> QueryAsync(PartnerRelationshipType partnerRelationshipType, IQuery query, CancellationToken cancellationToken = default);
    }
}
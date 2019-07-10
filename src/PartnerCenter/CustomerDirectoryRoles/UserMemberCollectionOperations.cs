﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Query;
    using Models.Roles;

    /// <summary>
    /// User member collection operations class.
    /// </summary>
    internal class UserMemberCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IUserMemberCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMemberCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="roleId">The directory role identifier.</param>
        public UserMemberCollectionOperations(IPartner rootPartnerOperations, string customerId, string roleId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, roleId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            roleId.AssertNotEmpty(nameof(roleId));
        }

        /// <summary>
        /// Get a single user member operations object.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The user member operations instance.</returns>
        public IUserMember this[string id] => ById(id);

        /// <summary>
        /// Get a single user member operations object.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The user member operations instance.</returns>
        public IUserMember ById(string id)
        {
            return new UserMemberOperations(Partner, Context.Item1, Context.Item2, id);
        }

        /// <summary>
        /// Adds customer user to a directory role.
        /// </summary>
        /// <param name="newEntity">The user to add.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer directory role user member.</returns>
        public async Task<UserMember> CreateAsync(UserMember newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<UserMember, UserMember>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.AddUserToCustomerDirectoryRole.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the user members of a customer directory role.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The directory role user memberships.</returns>
        public async Task<SeekBasedResourceCollection<UserMember>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<UserMember>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerDirectoryRoleUserMembers.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<UserMember>(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Queries the user members of a customer directory role.
        /// </summary>
        /// <param name="query">A query to apply onto user member collection.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The directory role user members.</returns>
        public async Task<SeekBasedResourceCollection<UserMember>> QueryAsync(IQuery query, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> headers = null;
            IDictionary<string, string> parameters;

            query.AssertNotNull(nameof(query));

            if (query.Type == QueryType.Seek)
            {
                query.Token.AssertNotNull(nameof(query.Token));

                headers = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetCustomerUsers.AdditionalHeaders.ContinuationToken,
                        query.Token.ToString()
                    }
                };

                parameters = new Dictionary<string, string>
                {
                    {
                        PartnerService.Instance.Configuration.Apis.GetCustomerDirectoryRoleUserMembers.Parameters.SeekOperation,
                        query.SeekOperation.ToString()
                    }
                };
            }
            else
            {
                parameters = new Dictionary<string, string>();

                if (query.Type == QueryType.Indexed)
                {
                    query.PageSize = Math.Max(query.PageSize, 0);

                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerDirectoryRoleUserMembers.Parameters.Size,
                        query.PageSize.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerDirectoryRoleUserMembers.Parameters.Size,
                        "0");
                }
            }

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<UserMember>>(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerDirectoryRoleUserMembers.Path}",
                    Context.Item1,
                    Context.Item2),
                    UriKind.Relative),
                headers,
                parameters,
                new ResourceCollectionConverter<UserMember>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
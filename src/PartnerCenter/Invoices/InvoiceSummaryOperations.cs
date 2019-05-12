﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Invoices;

    /// <summary>
    /// Represents the operations that can be done on an invoice summary.
    /// </summary>
    internal class InvoiceSummaryOperations : BasePartnerComponent<string>, IInvoiceSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummaryOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public InvoiceSummaryOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves summary of the partner's billing information.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The invoice summary.</returns>
        public async Task<InvoiceSummary> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<InvoiceSummary>(
              new Uri(
                  $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoiceSummary.Path}",
                  UriKind.Relative),
              cancellationToken).ConfigureAwait(false);
        }
    }
}
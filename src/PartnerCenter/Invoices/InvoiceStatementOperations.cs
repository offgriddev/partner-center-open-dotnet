﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the operations available on an invoice statement.
    /// </summary>
    internal class InvoiceStatementOperations : BasePartnerComponent<string>, IInvoiceStatement
    {
        /// <summary>
        /// The accept media type for the a PDF file.
        /// </summary>
        private const string PdfAcceptMediaType = "application/pdf";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceStatementOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        public InvoiceStatementOperations(IPartner rootPartnerOperations, string invoiceId)
          : base(rootPartnerOperations, invoiceId)
        {
        }

        /// <summary>
        /// Retrieves the invoice statement. This operation is currently only supported for user based credentials.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The invoice statement.</returns>
        public async Task<Stream> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetFileContentAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoiceStatement.Path}",
                        Context),
                    UriKind.Relative),
                PdfAcceptMediaType,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models.ServiceCosts
{
    using System;

    /// <summary>
    /// Represents a charge incurred by the partner per customer for a given subscription.
    /// </summary>
    public class ServiceCostLineItem : ResourceBase
    {
        /// <summary>
        /// Gets or sets the availability identifier.
        /// </summary>
        public string AvailabilityId { get; set; }

        /// <summary>
        /// Gets or sets the total for this item inclusive of taxes.
        /// </summary>
        public decimal AfterTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the the charge type associated.
        /// </summary>
        /// <value>
        /// Charges:
        ///  PURCHASE_FEE: Initial charge for a subscription.
        ///  CYCLE_FEE: Periodic charges for a subscription.
        /// ConvertResources:
        ///  CANCEL_USAGEFEE: Access usage fee upon cancellation for unpaid usage during the current billing period.
        ///  CYCLE_USAGEFEE: Access usage fee for the current billing period.
        /// PRORATIONS:
        ///  PURCHASE_PRORATE: Prorated fees upon purchase.
        ///  CANCEL_PRORATE: Prorated refund for unused portion of service upon cancellation.
        ///  ACTIVATION_PRORATE: Prorated fees from activation until end of billing period.
        ///  RENEW_PRORATE: Prorated fees upon subscription renewal.
        /// InstanceProrates:
        ///  CANCEL_INSTANCEPRORATE: Prorated charges refunded to the customer when associated seats are changed.
        ///  CYCLE_INSTANCEPRORATE: Prorated charges assessed from the customer when associated seats are changed.
        /// Credits:
        ///  CREDIT: Credit applied to a payment instrument.
        /// Offsets:
        ///  OFFSET_LINEITEM: Partial or whole refund to a line item.
        ///  ONE_TIME_REFUND: One Time Refund processed for the customer.
        ///  TAX_REFUND: Refund due to validation of tax exemption certificate.
        /// Discounts:
        ///  ACTIVATION_DISCOUNT: Discount applied when subscription activated.
        ///  CYCLE_DISCOUNT: Discount applied on periodic charges.
        ///  RENEW_DISCOUNT: Discount applied when subscription renewed.
        ///  CANCEL_DISCOUNT: Charges applied when discounts cancelled.
        /// Usage Based:
        ///  ASSESS USAGE FEE FOR CURRENT CYCLE.
        /// </value>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the costs.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol for the costs.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the discount details.
        /// </summary>
        public string DiscountDetails { get; set; }

        /// <summary>
        /// Gets or sets the end date for the charge.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets invoice number associated with this line item.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the offer name.
        /// </summary>
        public string OfferName { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the total charge for this item before taxes.
        /// </summary>
        public decimal PretaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the publisher identifier.
        /// </summary>
        public string PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the publisher name.
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// Gets or sets the quantity used or purchased.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the reseller MPN identifier.
        /// </summary>
        /// <remarks>
        ///  In the indirect scenarios, this refers to the MPN identifier.
        ///  </remarks>
        public string ResellerMPNId { get; set; }

        /// <summary>
        /// Gets or sets the SKU identifier.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the SKU name.
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the start date for the charge.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the subscription.
        /// </summary>
        public string SubscriptionFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the tax incurred.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Gets or sets the term and billing cycle.
        /// </summary>
        public string TermAndBillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the price per unit.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
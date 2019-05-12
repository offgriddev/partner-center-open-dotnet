﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Customers.Products
{
    using GenericOperations;
    using PartnerCenter.Products;

    /// <summary>
    /// Holds operations that can be performed on products that apply to a given customer.
    /// </summary>
    public interface ICustomerProductCollection : IPartnerComponent<string>, IEntitySelector<string, IProduct>
    {
        /// <summary>
        /// Gets the operations that can be applied on products in a given catalog view and that apply to a given customer.
        /// </summary>
        /// <param name="targetView">The product target view.</param>
        /// <returns>The catalog view operations by customer id and by target view.</returns>
        ICustomerProductCollectionByTargetView ByTargetView(string targetView);
    }
}
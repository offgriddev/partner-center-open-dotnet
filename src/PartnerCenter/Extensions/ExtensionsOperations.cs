﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Extensions
{
    using System;
    using Products;

    /// <summary>
    /// Extensions operations implementation.
    /// </summary>
    internal class ExtensionsOperations : BasePartnerComponent<string>, IExtensions
    {
        /// <summary>
        /// Provides access to the product extensions operations.
        /// </summary>
        private readonly Lazy<IProductExtensions> product;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionsOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public ExtensionsOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
            product = new Lazy<IProductExtensions>(() => new ProductExtensionsOperations(Partner));
        }

        /// <summary>
        /// Gets the product extension operations.
        /// </summary>
        public IProductExtensions Product => product.Value;
    }
}
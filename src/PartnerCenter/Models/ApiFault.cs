﻿// Copyright (c) Isaiah Williams. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.Models
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a failure with the API.
    /// </summary>
    public sealed class ApiFault : ResourceBase
    {
        /// <summary>
        /// Gets or sets the API error code.
        /// </summary>
        [JsonProperty("code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets additional fault information if present.
        /// </summary>
        [JsonProperty("data")]
        public IEnumerable<object> ErrorData { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty("description")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Returns a meaningful summary regarding the API fault.
        /// </summary>
        /// <returns>A meaningful summary regarding the fault.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine().AppendFormat(CultureInfo.InvariantCulture, "Error code: {0}", ErrorCode).AppendLine();
            stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Error message: {0}", ErrorMessage).AppendLine();

            if (ErrorData != null)
            {
                stringBuilder.AppendLine("Error data:");

                foreach (object obj in ErrorData)
                {
                    if (obj != null)
                    {
                        stringBuilder.AppendLine(obj.ToString());
                    }
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The list usages operation response. </summary>
    internal partial class NetworkUsagesListResult
    {
        /// <summary> Initializes a new instance of NetworkUsagesListResult. </summary>
        internal NetworkUsagesListResult()
        {
            Value = new ChangeTrackingList<NetworkUsage>();
        }

        /// <summary> Initializes a new instance of NetworkUsagesListResult. </summary>
        /// <param name="value"> The list network resource usages. </param>
        /// <param name="nextLink"> URL to get the next set of results. </param>
        internal NetworkUsagesListResult(IReadOnlyList<NetworkUsage> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list network resource usages. </summary>
        public IReadOnlyList<NetworkUsage> Value { get; }
        /// <summary> URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}

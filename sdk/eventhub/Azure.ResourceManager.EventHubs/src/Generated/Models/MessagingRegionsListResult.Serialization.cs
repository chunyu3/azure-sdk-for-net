// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Models
{
    public partial class MessagingRegionsListResult
    {
        internal static MessagingRegionsListResult DeserializeMessagingRegionsListResult(JsonElement element)
        {
            Optional<IReadOnlyList<MessagingRegions>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<MessagingRegions> array = new List<MessagingRegions>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MessagingRegions.DeserializeMessagingRegions(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new MessagingRegionsListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}

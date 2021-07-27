// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ProxyOnlyResource
    {
        internal static ProxyOnlyResource DeserializeProxyOnlyResource(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> type = default;
            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new ProxyOnlyResource(id, name.Value, type.Value);
        }
    }
}

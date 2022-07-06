// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class IntegrationRuntimeStatusResult
    {
        internal static IntegrationRuntimeStatusResult DeserializeIntegrationRuntimeStatusResult(JsonElement element)
        {
            Optional<string> name = default;
            IntegrationRuntimeStatus properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    properties = IntegrationRuntimeStatus.DeserializeIntegrationRuntimeStatus(property.Value);
                    continue;
                }
            }
            return new IntegrationRuntimeStatusResult(name.Value, properties);
        }
    }
}

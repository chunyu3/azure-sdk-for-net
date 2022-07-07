// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.HDInsight.Models
{
    public partial class CapabilitiesResult
    {
        internal static CapabilitiesResult DeserializeCapabilitiesResult(JsonElement element)
        {
            Optional<IReadOnlyDictionary<string, VersionsCapability>> versions = default;
            Optional<IReadOnlyDictionary<string, RegionsCapability>> regions = default;
            Optional<IReadOnlyList<string>> features = default;
            Optional<QuotaCapability> quota = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("versions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, VersionsCapability> dictionary = new Dictionary<string, VersionsCapability>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, VersionsCapability.DeserializeVersionsCapability(property0.Value));
                    }
                    versions = dictionary;
                    continue;
                }
                if (property.NameEquals("regions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, RegionsCapability> dictionary = new Dictionary<string, RegionsCapability>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RegionsCapability.DeserializeRegionsCapability(property0.Value));
                    }
                    regions = dictionary;
                    continue;
                }
                if (property.NameEquals("features"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    features = array;
                    continue;
                }
                if (property.NameEquals("quota"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    quota = QuotaCapability.DeserializeQuotaCapability(property.Value);
                    continue;
                }
            }
            return new CapabilitiesResult(Optional.ToDictionary(versions), Optional.ToDictionary(regions), Optional.ToList(features), quota.Value);
        }
    }
}

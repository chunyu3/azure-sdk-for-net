// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.HDInsight.Models
{
    public partial class VirtualNetworkProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Subnet))
            {
                writer.WritePropertyName("subnet");
                writer.WriteStringValue(Subnet);
            }
            writer.WriteEndObject();
        }

        internal static VirtualNetworkProfile DeserializeVirtualNetworkProfile(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> subnet = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("subnet"))
                {
                    subnet = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualNetworkProfile(id.Value, subnet.Value);
        }
    }
}

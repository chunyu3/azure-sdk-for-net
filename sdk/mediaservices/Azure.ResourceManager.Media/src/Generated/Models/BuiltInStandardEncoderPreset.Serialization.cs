// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Media.Models
{
    public partial class BuiltInStandardEncoderPreset : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Configurations))
            {
                writer.WritePropertyName("configurations");
                writer.WriteObjectValue(Configurations);
            }
            writer.WritePropertyName("presetName");
            writer.WriteStringValue(PresetName.ToString());
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static BuiltInStandardEncoderPreset DeserializeBuiltInStandardEncoderPreset(JsonElement element)
        {
            Optional<PresetConfigurations> configurations = default;
            EncoderNamedPreset presetName = default;
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("configurations"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    configurations = PresetConfigurations.DeserializePresetConfigurations(property.Value);
                    continue;
                }
                if (property.NameEquals("presetName"))
                {
                    presetName = new EncoderNamedPreset(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new BuiltInStandardEncoderPreset(odataType, configurations.Value, presetName);
        }
    }
}

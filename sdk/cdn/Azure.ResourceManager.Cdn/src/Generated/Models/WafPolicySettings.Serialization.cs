// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class WafPolicySettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(EnabledState))
            {
                writer.WritePropertyName("enabledState");
                writer.WriteStringValue(EnabledState.Value.ToString());
            }
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode");
                writer.WriteStringValue(Mode.Value.ToString());
            }
            if (Optional.IsDefined(DefaultRedirectUri))
            {
                writer.WritePropertyName("defaultRedirectUrl");
                writer.WriteStringValue(DefaultRedirectUri.AbsoluteUri);
            }
            if (Optional.IsDefined(DefaultCustomBlockResponseStatusCode))
            {
                if (DefaultCustomBlockResponseStatusCode != null)
                {
                    writer.WritePropertyName("defaultCustomBlockResponseStatusCode");
                    writer.WriteStringValue(DefaultCustomBlockResponseStatusCode.Value.ToString());
                }
                else
                {
                    writer.WriteNull("defaultCustomBlockResponseStatusCode");
                }
            }
            if (Optional.IsDefined(DefaultCustomBlockResponseBody))
            {
                writer.WritePropertyName("defaultCustomBlockResponseBody");
                writer.WriteStringValue(DefaultCustomBlockResponseBody);
            }
            writer.WriteEndObject();
        }

        internal static WafPolicySettings DeserializeWafPolicySettings(JsonElement element)
        {
            Optional<PolicyEnabledState> enabledState = default;
            Optional<PolicyMode> mode = default;
            Optional<Uri> defaultRedirectUrl = default;
            Optional<PolicySettingsDefaultCustomBlockResponseStatusCode?> defaultCustomBlockResponseStatusCode = default;
            Optional<string> defaultCustomBlockResponseBody = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabledState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabledState = new PolicyEnabledState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("mode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    mode = new PolicyMode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("defaultRedirectUrl"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        defaultRedirectUrl = null;
                        continue;
                    }
                    defaultRedirectUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("defaultCustomBlockResponseStatusCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        defaultCustomBlockResponseStatusCode = null;
                        continue;
                    }
                    defaultCustomBlockResponseStatusCode = new PolicySettingsDefaultCustomBlockResponseStatusCode(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("defaultCustomBlockResponseBody"))
                {
                    defaultCustomBlockResponseBody = property.Value.GetString();
                    continue;
                }
            }
            return new WafPolicySettings(Optional.ToNullable(enabledState), Optional.ToNullable(mode), defaultRedirectUrl.Value, Optional.ToNullable(defaultCustomBlockResponseStatusCode), defaultCustomBlockResponseBody.Value);
        }
    }
}

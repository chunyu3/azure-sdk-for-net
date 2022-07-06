// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class AutoscaleNotification : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("operation");
            writer.WriteStringValue(Operation.ToString());
            if (Optional.IsDefined(Email))
            {
                writer.WritePropertyName("email");
                writer.WriteObjectValue(Email);
            }
            if (Optional.IsCollectionDefined(Webhooks))
            {
                writer.WritePropertyName("webhooks");
                writer.WriteStartArray();
                foreach (var item in Webhooks)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static AutoscaleNotification DeserializeAutoscaleNotification(JsonElement element)
        {
            MonitorOperationType operation = default;
            Optional<EmailNotification> email = default;
            Optional<IList<WebhookNotification>> webhooks = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("operation"))
                {
                    operation = new MonitorOperationType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("email"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    email = EmailNotification.DeserializeEmailNotification(property.Value);
                    continue;
                }
                if (property.NameEquals("webhooks"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<WebhookNotification> array = new List<WebhookNotification>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WebhookNotification.DeserializeWebhookNotification(item));
                    }
                    webhooks = array;
                    continue;
                }
            }
            return new AutoscaleNotification(operation, email.Value, Optional.ToList(webhooks));
        }
    }
}

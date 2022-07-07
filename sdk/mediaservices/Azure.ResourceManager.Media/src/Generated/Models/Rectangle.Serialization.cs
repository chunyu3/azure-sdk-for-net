// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Media.Models
{
    public partial class Rectangle : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Left))
            {
                writer.WritePropertyName("left");
                writer.WriteStringValue(Left);
            }
            if (Optional.IsDefined(Top))
            {
                writer.WritePropertyName("top");
                writer.WriteStringValue(Top);
            }
            if (Optional.IsDefined(Width))
            {
                writer.WritePropertyName("width");
                writer.WriteStringValue(Width);
            }
            if (Optional.IsDefined(Height))
            {
                writer.WritePropertyName("height");
                writer.WriteStringValue(Height);
            }
            writer.WriteEndObject();
        }

        internal static Rectangle DeserializeRectangle(JsonElement element)
        {
            Optional<string> left = default;
            Optional<string> top = default;
            Optional<string> width = default;
            Optional<string> height = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("left"))
                {
                    left = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("top"))
                {
                    top = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("width"))
                {
                    width = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("height"))
                {
                    height = property.Value.GetString();
                    continue;
                }
            }
            return new Rectangle(left.Value, top.Value, width.Value, height.Value);
        }
    }
}

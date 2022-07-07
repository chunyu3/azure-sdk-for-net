// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class TimeInWeek : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Day))
            {
                writer.WritePropertyName("day");
                writer.WriteStringValue(Day.Value.ToString());
            }
            if (Optional.IsCollectionDefined(HourSlots))
            {
                writer.WritePropertyName("hourSlots");
                writer.WriteStartArray();
                foreach (var item in HourSlots)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static TimeInWeek DeserializeTimeInWeek(JsonElement element)
        {
            Optional<WeekDay> day = default;
            Optional<IList<int>> hourSlots = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("day"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    day = new WeekDay(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hourSlots"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    hourSlots = array;
                    continue;
                }
            }
            return new TimeInWeek(Optional.ToNullable(day), Optional.ToList(hourSlots));
        }
    }
}

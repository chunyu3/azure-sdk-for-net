// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class DataFeedList
    {
        internal static DataFeedList DeserializeDataFeedList(JsonElement element)
        {
            Optional<string> nextLink = default;
            Optional<IReadOnlyList<DataFeedDetail>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<DataFeedDetail> array = new List<DataFeedDetail>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DataFeedDetail.DeserializeDataFeedDetail(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new DataFeedList(nextLink.Value, Optional.ToList(value));
        }

        internal static DataFeedList FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDataFeedList(document.RootElement);
        }
    }
}

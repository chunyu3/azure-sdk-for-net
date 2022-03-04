// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.MetricsAdvisor;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class MetricFeedbackList
    {
        internal static MetricFeedbackList DeserializeMetricFeedbackList(JsonElement element)
        {
            Optional<string> nextLink = default;
            Optional<IReadOnlyList<MetricFeedback>> value = default;
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
                    List<MetricFeedback> array = new List<MetricFeedback>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MetricFeedback.DeserializeMetricFeedback(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new MetricFeedbackList(nextLink.Value, Optional.ToList(value));
        }

        internal static MetricFeedbackList FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMetricFeedbackList(document.RootElement);
        }
    }
}

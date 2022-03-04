// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.AI.MetricsAdvisor;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class MetricFeedbackFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("metricId");
            writer.WriteStringValue(MetricId);
            if (Optional.IsDefined(DimensionFilter))
            {
                writer.WritePropertyName("dimensionFilter");
                writer.WriteObjectValue(DimensionFilter);
            }
            if (Optional.IsDefined(FeedbackType))
            {
                writer.WritePropertyName("feedbackType");
                writer.WriteStringValue(FeedbackType.Value.ToString());
            }
            if (Optional.IsDefined(StartTime))
            {
                writer.WritePropertyName("startTime");
                writer.WriteStringValue(StartTime.Value, "O");
            }
            if (Optional.IsDefined(EndTime))
            {
                writer.WritePropertyName("endTime");
                writer.WriteStringValue(EndTime.Value, "O");
            }
            if (Optional.IsDefined(TimeMode))
            {
                writer.WritePropertyName("timeMode");
                writer.WriteStringValue(TimeMode.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static RequestContent ToRequestContent(MetricFeedbackFilter model)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            return content;
        }
    }
}

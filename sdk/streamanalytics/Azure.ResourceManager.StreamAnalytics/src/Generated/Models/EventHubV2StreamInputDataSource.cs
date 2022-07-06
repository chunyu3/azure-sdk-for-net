// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary> Describes an Event Hub input data source that contains stream data. </summary>
    public partial class EventHubV2StreamInputDataSource : StreamInputDataSource
    {
        /// <summary> Initializes a new instance of EventHubV2StreamInputDataSource. </summary>
        public EventHubV2StreamInputDataSource()
        {
            StreamInputDataSourceType = "Microsoft.EventHub/EventHub";
        }

        /// <summary> Initializes a new instance of EventHubV2StreamInputDataSource. </summary>
        /// <param name="streamInputDataSourceType"> Indicates the type of input data source containing stream data. Required on PUT (CreateOrReplace) requests. </param>
        /// <param name="serviceBusNamespace"> The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace) requests. </param>
        /// <param name="sharedAccessPolicyName"> The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace) requests. </param>
        /// <param name="sharedAccessPolicyKey"> The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests. </param>
        /// <param name="authenticationMode"> Authentication Mode. </param>
        /// <param name="eventHubName"> The name of the Event Hub. Required on PUT (CreateOrReplace) requests. </param>
        /// <param name="partitionCount"> The partition count of the event hub data source. Range 1 - 256. </param>
        /// <param name="consumerGroupName"> The name of an Event Hub Consumer Group that should be used to read events from the Event Hub. Specifying distinct consumer group names for multiple inputs allows each of those inputs to receive the same events from the Event Hub. If not specified, the input uses the Event Hub’s default consumer group. </param>
        /// <param name="prefetchCount"> The number of messages that the message receiver can simultaneously request. </param>
        internal EventHubV2StreamInputDataSource(string streamInputDataSourceType, string serviceBusNamespace, string sharedAccessPolicyName, string sharedAccessPolicyKey, AuthenticationMode? authenticationMode, string eventHubName, int? partitionCount, string consumerGroupName, int? prefetchCount) : base(streamInputDataSourceType)
        {
            ServiceBusNamespace = serviceBusNamespace;
            SharedAccessPolicyName = sharedAccessPolicyName;
            SharedAccessPolicyKey = sharedAccessPolicyKey;
            AuthenticationMode = authenticationMode;
            EventHubName = eventHubName;
            PartitionCount = partitionCount;
            ConsumerGroupName = consumerGroupName;
            PrefetchCount = prefetchCount;
            StreamInputDataSourceType = streamInputDataSourceType ?? "Microsoft.EventHub/EventHub";
        }

        /// <summary> The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace) requests. </summary>
        public string ServiceBusNamespace { get; set; }
        /// <summary> The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace) requests. </summary>
        public string SharedAccessPolicyName { get; set; }
        /// <summary> The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests. </summary>
        public string SharedAccessPolicyKey { get; set; }
        /// <summary> Authentication Mode. </summary>
        public AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary> The name of the Event Hub. Required on PUT (CreateOrReplace) requests. </summary>
        public string EventHubName { get; set; }
        /// <summary> The partition count of the event hub data source. Range 1 - 256. </summary>
        public int? PartitionCount { get; set; }
        /// <summary> The name of an Event Hub Consumer Group that should be used to read events from the Event Hub. Specifying distinct consumer group names for multiple inputs allows each of those inputs to receive the same events from the Event Hub. If not specified, the input uses the Event Hub’s default consumer group. </summary>
        public string ConsumerGroupName { get; set; }
        /// <summary> The number of messages that the message receiver can simultaneously request. </summary>
        public int? PrefetchCount { get; set; }
    }
}

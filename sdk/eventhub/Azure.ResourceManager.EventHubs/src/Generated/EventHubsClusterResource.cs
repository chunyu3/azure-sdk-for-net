// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EventHubs
{
    /// <summary>
    /// A Class representing an EventHubsCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="EventHubsClusterResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetEventHubsClusterResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetEventHubsCluster method.
    /// </summary>
    public partial class EventHubsClusterResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="EventHubsClusterResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _eventHubsClusterClustersClientDiagnostics;
        private readonly ClustersRestOperations _eventHubsClusterClustersRestClient;
        private readonly ClientDiagnostics _configurationClientDiagnostics;
        private readonly ConfigurationRestOperations _configurationRestClient;
        private readonly EventHubsClusterData _data;

        /// <summary> Initializes a new instance of the <see cref="EventHubsClusterResource"/> class for mocking. </summary>
        protected EventHubsClusterResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "EventHubsClusterResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal EventHubsClusterResource(ArmClient client, EventHubsClusterData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="EventHubsClusterResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal EventHubsClusterResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _eventHubsClusterClustersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventHubs", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string eventHubsClusterClustersApiVersion);
            _eventHubsClusterClustersRestClient = new ClustersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, eventHubsClusterClustersApiVersion);
            _configurationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EventHubs", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _configurationRestClient = new ConfigurationRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.EventHub/clusters";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual EventHubsClusterData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the resource description of the specified Event Hubs Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EventHubsClusterResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.Get");
            scope.Start();
            try
            {
                var response = await _eventHubsClusterClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EventHubsClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the resource description of the specified Event Hubs Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventHubsClusterResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.Get");
            scope.Start();
            try
            {
                var response = _eventHubsClusterClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EventHubsClusterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing Event Hubs Cluster. This operation is idempotent.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.Delete");
            scope.Start();
            try
            {
                var response = await _eventHubsClusterClustersRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new EventHubsArmOperation(_eventHubsClusterClustersClientDiagnostics, Pipeline, _eventHubsClusterClustersRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing Event Hubs Cluster. This operation is idempotent.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.Delete");
            scope.Start();
            try
            {
                var response = _eventHubsClusterClustersRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new EventHubsArmOperation(_eventHubsClusterClustersClientDiagnostics, Pipeline, _eventHubsClusterClustersRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Modifies mutable properties on the Event Hubs Cluster. This operation is idempotent.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Update
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The properties of the Event Hubs Cluster which should be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<EventHubsClusterResource>> UpdateAsync(WaitUntil waitUntil, EventHubsClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.Update");
            scope.Start();
            try
            {
                var response = await _eventHubsClusterClustersRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new EventHubsArmOperation<EventHubsClusterResource>(new EventHubsClusterOperationSource(Client), _eventHubsClusterClustersClientDiagnostics, Pipeline, _eventHubsClusterClustersRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Modifies mutable properties on the Event Hubs Cluster. This operation is idempotent.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Update
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The properties of the Event Hubs Cluster which should be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<EventHubsClusterResource> Update(WaitUntil waitUntil, EventHubsClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.Update");
            scope.Start();
            try
            {
                var response = _eventHubsClusterClustersRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new EventHubsArmOperation<EventHubsClusterResource>(new EventHubsClusterOperationSource(Client), _eventHubsClusterClustersClientDiagnostics, Pipeline, _eventHubsClusterClustersRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all Event Hubs Namespace IDs in an Event Hubs Dedicated Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}/namespaces
        /// Operation Id: Clusters_ListNamespaces
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubResource> GetNamespacesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.GetNamespaces");
                scope.Start();
                try
                {
                    var response = await _eventHubsClusterClustersRestClient.ListNamespacesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// List all Event Hubs Namespace IDs in an Event Hubs Dedicated Cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}/namespaces
        /// Operation Id: Clusters_ListNamespaces
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubResource> GetNamespaces(CancellationToken cancellationToken = default)
        {
            Page<SubResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.GetNamespaces");
                scope.Start();
                try
                {
                    var response = _eventHubsClusterClustersRestClient.ListNamespaces(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Replace all specified Event Hubs Cluster settings with those contained in the request body. Leaves the settings not specified in the request body unmodified.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}/quotaConfiguration/default
        /// Operation Id: Configuration_Patch
        /// </summary>
        /// <param name="clusterQuotaConfigurationProperties"> Parameters for creating an Event Hubs Cluster resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterQuotaConfigurationProperties"/> is null. </exception>
        public virtual async Task<Response<ClusterQuotaConfigurationProperties>> PatchConfigurationAsync(ClusterQuotaConfigurationProperties clusterQuotaConfigurationProperties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(clusterQuotaConfigurationProperties, nameof(clusterQuotaConfigurationProperties));

            using var scope = _configurationClientDiagnostics.CreateScope("EventHubsClusterResource.PatchConfiguration");
            scope.Start();
            try
            {
                var response = await _configurationRestClient.PatchAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, clusterQuotaConfigurationProperties, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace all specified Event Hubs Cluster settings with those contained in the request body. Leaves the settings not specified in the request body unmodified.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}/quotaConfiguration/default
        /// Operation Id: Configuration_Patch
        /// </summary>
        /// <param name="clusterQuotaConfigurationProperties"> Parameters for creating an Event Hubs Cluster resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterQuotaConfigurationProperties"/> is null. </exception>
        public virtual Response<ClusterQuotaConfigurationProperties> PatchConfiguration(ClusterQuotaConfigurationProperties clusterQuotaConfigurationProperties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(clusterQuotaConfigurationProperties, nameof(clusterQuotaConfigurationProperties));

            using var scope = _configurationClientDiagnostics.CreateScope("EventHubsClusterResource.PatchConfiguration");
            scope.Start();
            try
            {
                var response = _configurationRestClient.Patch(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, clusterQuotaConfigurationProperties, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get all Event Hubs Cluster settings - a collection of key/value pairs which represent the quotas and settings imposed on the cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}/quotaConfiguration/default
        /// Operation Id: Configuration_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ClusterQuotaConfigurationProperties>> GetConfigurationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _configurationClientDiagnostics.CreateScope("EventHubsClusterResource.GetConfiguration");
            scope.Start();
            try
            {
                var response = await _configurationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get all Event Hubs Cluster settings - a collection of key/value pairs which represent the quotas and settings imposed on the cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}/quotaConfiguration/default
        /// Operation Id: Configuration_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ClusterQuotaConfigurationProperties> GetConfiguration(CancellationToken cancellationToken = default)
        {
            using var scope = _configurationClientDiagnostics.CreateScope("EventHubsClusterResource.GetConfiguration");
            scope.Start();
            try
            {
                var response = _configurationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<EventHubsClusterResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _eventHubsClusterClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new EventHubsClusterResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<EventHubsClusterResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _eventHubsClusterClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new EventHubsClusterResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<EventHubsClusterResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.SetTags");
            scope.Start();
            try
            {
                await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _eventHubsClusterClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new EventHubsClusterResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<EventHubsClusterResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.SetTags");
            scope.Start();
            try
            {
                GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                var originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _eventHubsClusterClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new EventHubsClusterResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<EventHubsClusterResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _eventHubsClusterClustersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new EventHubsClusterResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}
        /// Operation Id: Clusters_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<EventHubsClusterResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _eventHubsClusterClustersClientDiagnostics.CreateScope("EventHubsClusterResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = GetTagResource().Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _eventHubsClusterClustersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new EventHubsClusterResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

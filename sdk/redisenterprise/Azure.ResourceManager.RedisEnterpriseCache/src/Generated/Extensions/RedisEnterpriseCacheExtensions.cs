// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.RedisEnterpriseCache.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RedisEnterpriseCache
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.RedisEnterpriseCache. </summary>
    public static partial class RedisEnterpriseCacheExtensions
    {
        private static SubscriptionResourceExtensionClient GetExtensionClient(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient((client) =>
            {
                return new SubscriptionResourceExtensionClient(client, subscriptionResource.Id);
            }
            );
        }

        /// <summary>
        /// Gets the status of operation.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Cache/locations/{location}/operationsStatus/{operationId}
        /// Operation Id: OperationsStatus_Get
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The region the operation is in. </param>
        /// <param name="operationId"> The operation&apos;s unique identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public static async Task<Response<OperationStatus>> GetRedisEnterpriseOperationsStatusAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            return await GetExtensionClient(subscriptionResource).GetRedisEnterpriseOperationsStatusAsync(location, operationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the status of operation.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Cache/locations/{location}/operationsStatus/{operationId}
        /// Operation Id: OperationsStatus_Get
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The region the operation is in. </param>
        /// <param name="operationId"> The operation&apos;s unique identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public static Response<OperationStatus> GetRedisEnterpriseOperationsStatus(this SubscriptionResource subscriptionResource, AzureLocation location, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            return GetExtensionClient(subscriptionResource).GetRedisEnterpriseOperationsStatus(location, operationId, cancellationToken);
        }

        /// <summary>
        /// Gets all RedisEnterprise clusters in the specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Cache/redisEnterprise
        /// Operation Id: RedisEnterprise_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ClusterResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ClusterResource> GetClustersAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetClustersAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all RedisEnterprise clusters in the specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Cache/redisEnterprise
        /// Operation Id: RedisEnterprise_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ClusterResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ClusterResource> GetClusters(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetClusters(cancellationToken);
        }

        private static ResourceGroupResourceExtensionClient GetExtensionClient(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient((client) =>
            {
                return new ResourceGroupResourceExtensionClient(client, resourceGroupResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of ClusterResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ClusterResources and their operations over a ClusterResource. </returns>
        public static ClusterCollection GetClusters(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetClusters();
        }

        /// <summary>
        /// Gets information about a RedisEnterprise cluster
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redisEnterprise/{clusterName}
        /// Operation Id: RedisEnterprise_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="clusterName"> The name of the RedisEnterprise cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ClusterResource>> GetClusterAsync(this ResourceGroupResource resourceGroupResource, string clusterName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetClusters().GetAsync(clusterName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about a RedisEnterprise cluster
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redisEnterprise/{clusterName}
        /// Operation Id: RedisEnterprise_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="clusterName"> The name of the RedisEnterprise cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="clusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="clusterName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ClusterResource> GetCluster(this ResourceGroupResource resourceGroupResource, string clusterName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetClusters().Get(clusterName, cancellationToken);
        }

        #region ClusterResource
        /// <summary>
        /// Gets an object representing a <see cref="ClusterResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ClusterResource.CreateResourceIdentifier" /> to create a <see cref="ClusterResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ClusterResource" /> object. </returns>
        public static ClusterResource GetClusterResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ClusterResource.ValidateResourceId(id);
                return new ClusterResource(client, id);
            }
            );
        }
        #endregion

        #region DatabaseResource
        /// <summary>
        /// Gets an object representing a <see cref="DatabaseResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DatabaseResource.CreateResourceIdentifier" /> to create a <see cref="DatabaseResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DatabaseResource" /> object. </returns>
        public static DatabaseResource GetDatabaseResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DatabaseResource.ValidateResourceId(id);
                return new DatabaseResource(client, id);
            }
            );
        }
        #endregion

        #region RedisEnterpriseCachePrivateEndpointConnectionResource
        /// <summary>
        /// Gets an object representing a <see cref="RedisEnterpriseCachePrivateEndpointConnectionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RedisEnterpriseCachePrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="RedisEnterpriseCachePrivateEndpointConnectionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RedisEnterpriseCachePrivateEndpointConnectionResource" /> object. </returns>
        public static RedisEnterpriseCachePrivateEndpointConnectionResource GetRedisEnterpriseCachePrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RedisEnterpriseCachePrivateEndpointConnectionResource.ValidateResourceId(id);
                return new RedisEnterpriseCachePrivateEndpointConnectionResource(client, id);
            }
            );
        }
        #endregion
    }
}

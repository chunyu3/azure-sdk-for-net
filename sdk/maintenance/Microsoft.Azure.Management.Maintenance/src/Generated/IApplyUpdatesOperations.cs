// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Maintenance
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ApplyUpdatesOperations operations.
    /// </summary>
    public partial interface IApplyUpdatesOperations
    {
        /// <summary>
        /// Track Updates to resource with parent
        /// </summary>
        /// <remarks>
        /// Track maintenance updates to resource with parent
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='resourceParentType'>
        /// Resource parent type
        /// </param>
        /// <param name='resourceParentName'>
        /// Resource parent identifier
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='applyUpdateName'>
        /// applyUpdate Id
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ApplyUpdate>> GetParentWithHttpMessagesAsync(string resourceGroupName, string resourceParentType, string resourceParentName, string providerName, string resourceType, string resourceName, string applyUpdateName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Track Updates to resource
        /// </summary>
        /// <remarks>
        /// Track maintenance updates to resource
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='applyUpdateName'>
        /// applyUpdate Id
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ApplyUpdate>> GetWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, string applyUpdateName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Apply Updates to resource with parent
        /// </summary>
        /// <remarks>
        /// Apply maintenance updates to resource with parent
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceParentType'>
        /// Resource parent type
        /// </param>
        /// <param name='resourceParentName'>
        /// Resource parent identifier
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ApplyUpdate>> CreateOrUpdateParentWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Apply Updates to resource
        /// </summary>
        /// <remarks>
        /// Apply maintenance updates to resource
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ApplyUpdate>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

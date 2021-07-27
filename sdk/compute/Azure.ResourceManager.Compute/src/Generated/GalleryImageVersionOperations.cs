// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing the operations that can be performed over a specific GalleryImageVersion. </summary>
    public partial class GalleryImageVersionOperations : ResourceOperationsBase<GalleryImageVersion>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private GalleryImageVersionsRestOperations _restClient { get; }

        /// <summary> Initializes a new instance of the <see cref="GalleryImageVersionOperations"/> class for mocking. </summary>
        protected GalleryImageVersionOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="GalleryImageVersionOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal GalleryImageVersionOperations(OperationsBase options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new GalleryImageVersionsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/galleries/images/versions";
        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<GalleryImageVersion>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GalleryImageVersion(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<GalleryImageVersion> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new GalleryImageVersion(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about a gallery image version. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<GalleryImageVersion>> GetAsync(ReplicationStatusTypes? expand, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GalleryImageVersion(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about a gallery image version. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GalleryImageVersion> Get(ReplicationStatusTypes? expand, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, expand, cancellationToken);
                return Response.FromValue(new GalleryImageVersion(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<Location>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<Location> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// <summary> Delete a gallery image version. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Delete");
            scope.Start();
            try
            {
                var operation = await StartDeleteAsync(cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a gallery image version. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Delete");
            scope.Start();
            try
            {
                var operation = StartDelete(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a gallery image version. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<GalleryImageVersionsDeleteOperation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.StartDelete");
            scope.Start();
            try
            {
                var response = await _restClient.DeleteAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return new GalleryImageVersionsDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a gallery image version. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual GalleryImageVersionsDeleteOperation StartDelete(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.StartDelete");
            scope.Start();
            try
            {
                var response = _restClient.Delete(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return new GalleryImageVersionsDeleteOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteRequest(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public async virtual Task<Response<GalleryImageVersion>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GalleryImageVersion(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<GalleryImageVersion> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResourceOperations.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagContainer.CreateOrUpdate(originalTags.Value.Data, cancellationToken);
                var originalResponse = _restClient.Get(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new GalleryImageVersion(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public async virtual Task<Response<GalleryImageVersion>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException($"{nameof(tags)} provided cannot be null.", nameof(tags));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.SetTags");
            scope.Start();
            try
            {
                await TagResourceOperations.DeleteAsync(cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GalleryImageVersion(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public virtual Response<GalleryImageVersion> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException($"{nameof(tags)} provided cannot be null.", nameof(tags));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.SetTags");
            scope.Start();
            try
            {
                TagResourceOperations.Delete(cancellationToken);
                var originalTags = TagResourceOperations.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagContainer.CreateOrUpdate(originalTags.Value.Data, cancellationToken);
                var originalResponse = _restClient.Get(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new GalleryImageVersion(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public async virtual Task<Response<GalleryImageVersion>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GalleryImageVersion(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public virtual Response<GalleryImageVersion> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResourceOperations.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagContainer.CreateOrUpdate(originalTags.Value.Data, cancellationToken);
                var originalResponse = _restClient.Get(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new GalleryImageVersion(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update a gallery image version. </summary>
        /// <param name="galleryImageVersion"> Parameters supplied to the update gallery image version operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersion"/> is null. </exception>
        public async virtual Task<Response<GalleryImageVersion>> UpdateAsync(GalleryImageVersionUpdate galleryImageVersion, CancellationToken cancellationToken = default)
        {
            if (galleryImageVersion == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersion));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Update");
            scope.Start();
            try
            {
                var operation = await StartUpdateAsync(galleryImageVersion, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update a gallery image version. </summary>
        /// <param name="galleryImageVersion"> Parameters supplied to the update gallery image version operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersion"/> is null. </exception>
        public virtual Response<GalleryImageVersion> Update(GalleryImageVersionUpdate galleryImageVersion, CancellationToken cancellationToken = default)
        {
            if (galleryImageVersion == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersion));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.Update");
            scope.Start();
            try
            {
                var operation = StartUpdate(galleryImageVersion, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update a gallery image version. </summary>
        /// <param name="galleryImageVersion"> Parameters supplied to the update gallery image version operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersion"/> is null. </exception>
        public async virtual Task<GalleryImageVersionsUpdateOperation> StartUpdateAsync(GalleryImageVersionUpdate galleryImageVersion, CancellationToken cancellationToken = default)
        {
            if (galleryImageVersion == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersion));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.StartUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.UpdateAsync(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, galleryImageVersion, cancellationToken).ConfigureAwait(false);
                return new GalleryImageVersionsUpdateOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateUpdateRequest(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, galleryImageVersion).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update a gallery image version. </summary>
        /// <param name="galleryImageVersion"> Parameters supplied to the update gallery image version operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersion"/> is null. </exception>
        public virtual GalleryImageVersionsUpdateOperation StartUpdate(GalleryImageVersionUpdate galleryImageVersion, CancellationToken cancellationToken = default)
        {
            if (galleryImageVersion == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersion));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionOperations.StartUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Update(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, galleryImageVersion, cancellationToken);
                return new GalleryImageVersionsUpdateOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateUpdateRequest(Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, galleryImageVersion).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

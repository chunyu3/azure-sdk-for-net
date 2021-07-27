// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of DiskAccess and their operations over a ResourceGroup. </summary>
    public partial class DiskAccessContainer : ResourceContainerBase<DiskAccess, DiskAccessData>
    {
        /// <summary> Initializes a new instance of the <see cref="DiskAccessContainer"/> class for mocking. </summary>
        protected DiskAccessContainer()
        {
        }

        /// <summary> Initializes a new instance of DiskAccessContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DiskAccessContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private DiskAccessesRestOperations _restClient => new DiskAccessesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> Creates or updates a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public virtual Response<DiskAccess> CreateOrUpdate(string diskAccessName, DiskAccessData diskAccess, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(diskAccessName, diskAccess, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public async virtual Task<Response<DiskAccess>> CreateOrUpdateAsync(string diskAccessName, DiskAccessData diskAccess, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(diskAccessName, diskAccess, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public virtual DiskAccessesCreateOrUpdateOperation StartCreateOrUpdate(string diskAccessName, DiskAccessData diskAccess, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, diskAccessName, diskAccess, cancellationToken);
                return new DiskAccessesCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, diskAccessName, diskAccess).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public async virtual Task<DiskAccessesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string diskAccessName, DiskAccessData diskAccess, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, diskAccessName, diskAccess, cancellationToken).ConfigureAwait(false);
                return new DiskAccessesCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, diskAccessName, diskAccess).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<DiskAccess> Get(string diskAccessName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.Get");
            scope.Start();
            try
            {
                if (diskAccessName == null)
                {
                    throw new ArgumentNullException(nameof(diskAccessName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, diskAccessName, cancellationToken: cancellationToken);
                return Response.FromValue(new DiskAccess(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<DiskAccess>> GetAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.Get");
            scope.Start();
            try
            {
                if (diskAccessName == null)
                {
                    throw new ArgumentNullException(nameof(diskAccessName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DiskAccess(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual DiskAccess TryGet(string diskAccessName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.TryGet");
            scope.Start();
            try
            {
                if (diskAccessName == null)
                {
                    throw new ArgumentNullException(nameof(diskAccessName));
                }

                return Get(diskAccessName, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<DiskAccess> TryGetAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.TryGet");
            scope.Start();
            try
            {
                if (diskAccessName == null)
                {
                    throw new ArgumentNullException(nameof(diskAccessName));
                }

                return await GetAsync(diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string diskAccessName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.DoesExist");
            scope.Start();
            try
            {
                if (diskAccessName == null)
                {
                    throw new ArgumentNullException(nameof(diskAccessName));
                }

                return TryGet(diskAccessName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.DoesExist");
            scope.Start();
            try
            {
                if (diskAccessName == null)
                {
                    throw new ArgumentNullException(nameof(diskAccessName));
                }

                return await TryGetAsync(diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all the disk access resources under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DiskAccess" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<DiskAccess> List(CancellationToken cancellationToken = default)
        {
            Page<DiskAccess> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DiskAccess> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disk access resources under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DiskAccess" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<DiskAccess> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DiskAccess>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DiskAccess>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="DiskAccess" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DiskAccessOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="DiskAccess" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DiskAccessOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, DiskAccess, DiskAccessData> Construct() { }
    }
}

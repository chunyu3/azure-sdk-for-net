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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of UpdateDomain and their operations over a CloudService. </summary>
    public partial class UpdateDomainContainer : ResourceContainerBase<UpdateDomain, UpdateDomainData>
    {
        /// <summary> Initializes a new instance of the <see cref="UpdateDomainContainer"/> class for mocking. </summary>
        protected UpdateDomainContainer()
        {
        }

        /// <summary> Initializes a new instance of UpdateDomainContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal UpdateDomainContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private CloudServicesUpdateDomainRestOperations _restClient => new CloudServicesUpdateDomainRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => CloudServiceOperations.ResourceType;

        // Container level operations.

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="updateDomain"> Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<UpdateDomain> Get(string updateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.Get");
            scope.Start();
            try
            {
                if (updateDomain == null)
                {
                    throw new ArgumentNullException(nameof(updateDomain));
                }

                var response = _restClient.GetUpdateDomain(Id.ResourceGroupName, Id.Name, updateDomain, cancellationToken: cancellationToken);
                return Response.FromValue(new UpdateDomain(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="updateDomain"> Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<UpdateDomain>> GetAsync(string updateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.Get");
            scope.Start();
            try
            {
                if (updateDomain == null)
                {
                    throw new ArgumentNullException(nameof(updateDomain));
                }

                var response = await _restClient.GetUpdateDomainAsync(Id.ResourceGroupName, Id.Name, updateDomain, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new UpdateDomain(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateDomain"> Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual UpdateDomain TryGet(string updateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.TryGet");
            scope.Start();
            try
            {
                if (updateDomain == null)
                {
                    throw new ArgumentNullException(nameof(updateDomain));
                }

                return Get(updateDomain, cancellationToken: cancellationToken).Value;
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
        /// <param name="updateDomain"> Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<UpdateDomain> TryGetAsync(string updateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.TryGet");
            scope.Start();
            try
            {
                if (updateDomain == null)
                {
                    throw new ArgumentNullException(nameof(updateDomain));
                }

                return await GetAsync(updateDomain, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="updateDomain"> Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string updateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.DoesExist");
            scope.Start();
            try
            {
                if (updateDomain == null)
                {
                    throw new ArgumentNullException(nameof(updateDomain));
                }

                return TryGet(updateDomain, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateDomain"> Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string updateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.DoesExist");
            scope.Start();
            try
            {
                if (updateDomain == null)
                {
                    throw new ArgumentNullException(nameof(updateDomain));
                }

                return await TryGetAsync(updateDomain, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of all update domains in a cloud service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UpdateDomain" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<UpdateDomain> List(CancellationToken cancellationToken = default)
        {
            Page<UpdateDomain> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListUpdateDomains(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new UpdateDomain(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<UpdateDomain> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListUpdateDomainsNextPage(nextLink, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new UpdateDomain(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets a list of all update domains in a cloud service. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UpdateDomain" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<UpdateDomain> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<UpdateDomain>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListUpdateDomainsAsync(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new UpdateDomain(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<UpdateDomain>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListUpdateDomainsNextPageAsync(nextLink, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new UpdateDomain(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="UpdateDomain" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(UpdateDomainOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="UpdateDomain" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdateDomainContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(UpdateDomainOperations.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, UpdateDomain, UpdateDomainData> Construct() { }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Media
{
    /// <summary>
    /// A class representing a collection of <see cref="AccountFilterResource" /> and their operations.
    /// Each <see cref="AccountFilterResource" /> in the collection will belong to the same instance of <see cref="MediaserviceResource" />.
    /// To get an <see cref="AccountFilterCollection" /> instance call the GetAccountFilters method from an instance of <see cref="MediaserviceResource" />.
    /// </summary>
    public partial class AccountFilterCollection : ArmCollection, IEnumerable<AccountFilterResource>, IAsyncEnumerable<AccountFilterResource>
    {
        private readonly ClientDiagnostics _accountFilterClientDiagnostics;
        private readonly AccountFiltersRestOperations _accountFilterRestClient;

        /// <summary> Initializes a new instance of the <see cref="AccountFilterCollection"/> class for mocking. </summary>
        protected AccountFilterCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AccountFilterCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AccountFilterCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _accountFilterClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Media", AccountFilterResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AccountFilterResource.ResourceType, out string accountFilterApiVersion);
            _accountFilterRestClient = new AccountFiltersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, accountFilterApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != MediaserviceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, MediaserviceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates an Account Filter in the Media Services account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters/{filterName}
        /// Operation Id: AccountFilters_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="filterName"> The Account Filter name. </param>
        /// <param name="data"> The request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="filterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="filterName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AccountFilterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string filterName, AccountFilterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _accountFilterRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filterName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MediaArmOperation<AccountFilterResource>(Response.FromValue(new AccountFilterResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates an Account Filter in the Media Services account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters/{filterName}
        /// Operation Id: AccountFilters_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="filterName"> The Account Filter name. </param>
        /// <param name="data"> The request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="filterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="filterName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AccountFilterResource> CreateOrUpdate(WaitUntil waitUntil, string filterName, AccountFilterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _accountFilterRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filterName, data, cancellationToken);
                var operation = new MediaArmOperation<AccountFilterResource>(Response.FromValue(new AccountFilterResource(Client, response), response.GetRawResponse()));
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
        /// Get the details of an Account Filter in the Media Services account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters/{filterName}
        /// Operation Id: AccountFilters_Get
        /// </summary>
        /// <param name="filterName"> The Account Filter name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="filterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="filterName"/> is null. </exception>
        public virtual async Task<Response<AccountFilterResource>> GetAsync(string filterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));

            using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.Get");
            scope.Start();
            try
            {
                var response = await _accountFilterRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filterName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AccountFilterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the details of an Account Filter in the Media Services account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters/{filterName}
        /// Operation Id: AccountFilters_Get
        /// </summary>
        /// <param name="filterName"> The Account Filter name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="filterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="filterName"/> is null. </exception>
        public virtual Response<AccountFilterResource> Get(string filterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));

            using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.Get");
            scope.Start();
            try
            {
                var response = _accountFilterRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filterName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AccountFilterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List Account Filters in the Media Services account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters
        /// Operation Id: AccountFilters_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AccountFilterResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AccountFilterResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AccountFilterResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _accountFilterRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AccountFilterResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AccountFilterResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _accountFilterRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AccountFilterResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List Account Filters in the Media Services account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters
        /// Operation Id: AccountFilters_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AccountFilterResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AccountFilterResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<AccountFilterResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _accountFilterRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AccountFilterResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AccountFilterResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _accountFilterRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AccountFilterResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters/{filterName}
        /// Operation Id: AccountFilters_Get
        /// </summary>
        /// <param name="filterName"> The Account Filter name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="filterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="filterName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string filterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));

            using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.Exists");
            scope.Start();
            try
            {
                var response = await _accountFilterRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filterName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/accountFilters/{filterName}
        /// Operation Id: AccountFilters_Get
        /// </summary>
        /// <param name="filterName"> The Account Filter name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="filterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="filterName"/> is null. </exception>
        public virtual Response<bool> Exists(string filterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));

            using var scope = _accountFilterClientDiagnostics.CreateScope("AccountFilterCollection.Exists");
            scope.Start();
            try
            {
                var response = _accountFilterRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filterName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AccountFilterResource> IEnumerable<AccountFilterResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AccountFilterResource> IAsyncEnumerable<AccountFilterResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}

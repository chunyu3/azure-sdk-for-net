// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.IoT.DeviceUpdate.Models;
using Azure;

namespace Azure.IoT.DeviceUpdate
{
    public partial class DeviceUpdateClient
    {
        /// <summary> Retrieve operation status. </summary>
        /// <param name="operationId"> Operation identifier. </param>
        /// <param name="accessCondition"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   operationId: string,
        ///   status: &quot;Undefined&quot; | &quot;NotStarted&quot; | &quot;Running&quot; | &quot;Succeeded&quot; | &quot;Failed&quot;,
        ///   updateId: {
        ///     provider: string,
        ///     name: string,
        ///     version: string
        ///   },
        ///   resourceLocation: string,
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [Error],
        ///     innererror: {
        ///       code: string,
        ///       message: string,
        ///       errorDetail: string,
        ///       innerError: InnerError
        ///     },
        ///     occurredDateTime: string (ISO 8601 Format)
        ///   },
        ///   traceId: string,
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   createdDateTime: string (ISO 8601 Format),
        ///   etag: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [Error],
        ///     innererror: {
        ///       code: string,
        ///       message: string,
        ///       errorDetail: string,
        ///       innerError: InnerError
        ///     },
        ///     occurredDateTime: string (ISO 8601 Format)
        ///   }
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual async Task<Response<UpdateOperation>> GetOperationAsync(string operationId, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };
            var ifNoneMatch = new ETag(accessCondition.IfNoneMatch);
            using var scope = ClientDiagnostics.CreateScope("DeviceUpdateClient.GetOperationAsync");
            scope.Start();
            try
            {
                var response = await GetOperationAsync(operationId, ifNoneMatch, requestContext).ConfigureAwait(false);;
                UpdateOperation value = UpdateOperation.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve operation status. </summary>
        /// <param name="operationId"> Operation identifier. </param>
        /// <param name="accessCondition"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   operationId: string,
        ///   status: &quot;Undefined&quot; | &quot;NotStarted&quot; | &quot;Running&quot; | &quot;Succeeded&quot; | &quot;Failed&quot;,
        ///   updateId: {
        ///     provider: string,
        ///     name: string,
        ///     version: string
        ///   },
        ///   resourceLocation: string,
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [Error],
        ///     innererror: {
        ///       code: string,
        ///       message: string,
        ///       errorDetail: string,
        ///       innerError: InnerError
        ///     },
        ///     occurredDateTime: string (ISO 8601 Format)
        ///   },
        ///   traceId: string,
        ///   lastActionDateTime: string (ISO 8601 Format),
        ///   createdDateTime: string (ISO 8601 Format),
        ///   etag: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [Error],
        ///     innererror: {
        ///       code: string,
        ///       message: string,
        ///       errorDetail: string,
        ///       innerError: InnerError
        ///     },
        ///     occurredDateTime: string (ISO 8601 Format)
        ///   }
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual Response<UpdateOperation> GetOperation(string operationId, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };
            var ifNoneMatch = new ETag(accessCondition.IfNoneMatch);
            using var scope = ClientDiagnostics.CreateScope("DeviceUpdateClient.GetOperationAsync");
            scope.Start();
            try
            {
                var response = GetOperation(operationId, ifNoneMatch, requestContext);
                UpdateOperation value = UpdateOperation.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a specific update version. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="provider"> Update provider. </param>
        /// <param name="name"> Update name. </param>
        /// <param name="version"> Update version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [Error],
        ///     innererror: {
        ///       code: string,
        ///       message: string,
        ///       errorDetail: string,
        ///       innerError: InnerError
        ///     },
        ///     occurredDateTime: string (ISO 8601 Format)
        ///   }
        /// }
        /// </code>
        /// </remarks>
        public virtual async Task<Operation> DeleteUpdateValueAsync(WaitUntil waitUntil, string provider, string name, string version, CancellationToken cancellationToken = default)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };
            using var scope = ClientDiagnostics.CreateScope("DeviceUpdateClient.DeleteUpdateValueAsync");
            scope.Start();
            try
            {
                var delOperation = await DeleteUpdateAsync(waitUntil, provider, name, version, requestContext).ConfigureAwait(false);
                //return LowLevelOperationHelpers.Convert(delOperation, r=>(Device)r, ClientDiagnostics, "DeviceUpdateClient.DeleteUpdateValueAsync");
                return delOperation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a specific update version. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="provider"> Update provider. </param>
        /// <param name="name"> Update name. </param>
        /// <param name="version"> Update version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [Error],
        ///     innererror: {
        ///       code: string,
        ///       message: string,
        ///       errorDetail: string,
        ///       innerError: InnerError
        ///     },
        ///     occurredDateTime: string (ISO 8601 Format)
        ///   }
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual Operation DeleteUpdateValue(WaitUntil waitUntil, string provider, string name, string version, CancellationToken cancellationToken = default)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };
            using var scope = ClientDiagnostics.CreateScope("DeviceUpdateClient.DeleteUpdateValue");
            scope.Start();
            try
            {
                var delOperation = DeleteUpdate(waitUntil, provider, name, version, requestContext);
                //return LowLevelOperationHelpers.Convert(delOperation, r => (Device)r, ClientDiagnostics, "DeviceUpdateClient.DeleteUpdateValue");
                return delOperation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.HealthcareApis.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The Private Endpoint Connection resource.
    /// </summary>
    public partial class PrivateEndpointConnectionDescription : PrivateEndpointConnection
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PrivateEndpointConnectionDescription class.
        /// </summary>
        public PrivateEndpointConnectionDescription()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PrivateEndpointConnectionDescription class.
        /// </summary>
        /// <param name="privateLinkServiceConnectionState">A collection of
        /// information about the state of the connection between service
        /// consumer and provider.</param>
        /// <param name="id">Fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}</param>
        /// <param name="name">The name of the resource</param>
        /// <param name="type">The type of the resource. E.g.
        /// "Microsoft.Compute/virtualMachines" or
        /// "Microsoft.Storage/storageAccounts"</param>
        /// <param name="privateEndpoint">The resource of private end
        /// point.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// private endpoint connection resource. Possible values include:
        /// 'Succeeded', 'Creating', 'Deleting', 'Failed'</param>
        /// <param name="systemData">Metadata pertaining to creation and last
        /// modification of the resource.</param>
        public PrivateEndpointConnectionDescription(PrivateLinkServiceConnectionState privateLinkServiceConnectionState, string id = default(string), string name = default(string), string type = default(string), PrivateEndpoint privateEndpoint = default(PrivateEndpoint), string provisioningState = default(string), SystemData systemData = default(SystemData))
            : base(privateLinkServiceConnectionState, id, name, type, privateEndpoint, provisioningState)
        {
            SystemData = systemData;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets metadata pertaining to creation and last modification
        /// of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "systemData")]
        public SystemData SystemData { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}

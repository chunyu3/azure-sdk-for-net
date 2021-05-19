// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Representation of a managed Cassandra cluster.
    /// </summary>
    public partial class ClusterResource : ARMResourceProperties
    {
        /// <summary>
        /// Initializes a new instance of the ClusterResource class.
        /// </summary>
        public ClusterResource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ClusterResource class.
        /// </summary>
        /// <param name="id">The unique resource identifier of the ARM
        /// resource.</param>
        /// <param name="name">The name of the ARM resource.</param>
        /// <param name="type">The type of Azure resource.</param>
        /// <param name="location">The location of the resource group to which
        /// the resource belongs.</param>
        /// <param name="properties">Properties of a managed Cassandra
        /// cluster.</param>
        public ClusterResource(string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), ManagedServiceIdentity identity = default(ManagedServiceIdentity), ClusterResourceProperties properties = default(ClusterResourceProperties))
            : base(id, name, type, location, tags, identity)
        {
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets properties of a managed Cassandra cluster.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public ClusterResourceProperties Properties { get; set; }

    }
}

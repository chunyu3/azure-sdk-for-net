// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The properties for updating the platform configuration. </summary>
    public partial class PlatformUpdateParameters
    {
        /// <summary> Initializes a new instance of PlatformUpdateParameters. </summary>
        public PlatformUpdateParameters()
        {
        }

        /// <summary> The operating system type required for the run. </summary>
        public O? OS { get; set; }
        /// <summary> The OS architecture. </summary>
        public Architecture? Architecture { get; set; }
        /// <summary> Variant of the CPU. </summary>
        public Variant? Variant { get; set; }
    }
}

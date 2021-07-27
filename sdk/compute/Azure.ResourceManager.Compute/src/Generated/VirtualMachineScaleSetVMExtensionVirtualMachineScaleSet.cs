// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A Class representing a VirtualMachineScaleSetVMExtensionVirtualMachineScaleSet along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineScaleSetVMExtensionVirtualMachineScaleSet : VirtualMachineScaleSetVMExtensionVirtualMachineScaleSetOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetVMExtensionVirtualMachineScaleSet"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVMExtensionVirtualMachineScaleSet() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetVMExtensionVirtualMachineScaleSet"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVMExtensionVirtualMachineScaleSet(OperationsBase options, VirtualMachineScaleSetVMExtensionData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineScaleSetVMExtensionData. </summary>
        public virtual VirtualMachineScaleSetVMExtensionData Data { get; private set; }
    }
}

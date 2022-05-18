// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.IoT.DeviceUpdate.Models
{
    /// <summary> Deployment device status. </summary>
    public partial class DeploymentDeviceState
    {
        /// <summary> Initializes a new instance of DeploymentDeviceState. </summary>
        /// <param name="deviceId"> Device identity. </param>
        /// <param name="retryCount"> The number of times this deployment has been retried on this device. </param>
        /// <param name="movedOnToNewDeployment"> Boolean flag indicating whether this device is in a newer deployment and can no longer retry this deployment. </param>
        /// <param name="deviceState"> Deployment device state. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deviceId"/> is null. </exception>
        internal DeploymentDeviceState(string deviceId, int retryCount, bool movedOnToNewDeployment, DeviceDeploymentState deviceState)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            DeviceId = deviceId;
            RetryCount = retryCount;
            MovedOnToNewDeployment = movedOnToNewDeployment;
            DeviceState = deviceState;
        }

        /// <summary> Initializes a new instance of DeploymentDeviceState. </summary>
        /// <param name="deviceId"> Device identity. </param>
        /// <param name="moduleId"> Device module identity. </param>
        /// <param name="retryCount"> The number of times this deployment has been retried on this device. </param>
        /// <param name="movedOnToNewDeployment"> Boolean flag indicating whether this device is in a newer deployment and can no longer retry this deployment. </param>
        /// <param name="deviceState"> Deployment device state. </param>
        internal DeploymentDeviceState(string deviceId, string moduleId, int retryCount, bool movedOnToNewDeployment, DeviceDeploymentState deviceState)
        {
            DeviceId = deviceId;
            ModuleId = moduleId;
            RetryCount = retryCount;
            MovedOnToNewDeployment = movedOnToNewDeployment;
            DeviceState = deviceState;
        }

        /// <summary> Device identity. </summary>
        public string DeviceId { get; }
        /// <summary> Device module identity. </summary>
        public string ModuleId { get; }
        /// <summary> The number of times this deployment has been retried on this device. </summary>
        public int RetryCount { get; }
        /// <summary> Boolean flag indicating whether this device is in a newer deployment and can no longer retry this deployment. </summary>
        public bool MovedOnToNewDeployment { get; }
        /// <summary> Deployment device state. </summary>
        public DeviceDeploymentState DeviceState { get; }
    }
}

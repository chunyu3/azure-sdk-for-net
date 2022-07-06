// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> uri-file data version entity. </summary>
    public partial class UriFileDataVersion : DataVersionProperties
    {
        /// <summary> Initializes a new instance of UriFileDataVersion. </summary>
        /// <param name="dataUri"> [Required] Uri of the data. Usage/meaning depends on Microsoft.MachineLearning.ManagementFrontEnd.Contracts.V20220201Preview.Assets.DataVersionBase.DataType. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataUri"/> is null. </exception>
        public UriFileDataVersion(Uri dataUri) : base(dataUri)
        {
            if (dataUri == null)
            {
                throw new ArgumentNullException(nameof(dataUri));
            }

            DataType = DataType.UriFile;
        }

        /// <summary> Initializes a new instance of UriFileDataVersion. </summary>
        /// <param name="description"> The asset description text. </param>
        /// <param name="properties"> The asset property dictionary. </param>
        /// <param name="tags"> Tag dictionary. Tags can be added, removed, and updated. </param>
        /// <param name="isAnonymous"> If the name version are system generated (anonymous registration). </param>
        /// <param name="isArchived"> Is the asset archived?. </param>
        /// <param name="dataType"> [Required] Specifies the type of data. </param>
        /// <param name="dataUri"> [Required] Uri of the data. Usage/meaning depends on Microsoft.MachineLearning.ManagementFrontEnd.Contracts.V20220201Preview.Assets.DataVersionBase.DataType. </param>
        internal UriFileDataVersion(string description, IDictionary<string, string> properties, IDictionary<string, string> tags, bool? isAnonymous, bool? isArchived, DataType dataType, Uri dataUri) : base(description, properties, tags, isAnonymous, isArchived, dataType, dataUri)
        {
            DataType = dataType;
        }
    }
}

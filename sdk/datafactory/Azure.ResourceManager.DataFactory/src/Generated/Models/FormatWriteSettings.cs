// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary>
    /// Format write settings.
    /// Please note <see cref="FormatWriteSettings"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AvroWriteSettings"/>, <see cref="JsonWriteSettings"/>, <see cref="OrcWriteSettings"/>, <see cref="ParquetWriteSettings"/> and <see cref="DelimitedTextWriteSettings"/>.
    /// </summary>
    public partial class FormatWriteSettings
    {
        /// <summary> Initializes a new instance of FormatWriteSettings. </summary>
        public FormatWriteSettings()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of FormatWriteSettings. </summary>
        /// <param name="formatWriteSettingsType"> The write setting type. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal FormatWriteSettings(string formatWriteSettingsType, IDictionary<string, BinaryData> additionalProperties)
        {
            FormatWriteSettingsType = formatWriteSettingsType;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> The write setting type. </summary>
        internal string FormatWriteSettingsType { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties { get; }
    }
}

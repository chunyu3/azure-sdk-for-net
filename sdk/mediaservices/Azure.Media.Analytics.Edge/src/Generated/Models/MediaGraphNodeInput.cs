// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary> Represents the input to any node in a media graph. </summary>
    public partial class MediaGraphNodeInput
    {
        /// <summary> Initializes a new instance of MediaGraphNodeInput. </summary>
        /// <param name="nodeName"> The name of another node in the media graph, the output of which is used as input to this node. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nodeName"/> is null. </exception>
        public MediaGraphNodeInput(string nodeName)
        {
            if (nodeName == null)
            {
                throw new ArgumentNullException(nameof(nodeName));
            }

            NodeName = nodeName;
            OutputSelectors = new ChangeTrackingList<MediaGraphOutputSelector>();
        }

        /// <summary> Initializes a new instance of MediaGraphNodeInput. </summary>
        /// <param name="nodeName"> The name of another node in the media graph, the output of which is used as input to this node. </param>
        /// <param name="outputSelectors"> Allows for the selection of particular streams from another node. </param>
        internal MediaGraphNodeInput(string nodeName, IList<MediaGraphOutputSelector> outputSelectors)
        {
            NodeName = nodeName;
            OutputSelectors = outputSelectors;
        }

        /// <summary> The name of another node in the media graph, the output of which is used as input to this node. </summary>
        public string NodeName { get; set; }
        /// <summary> Allows for the selection of particular streams from another node. </summary>
        public IList<MediaGraphOutputSelector> OutputSelectors { get; }
    }
}

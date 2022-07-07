// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Media.Models
{
    /// <summary> Class to specify which protocols are enabled. </summary>
    public partial class EnabledProtocols
    {
        /// <summary> Initializes a new instance of EnabledProtocols. </summary>
        /// <param name="download"> Enable Download protocol or not. </param>
        /// <param name="dash"> Enable DASH protocol or not. </param>
        /// <param name="hls"> Enable HLS protocol or not. </param>
        /// <param name="smoothStreaming"> Enable SmoothStreaming protocol or not. </param>
        public EnabledProtocols(bool download, bool dash, bool hls, bool smoothStreaming)
        {
            Download = download;
            Dash = dash;
            Hls = hls;
            SmoothStreaming = smoothStreaming;
        }

        /// <summary> Enable Download protocol or not. </summary>
        public bool Download { get; set; }
        /// <summary> Enable DASH protocol or not. </summary>
        public bool Dash { get; set; }
        /// <summary> Enable HLS protocol or not. </summary>
        public bool Hls { get; set; }
        /// <summary> Enable SmoothStreaming protocol or not. </summary>
        public bool SmoothStreaming { get; set; }
    }
}

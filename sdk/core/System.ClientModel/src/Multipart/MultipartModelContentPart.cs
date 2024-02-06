// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel
{
    /// <summary>
    /// A content part of multipart content.
    /// </summary>
    public class MultipartModelContentPart
    {
        /// <summary> The request content of this part. </summary>
        public readonly object Content;
        /// <summary> The headers of this content part. </summary>
        public Dictionary<string, string> Headers;

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartContentPart"/> class.
        ///  </summary>
        ///  <param name="content">The request content.</param>
        /// <param name="headers">The headers of this content part.</param>
        public MultipartModelContentPart(object content, Dictionary<string, string> headers)
        {
            Content = content;
            Headers = headers;
        }
    }
}

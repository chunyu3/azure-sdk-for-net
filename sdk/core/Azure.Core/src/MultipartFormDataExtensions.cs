// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Azure.Core
{
    internal static class MultipartFormDataExtensions
    {
        /// <summary>
        ///  To RequestContent
        /// </summary>
        public static RequestContent ToRequestContent(this MultipartFormData multipart)
        {
            return new MultipartRequestContent(multipart);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A request content in multipart/form-data format.
    /// </summary>
    public class MultipartFormDataBinaryContent: MultipartBinaryContent
    {
        #region Fields

        private const string FormData = "form-data";

        #endregion Fields

        #region Construction
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataBinaryContent"/> class.
        /// </summary>
        public MultipartFormDataBinaryContent() : base(FormData)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataBinaryContent"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartFormDataBinaryContent(string boundary) : base(FormData, boundary)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormDataBinaryContent"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        public MultipartFormDataBinaryContent(string boundary, IReadOnlyList<MultipartContent> nestedContent) : base(FormData, boundary, nestedContent)
        { }
        #endregion Construction
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        public override void Add(MultipartContent part) => AddInternal(part, null, null);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        public void Add(MultipartContent part, string name) => AddInternal(part, name, null);

        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        public void Add(MultipartContent part, string name, string fileName)
        {
            AddInternal(part, name, fileName);
        }
        private void AddInternal(MultipartContent part, string? name, string? fileName)
        {
            if (!part.Headers.ContainsKey("Content-Disposition"))
            {
                var value = FormData;

                if (name != null)
                {
                    value = value + "; name=" + name;
                }
                if (fileName != null)
                {
                    value = value + "; filename=" + fileName;
                }

                part.Headers.Add("Content-Disposition", value);
            }
            if (!part.Headers.ContainsKey("Content-Type"))
            {
                var value = part.ContentType;
                if (value != null)
                {
                    part.Headers.Add("Content-Type", value);
                }
            }
            base.Add(part);
        }
    }
}

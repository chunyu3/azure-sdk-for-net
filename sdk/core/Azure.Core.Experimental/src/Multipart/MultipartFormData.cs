// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

#nullable disable
namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A request content in multipart/form-data format.
    /// </summary>
    public class MultipartFormData : Multipart
    {
        #region Fields

        private const string FormData = "form-data";

        #endregion Fields

        #region Construction
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        public MultipartFormData() : base(FormData)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartFormData(string boundary) : base(FormData, boundary)
        { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFormData"/> class.
        /// </summary>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        public MultipartFormData(string boundary, IReadOnlyList<MultipartContent> nestedContent) : base(FormData, boundary, nestedContent)
        { }
        #endregion Construction
        /// <summary>
        /// Creates an instance of <see cref="MultipartFormData"/> that wraps a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="content">The <see cref="BinaryData"/> to use.</param>
        /// <param name="contentType">The content type of the data.</param>
        /// <returns>An instance of <see cref="MultipartFormData"/> that wraps a <see cref="BinaryData"/>.</returns>
        public static MultipartFormData Create(BinaryData content, string contentType)
        {
            if (!GetBoundary(contentType, out string subType, out string boundary) ||
                !subType.Equals(FormData))
            {
                throw new ArgumentException("invalid content type.", nameof(contentType));
            }
            return new MultipartFormData(boundary, Read(content, FormData, boundary));
        }
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        public override void Add(BinaryContent content) => AddInternal(content, null, null, null);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        public void Add(BinaryContent content, string name) => AddInternal(content, null, name, null);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        public void Add(BinaryContent content, string name, string fileName) => AddInternal(content, null, name, fileName);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="headers">The headers for the request content to add to the collection.</param>
        public override void Add(BinaryContent content, Dictionary<string, string> headers) => AddInternal(content, headers, null, null);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="headers">The headers for the request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        public void Add(BinaryContent content, Dictionary<string, string> headers, string name)
        {
            AddInternal(content, headers, name, null);
        }
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        /// <param name="headers">The headers for the request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        public void Add(BinaryContent content, Dictionary<string, string> headers, string name, string fileName)
        {
            AddInternal(content, headers, name, fileName);
        }
        private void AddInternal(BinaryContent content, Dictionary<string, string> headers, string name, string fileName)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }
            if (!headers.ContainsKey("Content-Disposition"))
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

                headers.Add("Content-Disposition", value);
            }
            base.Add(content, headers);
        }

        /// <summary>
        ///  To BinaryContent
        /// </summary>
        public BinaryContent ToBinaryContent()
        {
            return new MultipartBinaryContent(this);
        }
        /// <summary>
        ///  To RequestContent
        /// </summary>
        public RequestContent ToRequestContent()
        {
            return new MultipartRequestContent(this);
        }
    }
}

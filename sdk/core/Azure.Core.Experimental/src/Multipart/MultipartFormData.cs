// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#nullable disable
namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A request content in multipart/form-data format.
    /// </summary>
    public class MultipartFormData : Multipart, IPersistableModel<MultipartFormData>
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
        public MultipartFormData(string boundary, IReadOnlyList<MultipartBinaryContent> nestedContent) : base(FormData, boundary, nestedContent)
        { }
        #endregion Construction
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        public override void Add(MultipartBinaryContent part) => AddInternal(part, null, null);
        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        public void Add(MultipartBinaryContent part, string name) => AddInternal(part, name, null);

        /// <summary>
        ///  Add a content part.
        /// </summary>
        /// <param name="part">The Request content to add to the collection.</param>
        /// <param name="name">The name for the request content to add.</param>
        /// <param name="fileName">The file name for the request content to add to the collection.</param>
        public void Add(MultipartBinaryContent part, string name, string fileName)
        {
            AddInternal(part, name, fileName);
        }
        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellationToken">To cancellation token to use.</param>
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            await WriteToStreamAsync(stream, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellationToken">To cancellation token to use.</param>
        public override void WriteTo(Stream stream, CancellationToken cancellationToken)
        {
            WriteToStream(stream, cancellationToken);
        }
        /// <summary>
        /// Attempts to compute the length of the underlying body content, if available.
        /// </summary>
        /// <param name="length">The length of the underlying data.</param>
        public override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }
        /// <inheritdoc/>
        public override void Dispose()
        {
        }
        /// <summary>
        ///  Combine all the parts to BinaryData Content.
        /// </summary>
        // for-each content
        // write "--" + boundary
        // for-each content header
        // write header: header-value
        // write content.WriteTo[Async]
        // write "--" + boundary + "--"
        BinaryData IPersistableModel<MultipartFormData>.Write(ModelReaderWriterOptions options)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            return ToBinaryData();
        }
        MultipartFormData IPersistableModel<MultipartFormData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(data));
            }
            string MultipartContentTypePrefix = $"multipart/{_subtype}; boundary=";
            string contentType = data.MediaType;
            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentException("Missing content type", nameof(data));
            }
            if (contentType == null || !contentType.StartsWith(MultipartContentTypePrefix, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid content type", nameof(data));
            }
            if (!GetBoundary(contentType, out _, out string boundary))
            {
                throw new ArgumentException("Missing boundary", nameof(data));
            }
            return new MultipartFormData(boundary, Read(data, FormData, boundary));
        }
        private void AddInternal(MultipartBinaryContent part, string name, string fileName)
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
        string IPersistableModel<MultipartFormData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MPFD";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A body piece of multipart content.
    /// </summary>
    public class MultipartContent: BinaryContent
    {
        private const string CrLf = "\r\n";
        private const int BufferSize = 1024;
        /// <summary> The request content of this body piece. </summary>
        public BinaryContent Content { get; }
        /// <summary> The headers of this body piece. </summary>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartBinaryContent"/> class.
        ///  </summary>
        ///  <param name="content">The content of the body part.</param>
        /// <param name="headers">The headers of this body part.</param>
        public MultipartContent(BinaryContent content, IDictionary<string, string>? headers = null)
        {
            Content = content;
            Headers = headers ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellationToken">To cancellation token to use.</param>
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            await WriteHeadersToStreamAsync(stream, cancellationToken).ConfigureAwait(false);
            await Content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            /*
            byte[] crlf = Encoding.UTF8.GetBytes(CrLf);
            await stream.WriteAsync(crlf, 0, crlf.Length, cancellationToken).ConfigureAwait(false);
            */
        }

        /// <summary>
        /// Writes contents of this object to an instance of <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cancellationToken">To cancellation token to use.</param>
        public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
        {
            WriteHeadersToStream(stream);
            Content.WriteTo(stream, cancellationToken);
            /*
            byte[] crlf = Encoding.UTF8.GetBytes(CrLf);
            stream.Write(crlf, 0, crlf.Length);
            */
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

        private void WriteHeadersToStream(Stream stream)
        {
            foreach (var header in Headers)
            {
                string headerString = $"{header.Key}: {header.Value}{CrLf}";
                byte[] headerBytes = Encoding.UTF8.GetBytes(headerString);
                stream.Write(headerBytes, 0, headerBytes.Length);
            }
            byte[] crlf = Encoding.UTF8.GetBytes(CrLf);
            stream.Write(crlf, 0, crlf.Length);
        }

        private async Task WriteHeadersToStreamAsync(Stream stream, CancellationToken cancellation)
        {
            foreach (var header in Headers)
            {
                string headerString = $"{header.Key}: {header.Value}{CrLf}";
                byte[] headerBytes = Encoding.UTF8.GetBytes(headerString);
                await stream.WriteAsync(headerBytes, 0, headerBytes.Length, cancellation).ConfigureAwait(false);
            }
            byte[] crlf = Encoding.UTF8.GetBytes(CrLf);
            await stream.WriteAsync(crlf, 0, crlf.Length, cancellation).ConfigureAwait(false);
        }
    }
}

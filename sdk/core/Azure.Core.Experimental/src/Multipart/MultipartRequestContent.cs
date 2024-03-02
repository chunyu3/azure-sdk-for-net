// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ClientModel.Primitives;

namespace Azure.Core
{
    /// <summary>
    ///  Provides a container for content encoded using multipart/form-data MIME type.
    /// </summary>
    public sealed class MultipartRequestContent : RequestContent
    {
        private Multipart _content;

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartRequestContent"/> class.
        ///  </summary>
        public MultipartRequestContent(Multipart content)
        {
            _content = content;
            ContentType = content.ContentType;
        }
        /// <inheritdoc/>
        public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
        {
            _content.WriteTo(stream, cancellationToken);
        }
        /// <inheritdoc/>
        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
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
    }
}

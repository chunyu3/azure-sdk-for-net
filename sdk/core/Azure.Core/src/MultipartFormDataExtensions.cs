// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace Azure.Core
{
    /// <summary>
    /// A request content in multipart format.
    /// </summary>
    public static class MultipartFormDataExtensions
    {
        /// <summary>
        ///  Convert to RequestContent <see cref="RequestContent"/> instance.
        /// </summary>
        public static RequestContent ToStreamRequestContent(this MultipartFormData multipart)
        {
            MemoryStream stream = new MemoryStream();
            string? contentType = null;
            multipart.WriteToStream(stream, ref contentType);
            stream.Position = 0;
            RequestContent content = RequestContent.Create(stream);
            if (contentType != null)
            {
                content.ContentType = contentType;
            }
            return content;
        }
        /// <summary>
        ///  Convert to RequestContent <see cref="RequestContent"/> instance.
        /// </summary>
        public static RequestContent ToPreAllocatedStreamRequestContent(this MultipartFormData multipart)
        {
            long length = 0;
            multipart.TryComputeLength(out length);
            if (length <= 0)
            {
                throw new InvalidOperationException("The length of the content cannot be computed.");
            }
            MemoryStream stream = new MemoryStream((int)length);
            string? contentType = null;
            multipart.WriteToStream(stream, ref contentType);
            stream.Position = 0;
            RequestContent content = RequestContent.Create(stream);
            if (contentType != null)
            {
                content.ContentType = contentType;
            }
            return content;
        }
        /// <summary>
        ///  Convert to RequestContent <see cref="RequestContent"/> instance.
        /// </summary>
        public static RequestContent ToRequestContent(this MultipartFormData multipart)
        {
            BinaryData data = multipart.ToContent();
            RequestContent content = RequestContent.Create(data);
            if (data.MediaType != null)
            {
                content.ContentType = data.MediaType;
            }
            return content;
        }
        /// <summary>
        ///  Convert to RequestContent <see cref="RequestContent"/> instance.
        /// </summary>
        public static RequestContent ToRequestContent2(this MultipartFormData multipart)
        {
            BinaryData data = multipart.ToContent2();
            RequestContent content = RequestContent.Create(data);
            if (data.MediaType != null)
            {
                content.ContentType = data.MediaType;
            }
            return content;
        }
        /// <summary>
        ///  Convert to RequestContent <see cref="RequestContent"/> instance.
        /// </summary>
        public static RequestContent ToRequestContentFromBytes(this MultipartFormData multipart)
        {
            BinaryData data = multipart.ToContentBytes();
            RequestContent content = RequestContent.Create(data);
            if (data.MediaType != null)
            {
                content.ContentType = data.MediaType;
            }
            return content;
        }
        /// <summary>
        ///  Convert to RequestContent <see cref="RequestContent"/> instance.
        /// </summary>
        public static RequestContent ToBinaryDataAsStreamRequestContent(this MultipartFormData multipart)
        {
            BinaryData data = multipart.ToContent();
            RequestContent content = RequestContent.Create(data.ToStream());
            if (data.MediaType != null)
            {
                content.ContentType = data.MediaType;
            }
            return content;
        }
        /// <summary>
        ///  Creates an instance of <see cref="RequestContent"/> that wraps a IPersistableModel/>.
        /// </summary>
        /// <param name="IModel">The model to use.</param>
        /// <returns>An instance of <see cref="RequestContent"/> that wraps a IPersistableModel.</returns>
        public static RequestContent Create<T>(IPersistableModel<T> IModel)
        {
            return RequestContent.Create(IModel, ModelReaderWriterOptions.MultipartFormData);
        }
    }
}

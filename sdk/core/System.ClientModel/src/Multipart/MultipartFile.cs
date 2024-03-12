// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives
{
    /// <summary>
    ///  Provides a container for file used in Multipart.
    /// </summary>
    public class MultipartFile
    {
        /// <summary> The MIME type of the file content. </summary>
        public string ContentType { get; } = "application/octet-stream";
        /// <summary> The name of the file. </summary>
        public string? FileName { get; }
        /// <summary> The file content. </summary>
        public BinaryData? Content { get; }
        /// <summary> The file path. </summary>
        public string? FilePath { get; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFile"/> class.
        ///  <param name="content">The file content.</param>
        ///  </summary>
        public MultipartFile(BinaryData content)
        {
            Content = content;
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFile"/> class.
        ///  <param name="filePath">The file path.</param>
        ///  </summary>
        public MultipartFile(string filePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFile"/> class.
        ///  <param name="content">The file content.</param>
        ///  <param name="contentType">The MIME type of the file content.</param>
        ///  </summary>
        public MultipartFile(BinaryData content, string contentType) : this(content)
        {
            ContentType = contentType;
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFile"/> class.
        ///  <param name="filePath">The file path.</param>
        ///  <param name="contentType">The MIME type of the file content.</param>
        ///  </summary>
        public MultipartFile(string filePath, string contentType) : this(filePath)
        {
            ContentType = contentType;
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFile"/> class.
        ///  </summary>
        public MultipartFile(BinaryData content, string contentType, string fileName) : this(content, contentType)
        {
            FileName = fileName;
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartFile"/> class.
        ///  </summary>
        public MultipartFile(string filePath, string contentType, string fileName) : this(filePath, contentType)
        {
            FileName = fileName;
        }
    }
}

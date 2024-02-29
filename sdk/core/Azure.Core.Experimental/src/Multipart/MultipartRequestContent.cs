// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Azure.Core
{
    /// <summary>
    ///  Provides a container for content encoded using multipart/form-data MIME type.
    /// </summary>
    public class MultipartRequestContent: RequestContent
    {
        private const string CrLf = "\r\n";
        private const string ColonSP = ": ";

        private protected static readonly int s_crlfLength = GetEncodedLength(CrLf);
        private protected static readonly int s_dashDashLength = GetEncodedLength("--");
        private protected static readonly int s_colonSpaceLength = GetEncodedLength(ColonSP);
        private protected readonly List<MultipartContent> _nestedContent;
        private protected readonly string _subtype;
        private protected readonly string _boundary;
        internal readonly Dictionary<string, string> _headers;
        /// <summary> Gets the MIME type of this content. </summary>
        public readonly string ContentType;

        /// <summary> The list of request content parts. </summary>
        public List<MultipartContent> ContentParts => _nestedContent;

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartBinaryContent"/> class.
        ///  </summary>
        public MultipartRequestContent()
            : this("mixed", GetDefaultBoundary())
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartBinaryContent"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        public MultipartRequestContent(string subtype)
            : this(subtype, GetDefaultBoundary())
        {
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartContent"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartRequestContent(string subtype, string boundary) : this(subtype, boundary, new List<MultipartContent>())
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartBinaryContent"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        internal MultipartRequestContent(string subtype, string boundary, IReadOnlyList<MultipartContent> nestedContent)
        {
            ValidateBoundary(boundary);
            _subtype = subtype;

            // see https://www.ietf.org/rfc/rfc1521.txt page 29.
            _boundary = boundary.Contains(":") ? $"\"{boundary}\"" : boundary;
            _headers = new Dictionary<string, string>
            {
                ["Content-Type"] = $"multipart/{_subtype}; boundary={_boundary}"
            };
            ContentType = $"multipart/{_subtype}; boundary={_boundary}";
            _nestedContent = nestedContent.ToList<MultipartContent>();
        }

        private static string GetDefaultBoundary()
        {
            return Guid.NewGuid().ToString();
        }

        private static void ValidateBoundary(string boundary)
        {
            if (string.IsNullOrWhiteSpace(boundary))
            {
                throw new ArgumentException("Value cannot be null or empty.", boundary);
            }

            // cspell:disable
            // RFC 2046 Section 5.1.1
            // boundary := 0*69<bchars> bcharsnospace
            // bchars := bcharsnospace / " "
            // bcharsnospace := DIGIT / ALPHA / "'" / "(" / ")" / "+" / "_" / "," / "-" / "." / "/" / ":" / "=" / "?"
            // cspell:enable
            if (boundary.Length > 70)
            {
                throw new ArgumentOutOfRangeException(nameof(boundary), boundary, $"The field cannot be longer than {70} characters.");
            }
            // Cannot end with space.
            if (boundary.EndsWith(" ", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
            }

            foreach (char ch in boundary)
            {
                if (!IsValidBoundaryCharacter(ch))
                {
                    throw new ArgumentException($"The format of value '{boundary}' is invalid.", nameof(boundary));
                }
            }
        }
        private static bool IsValidBoundaryCharacter(char ch)
        {
            const string AllowedMarks = @"'()+_,-./:=? ";
            if (('0' <= ch && ch <= '9') || // Digit.
                    ('a' <= ch && ch <= 'z') || // alpha.
                    ('A' <= ch && ch <= 'Z') || // ALPHA.
                    AllowedMarks.Contains(char.ToString(ch))) // Marks.
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  Add HTTP content to a collection of RequestContent objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The Request content to add to the collection.</param>
        public virtual void Add(MultipartContent content)
        {
            _nestedContent.Add(content);
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
        private protected BinaryData ToBinaryData()
        {
            try
            {
                using MemoryStream stream = new MemoryStream();
                // Write start boundary.
                EncodeStringToStream(stream, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    if (contentIndex != 0)
                        EncodeStringToStream(stream, CrLf + "--" + _boundary + CrLf);
                    // Write divider, headers, and content.
                    _nestedContent[contentIndex].WriteTo(stream);
                }

                // Write footer boundary.
                EncodeStringToStream(stream, CrLf + "--" + _boundary + "--" + CrLf);
                string contentType = $"multipart/{_subtype}; boundary={_boundary}";
                BinaryData binaryData;
                if (stream.Position > int.MaxValue)
                {
                    binaryData = BinaryData.FromStream(stream, contentType);
                }
                else
                {
                    binaryData = new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position), contentType);
                }
                return binaryData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private protected void WriteToStream(Stream stream, CancellationToken cancellationToken)
        {
            try
            {
                // Write start boundary.
                EncodeStringToStream(stream, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    if (contentIndex != 0)
                        EncodeStringToStream(stream, CrLf + "--" + _boundary + CrLf);
                    _nestedContent[contentIndex].WriteTo(stream, cancellationToken);
                }

                // Write footer boundary.
                EncodeStringToStream(stream, CrLf + "--" + _boundary + "--" + CrLf);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // for-each content
        //   write "--" + boundary
        //   for-each content header
        //     write header: header-value
        //   write content.WriteTo[Async]
        // write "--" + boundary + "--"
        // Can't be canceled directly by the user.  If the overall request is canceled
        // then the stream will be closed an exception thrown.
        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private protected async Task WriteToStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            try
            {
                // Write start boundary.
                await EncodeStringToStreamAsync(stream, "--" + _boundary + CrLf, cancellationToken).ConfigureAwait(false);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    if (contentIndex != 0)
                        await EncodeStringToStreamAsync(stream, CrLf + "--" + _boundary + CrLf, cancellationToken).ConfigureAwait(false);
                    await _nestedContent[contentIndex].WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
                }

                // Write footer boundary.
                await EncodeStringToStreamAsync(stream, CrLf + "--" + _boundary + "--" + CrLf, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static async Task<IReadOnlyList<MultipartContent>> ReadAsync(Stream stream, string subType, string boundary)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (stream.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(stream));
            }
            // Read the content into a stream.
            List<MultipartContent> parts = new List<MultipartContent>();
            CancellationToken cancellationToken = new CancellationToken();
            bool expectBoundariesWithCRLF = false;
            MultipartReader reader = new MultipartReader(boundary, stream) { ExpectBoundariesWithCRLF = expectBoundariesWithCRLF };
            for (MultipartSection section = await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false);
                section != null;
                section = await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false))
            {
                if (section.Headers != null && section.Headers.TryGetValue("Content-Type", out string[] contentTypeValues) &&
                        contentTypeValues.Length == 1 &&
                        GetBoundary(contentTypeValues[0], out _, out string subBoundary))
                {
                    // ExpectBoundariesWithCRLF should always be true for the Body.
                    reader = new MultipartReader(subBoundary, section.Body) { ExpectBoundariesWithCRLF = true };
                    continue;
                }
                Dictionary<string, string> headers = new Dictionary<string, string>();
                if (section.Headers != null)
                {
                    foreach (KeyValuePair<string, string[]> header in section.Headers)
                    {
                        headers.Add(header.Key, string.Join(";", header.Value));
                    }
                }
                parts.Add(new MultipartContent(BinaryContent.Create(BinaryData.FromStream(section.Body)), headers));
            }
            return parts;
        }
        private protected static IReadOnlyList<MultipartContent> Read(Stream stream, string subType, string boundary)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (stream.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(stream));
            }
            // Read the content into a stream.
            List<MultipartContent> parts = new List<MultipartContent>();
            bool expectBoundariesWithCRLF = false;
            MultipartReader reader = new MultipartReader(boundary, stream) { ExpectBoundariesWithCRLF = expectBoundariesWithCRLF };
            for (MultipartSection section = reader.ReadNextSection();
                section != null;
                section = reader.ReadNextSection())
            {
                if (section.Headers != null && section.Headers.TryGetValue("Content-Type", out string[] contentTypeValues) &&
                        contentTypeValues.Length == 1 &&
                        GetBoundary(contentTypeValues[0], out _, out string subBoundary))
                {
                    // ExpectBoundariesWithCRLF should always be true for the Body.
                    reader = new MultipartReader(subBoundary, section.Body) { ExpectBoundariesWithCRLF = true };
                    continue;
                }
                Dictionary<string, string> headers = new Dictionary<string, string>();
                if (section.Headers != null)
                {
                    foreach (KeyValuePair<string, string[]> header in section.Headers)
                    {
                        headers.Add(header.Key, string.Join(";", header.Value));
                    }
                }
                parts.Add(new MultipartContent(BinaryContent.Create(BinaryData.FromStream(section.Body)), headers));
            }
            return parts;
        }
        /// <summary>
        ///  Read the content from BinaryData and parse it.
        ///  each part of BinaryData separted by boundary will be parsed as one MultipartContent.
        /// </summary>
        private static async Task<IReadOnlyList<MultipartContent>> ReadAsync(BinaryData data, string subType, string boundary)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(data));
            }
            string prefix = $"multipart/{subType}; boundary=";
            if (boundary == null)
            {
                string contentType = data.MediaType;
                if (string.IsNullOrEmpty(contentType))
                {
                    throw new ArgumentException("Missing content type", nameof(data));
                }
                if (contentType == null || !contentType.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Invalid content type", nameof(data));
                }
                if (!GetBoundary(contentType, out subType, out boundary))
                {
                    throw new ArgumentException("Missing boundary", nameof(data));
                }
            }
            // Read the content into a stream.
            return await ReadAsync(data.ToStream(), subType, boundary).ConfigureAwait(false);
        }

        private protected static IReadOnlyList<MultipartContent> Read(BinaryData data, string subType, string boundary)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Length == 0)
            {
                throw new ArgumentException("Empty data", nameof(data));
            }
            string prefix = $"multipart/{subType}; boundary=";
            if (boundary == null)
            {
                string contentType = data.MediaType;
                if (string.IsNullOrEmpty(contentType))
                {
                    throw new ArgumentException("Missing content type", nameof(data));
                }
                if (contentType == null || !contentType.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Invalid content type", nameof(data));
                }
                if (!GetBoundary(contentType, out subType, out boundary))
                {
                    throw new ArgumentException("Missing boundary", nameof(data));
                }
            }
            // Read the content into a stream.
            return Read(data.ToStream(), subType, boundary);
        }

        private void AddInternal(BinaryContent content, Dictionary<string, string> headers)
        {
            var part = new MultipartContent(content, headers);
            _nestedContent.Add(part);
        }

        private static Task EncodeStringToStreamAsync(Stream stream, string input, CancellationToken cancellationToken)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            return stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
        }
        private static void EncodeStringToStream(Stream stream, string input)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            stream.Write(buffer, 0, buffer.Length);
        }
        private protected static int GetEncodedLength(string input)
        {
            return Encoding.Default.GetByteCount(input);
        }
        private protected static bool GetBoundary(string contentType, out string subType, out string boundary)
        {
            string regex = @"^multipart/(?<subType>.*); boundary=(?<boundary>.*)";
            var matchs = Regex.Matches(contentType, regex);
            if (matchs == null || matchs?.Count == 0)
            {
                subType = null;
                boundary = null;
                return false;
            }
            subType = matchs?[0].Groups["subType"].Value;
            boundary = matchs?[0].Groups["boundary"].Value;
            return true;
        }
    }
}

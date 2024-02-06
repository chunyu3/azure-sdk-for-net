// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace System.ClientModel
{
    /// <summary>
    /// A Content in multipart format.
    /// </summary>
    public class MultipartHelper : IDisposable
    {
        private const string CrLf = "\r\n";
        private const string ColonSP = ": ";

        private protected static readonly int s_crlfLength = GetEncodedLength(CrLf);
        private protected static readonly int s_dashDashLength = GetEncodedLength("--");
        private protected static readonly int s_colonSpaceLength = GetEncodedLength(ColonSP);
        private protected readonly List<MultipartModelContentPart> _nestedContent;
        private protected readonly string _subtype;
        private protected readonly string _boundary;
        internal readonly Dictionary<string, string> _headers;
        private protected const string MultipartContentTypePrefix = "multipart/mixed; boundary=";

        /// <summary> The list of request content parts. </summary>
        public List<MultipartModelContentPart> ContentParts => _nestedContent;
        public string Boundary => _boundary;
        public string Subtype => _subtype;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        ///  </summary>
        public MultipartHelper()
            : this("mixed", GetDefaultBoundary(), null)
        { }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        public MultipartHelper(string subtype)
            : this(subtype, GetDefaultBoundary(), null)
        {
        }
        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        public MultipartHelper(string subtype, string boundary) : this(subtype, boundary, null)
        {
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Multipart"/> class.
        /// </summary>
        /// <param name="subtype">The multipart sub type.</param>
        /// <param name="boundary">The boundary string for the multipart form data content.</param>
        /// <param name="nestedContent">The list of content parts.</param>
        public MultipartHelper(string subtype, string boundary, IReadOnlyList<MultipartModelContentPart> nestedContent)
        {
            ValidateBoundary(boundary);
            _subtype = subtype;

            // see https://www.ietf.org/rfc/rfc1521.txt page 29.
            _boundary = boundary.Contains(":") ? $"\"{boundary}\"" : boundary;
            _headers = new Dictionary<string, string>
            {
                ["Content-Type"] = $"multipart/{_subtype}; boundary={_boundary}"
            };

            if (nestedContent != null)
            {
                _nestedContent = nestedContent.ToList<MultipartModelContentPart>();
            }
            else
            {
                _nestedContent = new List<MultipartModelContentPart>();
            }
        }

        protected static string GetDefaultBoundary()
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
        ///  Add HTTP content to a collection of Content objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The content to add to the collection.</param>
        public virtual void Add(object content)
        {
            AddInternal(content, null);
        }

        /// <summary>
        ///  Add HTTP content to a collection of binary data objects that
        ///  get serialized to multipart/form-data MIME type.
        /// </summary>
        /// <param name="content">The content to add to the collection.</param>
        /// <param name="headers">The headers to add to the collection.</param>
        public virtual void Add(object content, Dictionary<string, string> headers)
        {
            AddInternal(content, headers);
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
        public virtual BinaryData ToContent()
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
                    // Write divider, headers, and content.
                    //BinaryData content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    //byte[] buffer = content.ToArray();
                    byte[] buffer = Encoding.UTF8.GetBytes(_nestedContent[contentIndex].Content.ToString());
                    stream.Write(buffer, 0, buffer.Length);
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

        /// <summary>
        ///  Combine all the parts to BinaryData Content.
        /// </summary>
        // for-each content
        // write "--" + boundary
        // for-each content header
        // write header: header-value
        // write content.WriteTo[Async]
        // write "--" + boundary + "--"
        public virtual BinaryData ToContent2()
        {
            try
            {
                long length = 0;
                TryComputeLength(out length);
                if (length <= 0)
                {
                    throw new InvalidOperationException("The length of the content cannot be computed.");
                }
                using MemoryStream stream = new MemoryStream((int)length);
                // Write start boundary.
                EncodeStringToStream(stream, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    //BinaryData content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    byte[] buffer = Encoding.UTF8.GetBytes(_nestedContent[contentIndex].Content.ToString());
                    stream.Write(buffer, 0, buffer.Length);
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
        /// <summary>
        ///  Combine all the parts to BinaryData Content.
        /// </summary>
        // for-each content
        // write "--" + boundary
        // for-each content header
        // write header: header-value
        // write content.WriteTo[Async]
        // write "--" + boundary + "--"
        public virtual BinaryData ToContentBytes()
        {
            try
            {
                long length = 0;
                TryComputeLength(out length);
                if (length <= 0)
                {
                    throw new InvalidOperationException("The length of the content cannot be computed.");
                }
                byte[] data = new byte[length];
                int offset = 0;
                EncodeStringToBytes(data, ref offset, "--" + _boundary + CrLf);

                // Write each nested content.
                var output = new StringBuilder();
                for (int contentIndex = 0; contentIndex < _nestedContent.Count; contentIndex++)
                {
                    // Write divider, headers, and content.
                    //BinaryData content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToBytes(data, ref offset, SerializeHeadersToString(output, contentIndex, headers));
                    byte[] buffer = Encoding.UTF8.GetBytes(_nestedContent[contentIndex].Content.ToString());
                    EncodeStringToBytes(data, ref offset, buffer);
                }

                // Write footer boundary.
                EncodeStringToBytes(data, ref offset, CrLf + "--" + _boundary + "--" + CrLf);
                string contentType = $"multipart/{_subtype}; boundary={_boundary}";
                BinaryData binaryData = BinaryData.FromBytes(data, contentType);
                return binaryData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual void WriteToStream(Stream stream, ref string contentType)
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
                    //BinaryData content = _nestedContent[contentIndex].Content;
                    Dictionary<string, string> headers = _nestedContent[contentIndex].Headers;
                    EncodeStringToStream(stream, SerializeHeadersToString(output, contentIndex, headers));
                    //byte[] buffer = Encoding.UTF8.GetBytes(_nestedContent[contentIndex].Content.ToString());
                    byte[] buffer;
                    switch (_nestedContent[contentIndex].Content) {
                        case BinaryData binaryData:
                            buffer = binaryData.ToArray();
                            break;
                        case string str:
                            buffer = Encoding.UTF8.GetBytes(str);
                            break;
                        case byte[] bytes:
                            buffer = bytes;
                            break;
                        case Int32 int32Data:
                            buffer = BitConverter.GetBytes(int32Data);
                            break;
                        default:
                            throw new InvalidOperationException("Unsupported content type");
                    }
                    stream.Write(buffer, 0, buffer.Length);
                }

                // Write footer boundary.
                EncodeStringToStream(stream, CrLf + "--" + _boundary + "--" + CrLf);
                contentType = $"multipart/{_subtype}; boundary={_boundary}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Read the content from BinaryData and parse it.
        ///  each part of BinaryData separted by boundary will be parsed as one MultipartContentPart.
        /// </summary>
        public static async Task<MultipartHelper> ReadAsync(BinaryData data, string subType = "mixed", string boundary = null)
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
                if (!GetBoundary(contentType, prefix, out boundary))
                {
                    throw new ArgumentException("Missing boundary", nameof(data));
                }
            }
            // Read the content into a stream.
            MultipartHelper multipartContent = new MultipartHelper(subType, boundary);
            Stream content = data.ToStream();
            CancellationToken cancellationToken = new CancellationToken();
            bool expectBoundariesWithCRLF = false;
            MultipartReader reader = new MultipartReader(boundary, content) { ExpectBoundariesWithCRLF = expectBoundariesWithCRLF };
            for (MultipartSection section = await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false);
                section != null;
                section = await reader.ReadNextSectionAsync(cancellationToken).ConfigureAwait(false))
            {
                if (section.Headers != null && section.Headers.TryGetValue("Content-Type", out string[] contentTypeValues) &&
                        contentTypeValues.Length == 1 &&
                        GetBoundary(contentTypeValues[0], prefix, out string subBoundary))
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
                multipartContent.ContentParts.Add(new MultipartModelContentPart(BinaryData.FromStream(section.Body), headers));
            }
            return multipartContent;
        }

        public static MultipartHelper Read(BinaryData data, string subType = "mixed", string boundary = null)
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return ReadAsync(data, subType, boundary).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private void AddInternal(object content, Dictionary<string, string> headers)
        {
            var part = new MultipartModelContentPart(content, headers);
            _nestedContent.Add(part);
        }
        private string SerializeHeadersToString(StringBuilder scratch, int contentIndex, Dictionary<string, string> headers)
        {
            scratch.Clear();
            // Add divider.
            if (contentIndex != 0) // Write divider for all but the first content.
            {
                scratch.Append(CrLf + "--"); // const strings
                scratch.Append(_boundary);
                scratch.Append(CrLf);
            }

            // Add headers.
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    scratch.Append(header.Key);
                    scratch.Append(": ");
                    scratch.Append(header.Value);
                    scratch.Append(CrLf);
                }
            }

            // Extra CRLF to end headers (even if there are no headers).
            scratch.Append(CrLf);

            return scratch.ToString();
        }

        private static void EncodeStringToBytes(byte[] buffer, ref int offset, string input)
        {
            int encodedLength = Encoding.Default.GetBytes(input, 0, input.Length, buffer, offset);
            offset += encodedLength;
        }
        private static void EncodeStringToBytes(byte[] buffer, ref int offset, byte[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                buffer[offset++] = input[i];
            }
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
        private static bool GetBoundary(string contentType, string prefix, out string boundary)
        {
            if (contentType == null || !contentType.StartsWith(prefix, StringComparison.Ordinal))
            {
                boundary = null;
                return false;
            }
            boundary = contentType.Substring(prefix.Length);
            return true;
        }
        public virtual bool TryComputeLength(out long length)
        {
            int boundaryLength = GetEncodedLength(_boundary);

            long currentLength = 0;
            long internalBoundaryLength = s_crlfLength + s_dashDashLength + boundaryLength + s_crlfLength;

            // Start Boundary.
            currentLength += s_dashDashLength + boundaryLength + s_crlfLength;

            bool first = true;
            foreach (MultipartModelContentPart content in _nestedContent)
            {
                if (first)
                {
                    first = false; // First boundary already written.
                }
                else
                {
                    // Internal Boundary.
                    currentLength += internalBoundaryLength;
                }

                // Headers.
                foreach (KeyValuePair<string, string> headerPair in content.Headers)
                {
                    currentLength += GetEncodedLength(headerPair.Key) + s_colonSpaceLength;
                    currentLength += GetEncodedLength(headerPair.Value);
                    currentLength += s_crlfLength;
                }

                currentLength += s_crlfLength;

                // Content.
                /*
                if (!content.RequestContent.TryComputeLength(out long tempContentLength))
                {
                    length = 0;
                    return false;
                }
                */
                currentLength += Encoding.UTF8.GetBytes(content.ToString()).Length;
            }

            // Terminating boundary.
            currentLength += s_crlfLength + s_dashDashLength + boundaryLength + s_dashDashLength + s_crlfLength;

            length = currentLength;
            return true;
        }
        /// <summary>
        /// Frees resources held by the <see cref="Multipart"/> object.
        /// </summary>
        public void Dispose() { }
    }
}

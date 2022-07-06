// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Indicates the directory service used. </summary>
    public readonly partial struct DirectoryServiceOption : IEquatable<DirectoryServiceOption>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DirectoryServiceOption"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DirectoryServiceOption(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string AaddsValue = "AADDS";
        private const string ADValue = "AD";

        /// <summary> None. </summary>
        public static DirectoryServiceOption None { get; } = new DirectoryServiceOption(NoneValue);
        /// <summary> AADDS. </summary>
        public static DirectoryServiceOption Aadds { get; } = new DirectoryServiceOption(AaddsValue);
        /// <summary> AD. </summary>
        public static DirectoryServiceOption AD { get; } = new DirectoryServiceOption(ADValue);
        /// <summary> Determines if two <see cref="DirectoryServiceOption"/> values are the same. </summary>
        public static bool operator ==(DirectoryServiceOption left, DirectoryServiceOption right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DirectoryServiceOption"/> values are not the same. </summary>
        public static bool operator !=(DirectoryServiceOption left, DirectoryServiceOption right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DirectoryServiceOption"/>. </summary>
        public static implicit operator DirectoryServiceOption(string value) => new DirectoryServiceOption(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DirectoryServiceOption other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DirectoryServiceOption other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

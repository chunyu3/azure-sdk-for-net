// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.RedisEnterpriseCache.Models
{
    /// <summary> State of the link between the database resources. </summary>
    public readonly partial struct LinkState : IEquatable<LinkState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LinkState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LinkState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LinkedValue = "Linked";
        private const string LinkingValue = "Linking";
        private const string UnlinkingValue = "Unlinking";
        private const string LinkFailedValue = "LinkFailed";
        private const string UnlinkFailedValue = "UnlinkFailed";

        /// <summary> Linked. </summary>
        public static LinkState Linked { get; } = new LinkState(LinkedValue);
        /// <summary> Linking. </summary>
        public static LinkState Linking { get; } = new LinkState(LinkingValue);
        /// <summary> Unlinking. </summary>
        public static LinkState Unlinking { get; } = new LinkState(UnlinkingValue);
        /// <summary> LinkFailed. </summary>
        public static LinkState LinkFailed { get; } = new LinkState(LinkFailedValue);
        /// <summary> UnlinkFailed. </summary>
        public static LinkState UnlinkFailed { get; } = new LinkState(UnlinkFailedValue);
        /// <summary> Determines if two <see cref="LinkState"/> values are the same. </summary>
        public static bool operator ==(LinkState left, LinkState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LinkState"/> values are not the same. </summary>
        public static bool operator !=(LinkState left, LinkState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LinkState"/>. </summary>
        public static implicit operator LinkState(string value) => new LinkState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LinkState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LinkState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

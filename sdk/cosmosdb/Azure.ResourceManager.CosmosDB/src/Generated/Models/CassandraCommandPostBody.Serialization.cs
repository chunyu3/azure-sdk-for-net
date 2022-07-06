// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CassandraCommandPostBody : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("command");
            writer.WriteStringValue(Command);
            if (Optional.IsCollectionDefined(Arguments))
            {
                writer.WritePropertyName("arguments");
                writer.WriteStartObject();
                foreach (var item in Arguments)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("host");
            writer.WriteStringValue(Host);
            if (Optional.IsDefined(CassandraStopStart))
            {
                writer.WritePropertyName("cassandra-stop-start");
                writer.WriteBooleanValue(CassandraStopStart.Value);
            }
            if (Optional.IsDefined(Readwrite))
            {
                writer.WritePropertyName("readwrite");
                writer.WriteBooleanValue(Readwrite.Value);
            }
            writer.WriteEndObject();
        }
    }
}

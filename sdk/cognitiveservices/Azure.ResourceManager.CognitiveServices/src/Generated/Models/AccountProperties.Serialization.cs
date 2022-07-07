// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class AccountProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MigrationToken))
            {
                writer.WritePropertyName("migrationToken");
                writer.WriteStringValue(MigrationToken);
            }
            if (Optional.IsDefined(CustomSubDomainName))
            {
                writer.WritePropertyName("customSubDomainName");
                writer.WriteStringValue(CustomSubDomainName);
            }
            if (Optional.IsDefined(NetworkAcls))
            {
                writer.WritePropertyName("networkAcls");
                writer.WriteObjectValue(NetworkAcls);
            }
            if (Optional.IsDefined(Encryption))
            {
                writer.WritePropertyName("encryption");
                writer.WriteObjectValue(Encryption);
            }
            if (Optional.IsCollectionDefined(UserOwnedStorage))
            {
                writer.WritePropertyName("userOwnedStorage");
                writer.WriteStartArray();
                foreach (var item in UserOwnedStorage)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess");
                writer.WriteStringValue(PublicNetworkAccess.Value.ToString());
            }
            if (Optional.IsDefined(ApiProperties))
            {
                writer.WritePropertyName("apiProperties");
                writer.WriteObjectValue(ApiProperties);
            }
            if (Optional.IsDefined(DynamicThrottlingEnabled))
            {
                writer.WritePropertyName("dynamicThrottlingEnabled");
                writer.WriteBooleanValue(DynamicThrottlingEnabled.Value);
            }
            if (Optional.IsDefined(RestrictOutboundNetworkAccess))
            {
                writer.WritePropertyName("restrictOutboundNetworkAccess");
                writer.WriteBooleanValue(RestrictOutboundNetworkAccess.Value);
            }
            if (Optional.IsCollectionDefined(AllowedFqdnList))
            {
                writer.WritePropertyName("allowedFqdnList");
                writer.WriteStartArray();
                foreach (var item in AllowedFqdnList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DisableLocalAuth))
            {
                writer.WritePropertyName("disableLocalAuth");
                writer.WriteBooleanValue(DisableLocalAuth.Value);
            }
            if (Optional.IsDefined(Restore))
            {
                writer.WritePropertyName("restore");
                writer.WriteBooleanValue(Restore.Value);
            }
            writer.WriteEndObject();
        }

        internal static AccountProperties DeserializeAccountProperties(JsonElement element)
        {
            Optional<ProvisioningState> provisioningState = default;
            Optional<string> endpoint = default;
            Optional<string> internalId = default;
            Optional<IReadOnlyList<SkuCapability>> capabilities = default;
            Optional<bool> isMigrated = default;
            Optional<string> migrationToken = default;
            Optional<SkuChangeInfo> skuChangeInfo = default;
            Optional<string> customSubDomainName = default;
            Optional<NetworkRuleSet> networkAcls = default;
            Optional<Encryption> encryption = default;
            Optional<IList<UserOwnedStorage>> userOwnedStorage = default;
            Optional<IReadOnlyList<CognitiveServicesPrivateEndpointConnectionData>> privateEndpointConnections = default;
            Optional<PublicNetworkAccess> publicNetworkAccess = default;
            Optional<ApiProperties> apiProperties = default;
            Optional<string> dateCreated = default;
            Optional<CallRateLimit> callRateLimit = default;
            Optional<bool> dynamicThrottlingEnabled = default;
            Optional<QuotaLimit> quotaLimit = default;
            Optional<bool> restrictOutboundNetworkAccess = default;
            Optional<IList<string>> allowedFqdnList = default;
            Optional<bool> disableLocalAuth = default;
            Optional<IReadOnlyDictionary<string, string>> endpoints = default;
            Optional<bool> restore = default;
            Optional<string> deletionDate = default;
            Optional<string> scheduledPurgeDate = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisioningState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    provisioningState = new ProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("endpoint"))
                {
                    endpoint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("internalId"))
                {
                    internalId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("capabilities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SkuCapability> array = new List<SkuCapability>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SkuCapability.DeserializeSkuCapability(item));
                    }
                    capabilities = array;
                    continue;
                }
                if (property.NameEquals("isMigrated"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isMigrated = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("migrationToken"))
                {
                    migrationToken = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("skuChangeInfo"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    skuChangeInfo = SkuChangeInfo.DeserializeSkuChangeInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("customSubDomainName"))
                {
                    customSubDomainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("networkAcls"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    networkAcls = NetworkRuleSet.DeserializeNetworkRuleSet(property.Value);
                    continue;
                }
                if (property.NameEquals("encryption"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    encryption = Encryption.DeserializeEncryption(property.Value);
                    continue;
                }
                if (property.NameEquals("userOwnedStorage"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<UserOwnedStorage> array = new List<UserOwnedStorage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Models.UserOwnedStorage.DeserializeUserOwnedStorage(item));
                    }
                    userOwnedStorage = array;
                    continue;
                }
                if (property.NameEquals("privateEndpointConnections"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<CognitiveServicesPrivateEndpointConnectionData> array = new List<CognitiveServicesPrivateEndpointConnectionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CognitiveServicesPrivateEndpointConnectionData.DeserializeCognitiveServicesPrivateEndpointConnectionData(item));
                    }
                    privateEndpointConnections = array;
                    continue;
                }
                if (property.NameEquals("publicNetworkAccess"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    publicNetworkAccess = new PublicNetworkAccess(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("apiProperties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    apiProperties = ApiProperties.DeserializeApiProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("dateCreated"))
                {
                    dateCreated = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("callRateLimit"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    callRateLimit = CallRateLimit.DeserializeCallRateLimit(property.Value);
                    continue;
                }
                if (property.NameEquals("dynamicThrottlingEnabled"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dynamicThrottlingEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("quotaLimit"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    quotaLimit = QuotaLimit.DeserializeQuotaLimit(property.Value);
                    continue;
                }
                if (property.NameEquals("restrictOutboundNetworkAccess"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    restrictOutboundNetworkAccess = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("allowedFqdnList"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedFqdnList = array;
                    continue;
                }
                if (property.NameEquals("disableLocalAuth"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    disableLocalAuth = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("endpoints"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    endpoints = dictionary;
                    continue;
                }
                if (property.NameEquals("restore"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    restore = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("deletionDate"))
                {
                    deletionDate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("scheduledPurgeDate"))
                {
                    scheduledPurgeDate = property.Value.GetString();
                    continue;
                }
            }
            return new AccountProperties(Optional.ToNullable(provisioningState), endpoint.Value, internalId.Value, Optional.ToList(capabilities), Optional.ToNullable(isMigrated), migrationToken.Value, skuChangeInfo.Value, customSubDomainName.Value, networkAcls.Value, encryption.Value, Optional.ToList(userOwnedStorage), Optional.ToList(privateEndpointConnections), Optional.ToNullable(publicNetworkAccess), apiProperties.Value, dateCreated.Value, callRateLimit.Value, Optional.ToNullable(dynamicThrottlingEnabled), quotaLimit.Value, Optional.ToNullable(restrictOutboundNetworkAccess), Optional.ToList(allowedFqdnList), Optional.ToNullable(disableLocalAuth), Optional.ToDictionary(endpoints), Optional.ToNullable(restore), deletionDate.Value, scheduledPurgeDate.Value);
        }
    }
}

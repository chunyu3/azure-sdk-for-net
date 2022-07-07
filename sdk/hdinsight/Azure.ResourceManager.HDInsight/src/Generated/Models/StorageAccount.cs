// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.HDInsight.Models
{
    /// <summary> The storage Account. </summary>
    public partial class StorageAccount
    {
        /// <summary> Initializes a new instance of StorageAccount. </summary>
        public StorageAccount()
        {
        }

        /// <summary> Initializes a new instance of StorageAccount. </summary>
        /// <param name="name"> The name of the storage account. </param>
        /// <param name="isDefault"> Whether or not the storage account is the default storage account. </param>
        /// <param name="container"> The container in the storage account, only to be specified for WASB storage accounts. </param>
        /// <param name="fileSystem"> The filesystem, only to be specified for Azure Data Lake Storage Gen 2. </param>
        /// <param name="key"> The storage account access key. </param>
        /// <param name="resourceId"> The resource ID of storage account, only to be specified for Azure Data Lake Storage Gen 2. </param>
        /// <param name="msiResourceId"> The managed identity (MSI) that is allowed to access the storage account, only to be specified for Azure Data Lake Storage Gen 2. </param>
        /// <param name="sasKey"> The shared access signature key. </param>
        /// <param name="fileshare"> The file share name. </param>
        internal StorageAccount(string name, bool? isDefault, string container, string fileSystem, string key, string resourceId, string msiResourceId, string sasKey, string fileshare)
        {
            Name = name;
            IsDefault = isDefault;
            Container = container;
            FileSystem = fileSystem;
            Key = key;
            ResourceId = resourceId;
            MsiResourceId = msiResourceId;
            SasKey = sasKey;
            Fileshare = fileshare;
        }

        /// <summary> The name of the storage account. </summary>
        public string Name { get; set; }
        /// <summary> Whether or not the storage account is the default storage account. </summary>
        public bool? IsDefault { get; set; }
        /// <summary> The container in the storage account, only to be specified for WASB storage accounts. </summary>
        public string Container { get; set; }
        /// <summary> The filesystem, only to be specified for Azure Data Lake Storage Gen 2. </summary>
        public string FileSystem { get; set; }
        /// <summary> The storage account access key. </summary>
        public string Key { get; set; }
        /// <summary> The resource ID of storage account, only to be specified for Azure Data Lake Storage Gen 2. </summary>
        public string ResourceId { get; set; }
        /// <summary> The managed identity (MSI) that is allowed to access the storage account, only to be specified for Azure Data Lake Storage Gen 2. </summary>
        public string MsiResourceId { get; set; }
        /// <summary> The shared access signature key. </summary>
        public string SasKey { get; set; }
        /// <summary> The file share name. </summary>
        public string Fileshare { get; set; }
    }
}

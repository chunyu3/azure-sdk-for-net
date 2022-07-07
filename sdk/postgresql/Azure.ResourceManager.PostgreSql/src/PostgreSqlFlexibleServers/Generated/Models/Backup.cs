// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Backup properties of a server. </summary>
    public partial class Backup
    {
        /// <summary> Initializes a new instance of Backup. </summary>
        public Backup()
        {
        }

        /// <summary> Initializes a new instance of Backup. </summary>
        /// <param name="backupRetentionDays"> Backup retention days for the server. </param>
        /// <param name="geoRedundantBackup"> A value indicating whether Geo-Redundant backup is enabled on the server. </param>
        /// <param name="earliestRestoreOn"> The earliest restore point time (ISO8601 format) for server. </param>
        internal Backup(int? backupRetentionDays, GeoRedundantBackupEnum? geoRedundantBackup, DateTimeOffset? earliestRestoreOn)
        {
            BackupRetentionDays = backupRetentionDays;
            GeoRedundantBackup = geoRedundantBackup;
            EarliestRestoreOn = earliestRestoreOn;
        }

        /// <summary> Backup retention days for the server. </summary>
        public int? BackupRetentionDays { get; set; }
        /// <summary> A value indicating whether Geo-Redundant backup is enabled on the server. </summary>
        public GeoRedundantBackupEnum? GeoRedundantBackup { get; set; }
        /// <summary> The earliest restore point time (ISO8601 format) for server. </summary>
        public DateTimeOffset? EarliestRestoreOn { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> SAP HANA Linked Service. </summary>
    public partial class SapHanaLinkedService : LinkedService
    {
        /// <summary> Initializes a new instance of SapHanaLinkedService. </summary>
        public SapHanaLinkedService()
        {
            LinkedServiceType = "SapHana";
        }

        /// <summary> Initializes a new instance of SapHanaLinkedService. </summary>
        /// <param name="linkedServiceType"> Type of linked service. </param>
        /// <param name="connectVia"> The integration runtime reference. </param>
        /// <param name="description"> Linked service description. </param>
        /// <param name="parameters"> Parameters for linked service. </param>
        /// <param name="annotations"> List of tags that can be used for describing the linked service. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="connectionString"> SAP HANA ODBC connection string. Type: string, SecureString or AzureKeyVaultSecretReference. </param>
        /// <param name="server"> Host name of the SAP HANA server. Type: string (or Expression with resultType string). </param>
        /// <param name="authenticationType"> The authentication type to be used to connect to the SAP HANA server. </param>
        /// <param name="userName"> Username to access the SAP HANA server. Type: string (or Expression with resultType string). </param>
        /// <param name="password">
        /// Password to access the SAP HANA server.
        /// Please note <see cref="SecretBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecureString"/> and <see cref="AzureKeyVaultSecretReference"/>.
        /// </param>
        /// <param name="encryptedCredential"> The encrypted credential used for authentication. Credentials are encrypted using the integration runtime credential manager. Type: string (or Expression with resultType string). </param>
        internal SapHanaLinkedService(string linkedServiceType, IntegrationRuntimeReference connectVia, string description, IDictionary<string, ParameterSpecification> parameters, IList<BinaryData> annotations, IDictionary<string, BinaryData> additionalProperties, BinaryData connectionString, BinaryData server, SapHanaAuthenticationType? authenticationType, BinaryData userName, SecretBase password, BinaryData encryptedCredential) : base(linkedServiceType, connectVia, description, parameters, annotations, additionalProperties)
        {
            ConnectionString = connectionString;
            Server = server;
            AuthenticationType = authenticationType;
            UserName = userName;
            Password = password;
            EncryptedCredential = encryptedCredential;
            LinkedServiceType = linkedServiceType ?? "SapHana";
        }

        /// <summary> SAP HANA ODBC connection string. Type: string, SecureString or AzureKeyVaultSecretReference. </summary>
        public BinaryData ConnectionString { get; set; }
        /// <summary> Host name of the SAP HANA server. Type: string (or Expression with resultType string). </summary>
        public BinaryData Server { get; set; }
        /// <summary> The authentication type to be used to connect to the SAP HANA server. </summary>
        public SapHanaAuthenticationType? AuthenticationType { get; set; }
        /// <summary> Username to access the SAP HANA server. Type: string (or Expression with resultType string). </summary>
        public BinaryData UserName { get; set; }
        /// <summary>
        /// Password to access the SAP HANA server.
        /// Please note <see cref="SecretBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecureString"/> and <see cref="AzureKeyVaultSecretReference"/>.
        /// </summary>
        public SecretBase Password { get; set; }
        /// <summary> The encrypted credential used for authentication. Credentials are encrypted using the integration runtime credential manager. Type: string (or Expression with resultType string). </summary>
        public BinaryData EncryptedCredential { get; set; }
    }
}

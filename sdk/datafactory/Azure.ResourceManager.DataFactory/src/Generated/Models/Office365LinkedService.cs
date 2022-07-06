// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Office365 linked service. </summary>
    public partial class Office365LinkedService : LinkedService
    {
        /// <summary> Initializes a new instance of Office365LinkedService. </summary>
        /// <param name="office365TenantId"> Azure tenant ID to which the Office 365 account belongs. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalTenantId"> Specify the tenant information under which your Azure AD web application resides. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalId"> Specify the application&apos;s client ID. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalKey">
        /// Specify the application&apos;s key.
        /// Please note <see cref="SecretBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecureString"/> and <see cref="AzureKeyVaultSecretReference"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="office365TenantId"/>, <paramref name="servicePrincipalTenantId"/>, <paramref name="servicePrincipalId"/> or <paramref name="servicePrincipalKey"/> is null. </exception>
        public Office365LinkedService(BinaryData office365TenantId, BinaryData servicePrincipalTenantId, BinaryData servicePrincipalId, SecretBase servicePrincipalKey)
        {
            if (office365TenantId == null)
            {
                throw new ArgumentNullException(nameof(office365TenantId));
            }
            if (servicePrincipalTenantId == null)
            {
                throw new ArgumentNullException(nameof(servicePrincipalTenantId));
            }
            if (servicePrincipalId == null)
            {
                throw new ArgumentNullException(nameof(servicePrincipalId));
            }
            if (servicePrincipalKey == null)
            {
                throw new ArgumentNullException(nameof(servicePrincipalKey));
            }

            Office365TenantId = office365TenantId;
            ServicePrincipalTenantId = servicePrincipalTenantId;
            ServicePrincipalId = servicePrincipalId;
            ServicePrincipalKey = servicePrincipalKey;
            LinkedServiceType = "Office365";
        }

        /// <summary> Initializes a new instance of Office365LinkedService. </summary>
        /// <param name="linkedServiceType"> Type of linked service. </param>
        /// <param name="connectVia"> The integration runtime reference. </param>
        /// <param name="description"> Linked service description. </param>
        /// <param name="parameters"> Parameters for linked service. </param>
        /// <param name="annotations"> List of tags that can be used for describing the linked service. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="office365TenantId"> Azure tenant ID to which the Office 365 account belongs. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalTenantId"> Specify the tenant information under which your Azure AD web application resides. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalId"> Specify the application&apos;s client ID. Type: string (or Expression with resultType string). </param>
        /// <param name="servicePrincipalKey">
        /// Specify the application&apos;s key.
        /// Please note <see cref="SecretBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecureString"/> and <see cref="AzureKeyVaultSecretReference"/>.
        /// </param>
        /// <param name="encryptedCredential"> The encrypted credential used for authentication. Credentials are encrypted using the integration runtime credential manager. Type: string (or Expression with resultType string). </param>
        internal Office365LinkedService(string linkedServiceType, IntegrationRuntimeReference connectVia, string description, IDictionary<string, ParameterSpecification> parameters, IList<BinaryData> annotations, IDictionary<string, BinaryData> additionalProperties, BinaryData office365TenantId, BinaryData servicePrincipalTenantId, BinaryData servicePrincipalId, SecretBase servicePrincipalKey, BinaryData encryptedCredential) : base(linkedServiceType, connectVia, description, parameters, annotations, additionalProperties)
        {
            Office365TenantId = office365TenantId;
            ServicePrincipalTenantId = servicePrincipalTenantId;
            ServicePrincipalId = servicePrincipalId;
            ServicePrincipalKey = servicePrincipalKey;
            EncryptedCredential = encryptedCredential;
            LinkedServiceType = linkedServiceType ?? "Office365";
        }

        /// <summary> Azure tenant ID to which the Office 365 account belongs. Type: string (or Expression with resultType string). </summary>
        public BinaryData Office365TenantId { get; set; }
        /// <summary> Specify the tenant information under which your Azure AD web application resides. Type: string (or Expression with resultType string). </summary>
        public BinaryData ServicePrincipalTenantId { get; set; }
        /// <summary> Specify the application&apos;s client ID. Type: string (or Expression with resultType string). </summary>
        public BinaryData ServicePrincipalId { get; set; }
        /// <summary>
        /// Specify the application&apos;s key.
        /// Please note <see cref="SecretBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SecureString"/> and <see cref="AzureKeyVaultSecretReference"/>.
        /// </summary>
        public SecretBase ServicePrincipalKey { get; set; }
        /// <summary> The encrypted credential used for authentication. Credentials are encrypted using the integration runtime credential manager. Type: string (or Expression with resultType string). </summary>
        public BinaryData EncryptedCredential { get; set; }
    }
}

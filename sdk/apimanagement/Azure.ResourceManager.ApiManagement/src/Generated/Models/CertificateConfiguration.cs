// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Certificate configuration which consist of non-trusted intermediates and root certificates. </summary>
    public partial class CertificateConfiguration
    {
        /// <summary> Initializes a new instance of CertificateConfiguration. </summary>
        /// <param name="storeName"> The System.Security.Cryptography.x509certificates.StoreName certificate store location. Only Root and CertificateAuthority are valid locations. </param>
        public CertificateConfiguration(CertificateConfigurationStoreName storeName)
        {
            StoreName = storeName;
        }

        /// <summary> Initializes a new instance of CertificateConfiguration. </summary>
        /// <param name="encodedCertificate"> Base64 Encoded certificate. </param>
        /// <param name="certificatePassword"> Certificate Password. </param>
        /// <param name="storeName"> The System.Security.Cryptography.x509certificates.StoreName certificate store location. Only Root and CertificateAuthority are valid locations. </param>
        /// <param name="certificate"> Certificate information. </param>
        internal CertificateConfiguration(string encodedCertificate, string certificatePassword, CertificateConfigurationStoreName storeName, CertificateInformation certificate)
        {
            EncodedCertificate = encodedCertificate;
            CertificatePassword = certificatePassword;
            StoreName = storeName;
            Certificate = certificate;
        }

        /// <summary> Base64 Encoded certificate. </summary>
        public string EncodedCertificate { get; set; }
        /// <summary> Certificate Password. </summary>
        public string CertificatePassword { get; set; }
        /// <summary> The System.Security.Cryptography.x509certificates.StoreName certificate store location. Only Root and CertificateAuthority are valid locations. </summary>
        public CertificateConfigurationStoreName StoreName { get; set; }
        /// <summary> Certificate information. </summary>
        public CertificateInformation Certificate { get; set; }
    }
}

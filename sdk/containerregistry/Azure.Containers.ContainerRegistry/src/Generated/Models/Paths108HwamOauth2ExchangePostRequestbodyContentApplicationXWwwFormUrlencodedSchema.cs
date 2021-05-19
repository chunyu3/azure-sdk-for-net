// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The Paths108HwamOauth2ExchangePostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
    internal partial class Paths108HwamOauth2ExchangePostRequestbodyContentApplicationXWwwFormUrlencodedSchema
    {
        /// <summary> Initializes a new instance of Paths108HwamOauth2ExchangePostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
        /// <param name="grantType"> Can take a value of access_token_refresh_token, or access_token, or refresh_token. </param>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/> is null. </exception>
        internal Paths108HwamOauth2ExchangePostRequestbodyContentApplicationXWwwFormUrlencodedSchema(PostContentSchemaGrantType grantType, string service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            GrantType = grantType;
            Service = service;
        }

        /// <summary> Can take a value of access_token_refresh_token, or access_token, or refresh_token. </summary>
        public PostContentSchemaGrantType GrantType { get; }
        /// <summary> Indicates the name of your Azure container registry. </summary>
        public string Service { get; }
        /// <summary> AAD tenant associated to the AAD credentials. </summary>
        public string Tenant { get; }
        /// <summary> AAD refresh token, mandatory when grant_type is access_token_refresh_token or refresh_token. </summary>
        public string RefreshToken { get; }
        /// <summary> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </summary>
        public string AccessToken { get; }
    }
}

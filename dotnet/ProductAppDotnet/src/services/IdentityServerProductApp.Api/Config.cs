// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerProductApp.Api
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] {

            new ApiResource("product_resource"){Scopes = { "product_app_full_permission" } },
            new ApiResource("photo_resource"){Scopes = { "photo_app_full_permission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

            };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("product_app_full_permission" , "Full Permission For Product Api"),
                  new ApiScope("photo_app_full_permission" , "Full Permission For Product Api"),
                  new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                
                new Client
                {
                    ClientId = "Client_CC",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "Client_ROP",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AllowedScopes = { IdentityServerConstants.LocalApi.ScopeName,IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Email , "photo_app_full_permission" , "product_app_full_permission" },
                    AccessTokenLifetime = 1 * 60 * 60 * 24 ,
                    RefreshTokenExpiration = TokenExpiration.Absolute , 
                    RefreshTokenUsage = TokenUsage.ReUse , 
                    AbsoluteRefreshTokenLifetime = 1* 60 * 60 * 24 * 60 ,
                    
                },
            };
    }
}
// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("pharmarestapi", "Pharma Rest API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("pharmarestapi", "Projects API")
                {
                    Scopes = { "pharmarestapi" }
                },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                //// machine to machine client
                //new Client
                //{
                //    ClientId = "client",
                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    // scopes that client has access to
                //    AllowedScopes = { "PharmaRestAPI" }
                //},
                
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "hcl_demo_client",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,
                    RequirePkce = true,
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:4200/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:4200/signout-callback-oidc" },
                    AllowedCorsOrigins =     { "https://localhost:4200" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "pharmarestapi",
                        IdentityServerConstants.LocalApi.ScopeName
                    }
                }
            };
    }
}
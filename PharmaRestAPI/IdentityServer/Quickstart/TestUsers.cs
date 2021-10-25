// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "admin",
                        Username = "admin",
                        Password = "abcd1234",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "ADMIN"),
                            new Claim(JwtClaimTypes.FamilyName, "ADMIN"),
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "hcl1",
                        Username = "hcl1",
                        Password = "abcd1234",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "HCL1"),
                            new Claim(JwtClaimTypes.FamilyName, "HCL"),
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "hcl2",
                        Username = "hcl2",
                        Password = "abcd1234",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "HCL2"),
                            new Claim(JwtClaimTypes.FamilyName, "HCL")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "hcl3",
                        Username = "hcl3",
                        Password = "abcd1234",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "HCL2"),
                            new Claim(JwtClaimTypes.FamilyName, "HCL")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "hcl4",
                        Username = "hcl4",
                        Password = "abcd1234",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.GivenName, "HCL2"),
                            new Claim(JwtClaimTypes.FamilyName, "HCL")
                        }
                    }
                };
            }
        }
    }
}
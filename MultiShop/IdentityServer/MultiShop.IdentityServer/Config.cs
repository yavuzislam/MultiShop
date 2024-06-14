using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"} },
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },
           new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },
           new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"} },
           new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"} },
           new ApiResource("ResourceImages"){Scopes={"ImagesFullPermission"} },
           new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"} },
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile(),
          new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full access to catalog"),
            new ApiScope("CatalogReadPermission","Read access to catalog"),
            new ApiScope("DiscountFullPermission","Full access to discount"),
            new ApiScope("OrderFullPermission","Full access to order"),
            new ApiScope("CargoFullPermission","Full access to cargo"),
            new ApiScope("BasketFullPermission","Full access to basket"),
            new ApiScope("CommentFullPermission","Full access to comment"),
            new ApiScope("PaymentFullPermission","Full access to payment"),
            new ApiScope("ImagesFullPermission","Full access to images"),
            new ApiScope("OcelotFullPermission","Full access to ocelot"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "CommentFullPermission", "OcelotFullPermission", IdentityServerConstants.LocalApi.ScopeName }
            },

            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission",
                    "BasketFullPermission" ,"DiscountFullPermission","OrderFullPermission", "CommentFullPermission",
                    "PaymentFullPermission","OcelotFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email
                 }
            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission",
                    "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                    "PaymentFullPermission","CommentFullPermission","OcelotFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email
                },
                AccessTokenLifetime=600
            }
        };
    }
}
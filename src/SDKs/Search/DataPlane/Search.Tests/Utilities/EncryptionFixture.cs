using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Search.Tests.Utilities
{
    public class EncryptionFixture : SearchServiceFixture
    {
        public override void Initialize(MockContext context)
        {
            base.Initialize(context);



            string vaultName = TestUtilities.GenerateName("keyvault");
            string keyName = TestUtilities.GenerateName("keyvaultkey");

            
            KeyVaultManagementClient keyVaultMgmtClient = GetKeyVaultManagementClient(context);

            var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(this.ResourceGroupName, vaultName, new VaultCreateOrUpdateParameters
            {
                Location = this.Location,
                Properties = new VaultProperties
                {
                    //TenantId = System.Guid.Parse(account.Identity.TenantId),
                    AccessPolicies = accessPolicies,
                    Sku = new Sku(SkuName.Standard),
                    EnabledForDiskEncryption = false,
                    EnabledForDeployment = false,
                    EnabledForTemplateDeployment = false
                }
            });

            var keyVaultKey = keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();

        }
        private static  

        private static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>();
        }

        public static KeyVaultClient CreateKeyVaultClient()
        {
            return new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
        }

        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            string authClientId = GetServicePrincipalId();
            string authSecret = GetServicePrincipalSecret();
            var clientCredential = new ClientCredential(authClientId, authSecret);
            var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return result.AccessToken;
        }
    }
}

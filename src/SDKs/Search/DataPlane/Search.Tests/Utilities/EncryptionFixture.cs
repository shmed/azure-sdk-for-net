using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Search.Tests.Utilities
{
    public class EncryptionFixture : ResourceGroupFixture
    {
        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            SearchService searchService = CreateService(
                DefineServiceWithSku(Microsoft.Azure.Management.Search.Models.SkuName.Basic, Location),
                context, 
                ResourceGroupName);


            string vaultName = TestUtilities.GenerateName("keyvault");
            string keyName = TestUtilities.GenerateName("keyvaultkey");

            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            string tenantId = currentEnvironment.Tenant;


            KeyVaultManagementClient keyVaultMgmtClient = GetKeyVaultManagementClient(context);

            //var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(this.ResourceGroupName, vaultName, new VaultCreateOrUpdateParameters
            //{
            //    Location = this.Location,
            //    Properties = new VaultProperties
            //    {
            //        TenantId = System.Guid.Parse(account.Identity.TenantId),
            //        AccessPolicies = accessPolicies,
            //        Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
            //        EnabledForDiskEncryption = false,
            //        EnabledForDeployment = false,
            //        EnabledForTemplateDeployment = false
            //    }
            //});

            //var keyVaultKey = keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
            //        JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();

        }


        private static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>();
        }

        //public static KeyVaultClient CreateKeyVaultClient()
        //{
        //    return new KeyVaultClient(new TestKeyVaultCredential(GetAccessToken), GetHandlers());
        //}

        //public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        //{
        //    var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
        //    string authClientId = GetServicePrincipalId();
        //    string authSecret = GetServicePrincipalSecret();
        //    var clientCredential = new ClientCredential(authClientId, authSecret);
        //    var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
        //    return result.AccessToken;
        //}



        private SearchService DefineServiceWithSku(Microsoft.Azure.Management.Search.Models.SkuName sku, string location )
        {
            return new SearchService()
            {
                Location = location,
                Sku = new Microsoft.Azure.Management.Search.Models.Sku() { Name = sku },
                ReplicaCount = 1,
                PartitionCount = 1,
                Identity = new Identity(IdentityType.SystemAssigned)
            };
        }

        private static SearchService CreateService(SearchService service, MockContext context, string resourceGroupName)
        {
            SearchManagementClient searchMgmt = context.GetServiceClient<SearchManagementClient>();

            string serviceName = SearchTestUtilities.GenerateServiceName();

            service = searchMgmt.Services.BeginCreateOrUpdate(resourceGroupName, serviceName, service);
            service = WaitForProvisioningToComplete(searchMgmt, service, resourceGroupName);

            return service;

        }

        private static SearchService WaitForProvisioningToComplete(
            SearchManagementClient searchMgmt,
            SearchService service,
            string resourceGroupName)
        {
            while (service.ProvisioningState == ProvisioningState.Provisioning)
            {
                SearchTestUtilities.WaitForServiceProvisioning();
                service = searchMgmt.Services.Get(resourceGroupName, service.Name);
            }

            return service;
        }
    }
}

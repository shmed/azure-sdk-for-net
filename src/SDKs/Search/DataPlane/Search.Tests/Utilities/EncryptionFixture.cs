using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Tests.Utilities
{
    public class EncryptionFixture : SearchServiceFixture
    {
        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

             string resourceGroupName = this.ResourceGroupName;

            KeyVaultManagementClient keyVaultMgmtClient = GetKeyVaultManagementClient(context);

            
        }

        private static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>();
        }
    }
}

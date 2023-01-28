param location string

var config = json(loadTextContent('../configuration-map.json'))

resource vault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: '${config.keyVault.name}-${substring(uniqueString(resourceGroup().id), 0, 5)}'
  location: location
  properties: {
    enableRbacAuthorization: true
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Allow'
    }
  }
}

resource account 'Microsoft.DocumentDB/databaseAccounts@2022-08-15' existing = {
  name: config.cosmosDb.name
}

resource secret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: vault
  name: 'AppSettings--CosmosConnectionString'
  properties: {
    value: account.listConnectionStrings(account.apiVersion).connectionStrings[0].connectionString
  }
}

resource identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' existing = {
  name: config.userAssignedIdentities[0].name
}

resource vaultRoleAssignmment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(config.keyVault.rbacRoles.keyVaultSecretsUser.id, identity.id, vault.id)
  properties: {
    principalId: identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', config.keyVault.rbacRoles.keyVaultSecretsUser.id)
  }
}

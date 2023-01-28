param location string

var config = json(loadTextContent('../configuration-map.json'))

resource acr 'Microsoft.ContainerRegistry/registries@2021-09-01' = {
  name: config.acrRegistry.name
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
  }
}

resource user 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' existing = {
  name: config.userAssignedIdentities[0].name
}

resource roleAssignmment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(config.keyVault.rbacRoles.keyVaultSecretsUser.id, user.id, acr.id)
  properties: {
    principalId: user.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', config.keyVault.rbacRoles.acrPull.id)
  }
}

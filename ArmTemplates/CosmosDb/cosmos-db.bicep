param location string

var config = json(loadTextContent('../configuration-map.json'))

resource account 'Microsoft.DocumentDB/databaseAccounts@2022-08-15' = {
  name: config.cosmosDb.name
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    databaseAccountOfferType: 'Standard'
    enableFreeTier: true
    locations: [
      {
        failoverPriority: 0
        locationName: location
      }
    ]
  }
}

resource database 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2022-08-15' = {
  name: config.cosmosDb.sqlDatabase.name
  parent: account
  properties: {
    resource: {
      id: config.cosmosDb.sqlDatabase.name
    }
  }
}

resource containers 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2022-05-15' = [for container in config.cosmosDb.sqlDatabase.containers: {
  name: container.name
  parent: database
  properties: {
    resource: {
      id: container.name
      partitionKey: {
        kind: 'Hash'
        paths: [
          container.partitionKey
        ]
      }
    }
  }
}]

resource identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' existing = {
  name: config.userAssignedIdentities[0].name
}

resource cosmosRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(config.cosmosDb.rbacRoles.contributor.name, identity.id, account.apiVersion)
  properties: {
    principalId: identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', config.cosmosDb.rbacRoles.contributor.id)
  }
}

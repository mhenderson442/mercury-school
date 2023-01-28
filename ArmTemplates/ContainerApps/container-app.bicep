param location string
param image string

var config = json(loadTextContent('../configuration-map.json'))

resource env 'Microsoft.App/managedEnvironments@2022-03-01' existing = {
  name: config.containerAppEnvironment.name
}

resource user 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' existing = {
  name: config.userAssignedIdentities[0].name
}

resource acr 'Microsoft.ContainerRegistry/registries@2021-09-01' existing = {
  name: config.acrRegistry.name
}

resource account 'Microsoft.DocumentDB/databaseAccounts@2022-08-15' existing = {
  name: config.cosmosDb.name
}

resource cosmosDb 'Microsoft.DocumentDB/databaseAccounts@2022-08-15' existing = {
  name: config.cosmosDb.name
}

resource app 'Microsoft.App/containerApps@2022-06-01-preview' = {
  name: config.containerApp.name
  location: location
  identity: {
    type: 'SystemAssigned,UserAssigned'
    userAssignedIdentities: {
      '${user.id}': {}
    }
  }
  properties: {
    environmentId: env.id
    template: {
      containers: [
        {
          name: config.containerApp.name
          image: image
          env: [
            {
              name: config.containerApp.secrets[0].name
              secretRef: config.containerApp.secrets[0].name
            }
          ]
        }
      ]
    }
    configuration: {
      ingress: {
        external: true
        targetPort: 80
        transport: 'auto'
      }
      secrets: [
        {
          name: config.containerApp.secrets[0].name
          value: account.listConnectionStrings(account.apiVersion).connectionStrings[0].connectionString
        }
      ]
      registries: [
        {
          server: acr.properties.loginServer
          identity: user.id
        }
      ]
    }
  }
}

resource serviceLinker 'Microsoft.ServiceLinker/linkers@2022-11-01-preview' = {
  name: config.containerApp.serviceLinker.cosmosDb.name
  scope: app
  properties: {
    clientType: 'dotnet'
    scope: app.name
    authInfo: {
      authType: 'userAssignedIdentity'
      clientId: user.properties.clientId
      subscriptionId: subscription().subscriptionId
    }
    targetService: {
      type: 'AzureResource'
      id: cosmosDb.id
    }
  }
}

param location string
param buildId string
param image string

var config = json(loadTextContent('./configuration-map.json'))

module userAssignedIdentity 'Identity/user-assigned-identity.bicep' = {
  name: '${config.userAssignedIdentities[0].name}-${buildId}'
  params: {
    location: location
  }
}

module cosmos 'CosmosDb/cosmos-db.bicep' = {
  name: '${config.cosmosDb.name}-${buildId}'
  params: {
    location: location
  }
}

module vault 'KeyVault/key-vault.bicep' = {
  name: '${config.keyVault.name}-${buildId}'
  dependsOn: [
    cosmos
    userAssignedIdentity
  ]
  params: {
    location: location
  }
}

module containerRegistry 'AzureContainerRegistries/container-registry.bicep' = {
  name: '${config.acrRegistry.name}-${buildId}'
  dependsOn: [
    userAssignedIdentity
  ]
  params: {
    location: location
  }
}

module insightsWorkspace 'OperationalInsights/log-analytics-workspace.bicep' = {
  name: '${config.operationalInsights.workspace.name}-${buildId}'
  params: {
    location: location
  }
}

module containerEnvironment 'ContainerApps/container-app-environment.bicep' = {
  name: '${config.containerAppEnvironment.name}-${buildId}'
  dependsOn: [
    insightsWorkspace
  ]
  params: {
    location: location
  }
}

module containerApp 'ContainerApps/container-app.bicep' = {
  name: '${config.containerApp.name}-${buildId}'
  dependsOn: [
    userAssignedIdentity
    containerRegistry
    containerEnvironment
  ]
  params: {
    location: location
    image: image
  }
}

param location string

var config = json(loadTextContent('../configuration-map.json'))

resource server 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: config.appServicePlan.name
  location: location
  kind: 'linux'
  sku: {
    name: 'B1'
    tier: 'Basic'
    size: 'B1'
    family: 'B'
    capacity: 1
  }
  properties: {
    perSiteScaling: false
    elasticScaleEnabled: false
    maximumElasticWorkerCount: 1
    targetWorkerCount: 0
    targetWorkerSizeId: 0
    zoneRedundant: false
    reserved: true
  }
}

resource app 'Microsoft.Web/sites@2022-03-01' = {
  name: config.appServicePlan.webapi.name
  location: location
  kind: 'app,linux'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    httpsOnly: true
    serverFarmId: server.id
    siteConfig: {
      alwaysOn: true
      linuxFxVersion: 'DOTNETCORE|7.0'
      numberOfWorkers: 1
    }

  }
}

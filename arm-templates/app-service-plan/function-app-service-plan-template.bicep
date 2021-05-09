param functionAppServiceName string
param vnetDataSubNetId string

var functionAppServicePlanName = '${functionAppServiceName}-app-service-plan'

resource appServicePlan 'Microsoft.Web/serverfarms@2020-12-01' = {
  name: functionAppServiceName
  kind: 'linux'
  location: resourceGroup().location
  sku: {
    tier: 'Dynamic'
    name: 'Y1'
  }
  properties: {
    reserved: true
    targetWorkerCount: 1
  }
}

resource functionAddService 'Microsoft.Web/sites@2020-12-01' = {
  name: functionAppServiceName
  location: resourceGroup().location
  kind: 'functionapp,linux'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      scmIpSecurityRestrictions: [
        {
          ipAddress: 'Any'
          action: 'Allow'
          description: 'Allow all access'
          name: 'Allow all'
          priority: 1
        }
      ]
      ipSecurityRestrictions: [
        {
          vnetSubnetResourceId: vnetDataSubNetId
          action: 'Allow'
          tag: 'Default'
          priority: 100
          name: 'Vnet Access Rule'
          description: 'Vnet Access Rule'
        }
        {
          ipAddress: 'Any'
          action: 'Deny'
          description: 'Deny all access'
          name: 'Deny all'
          priority: 2147483647
        }
      ]
      appSettings: [
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~3'
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'dotnet-isolated'
        }
      ]
      linuxFxVersion: 'DOTNET-ISOLATED|5.0'
    }
  }
}

output functionAppPrincipleId string = functionAddService.identity.principalId

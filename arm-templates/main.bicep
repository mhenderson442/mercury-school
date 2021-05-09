param resourceGroupName string
param adminObjectId string

var vnetName = '${resourceGroupName}-vnet'
var storageAccountName = 'storage${uniqueString(resourceGroupName)}'
var functionAppServiceName = '${resourceGroupName}-functions'
var keyVaultName = '${resourceGroupName}-key-vault'
var cosmosDbName = '${resourceGroupName}-cosmos-db'

module vnetDeployment 'vnet/vnet-template.bicep' = {
  name: '${vnetName}-deployment'
  params: {
    ventName: vnetName
  }
}

module storageDeployment 'storage/storage-template.bicep' = {
  name: '${storageAccountName}-deployment'
  params: {
    storageAccountName: storageAccountName
    vnetDataSubNetId: vnetDeployment.outputs.vnetDataSubNetId
  }
}

module functionAppServiceDeployment 'app-service-plan/function-app-service-plan-template.bicep' = {
  name: '${functionAppServiceName}-deployment'
  params: {
    functionAppServiceName: functionAppServiceName
    vnetDataSubNetId: vnetDeployment.outputs.vnetDataSubNetId
  }
}

module cosmosDbDeployment 'cosmosdb/cosmosdb-template.bicep' = {
  name: '${cosmosDbName}-deployment'
  params: {
    cosmosDbName: cosmosDbName
    databaseName: 'school'
    vnetDataSubNetId: vnetDeployment.outputs.vnetDataSubNetId
  }
}

var adminPrincipleIds = [
  adminObjectId
  functionAppServiceDeployment.outputs.functionAppPrincipleId
  cosmosDbDeployment.outputs.cosmosDbPrincipleId
]

module keyVaultDeployment 'key-vault/key-vault-template.bicep' = {
  name: '${keyVaultName}-deployment'
  params: {
    adminPrincipleIds: adminPrincipleIds
    keyVaultName: keyVaultName
    vnetDataSubNetId: vnetDeployment.outputs.vnetDataSubNetId
  }
}

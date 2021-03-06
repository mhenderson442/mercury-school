param administratorLogin string
param administratorLoginPassword string

var resourceGroupName = resourceGroup().name
var vnetName = '${resourceGroupName}-vnet'
var dnsZoneName = '${resourceGroupName}.cloud'
var appServicePlanName = '${resourceGroupName}-app-service-plan'
var webAppName = '${resourceGroupName}-web-api'
var privateEndpointName = '${resourceGroupName}-sql-private-endpoint'

var sqlServerParameters = {
  'serverName': '${resourceGroupName}-sql-server'
  'databaseName': 'MercurySchool'
  'administratorLogin': administratorLogin
  'administratorLoginPassword': administratorLoginPassword
}

module vnetDeployment 'vnet/vnet-template.bicep' = {
  name: '${vnetName}-deployment'
  params: {
    vnetName: vnetName
  }
}

module dnsZoneDeployment 'private-dns-zone/private-dns-zone-template.bicep' = {
  name: '${dnsZoneName}-dns-zone-deployment'
  params: {
    dnsZoneName: dnsZoneName
    ventId: vnetDeployment.outputs.vnetId
  }
}
module sqlServerDeployment 'sql-server/sql-server-template.bicep' = {
  name: '${sqlServerParameters.serverName}-deployment'
  params: {
    sqlServerParameters: sqlServerParameters
  }
}

module appServicePlanDeployment 'app-service-plan/web-app-service-plan-template.bicep' = {
  name: '${appServicePlanName}-deployment'
  params: {
    appServicePlanName: appServicePlanName
    webAppName: webAppName
    vnetWebSubNetId: vnetDeployment.outputs.vnetWebSubNetId
    vnetName: vnetName
  }
}

// module privateEndpointDeployment 'private-endpoint/private-endpoint-template.bicep' = {
//   name: '${privateEndpointName}-deployment'
//   params: {
//     privateEndpointName: privateEndpointName
//     subNetId: vnetDeployment.outputs.vnetDataSubNetId
//     webAppId: appServicePlanDeployment.outputs.webApiId
//   }
// }

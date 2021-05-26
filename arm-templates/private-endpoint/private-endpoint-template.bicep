param privateEndpointName string
param webAppId string
param subNetId string

resource privateEndpoint 'Microsoft.Network/privateEndpoints@2020-11-01' = {
  name: privateEndpointName
  location: resourceGroup().location
  properties: {
    privateLinkServiceConnections: [
      {
        name: '${privateEndpointName}-${uniqueString(resourceGroup().name)})}'
        properties: {
          groupIds: [
            'sites'
          ]
          privateLinkServiceId: webAppId
          privateLinkServiceConnectionState: {
            status: 'Approved'
            actionsRequired: 'None'
          }
        }
      }
    ]
    subnet: {
      id: subNetId
    }
  }
}

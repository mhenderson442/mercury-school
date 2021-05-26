param vnetName string

resource vnet 'Microsoft.Network/virtualNetworks@2020-11-01' = {
  name: vnetName
  location: resourceGroup().location
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.0.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'data-subnet'
        properties: {
          addressPrefix: '10.0.0.0/24'
          delegations: []
          privateEndpointNetworkPolicies: 'Disabled'
          privateLinkServiceNetworkPolicies: 'Enabled'
          serviceEndpoints: [
            {
              service: 'Microsoft.Sql'
              locations: [
                'northcentralus'
              ]
            }
          ]
        }
      }
      {
        name: 'app-service-subnet'
        properties: {
          addressPrefix: '10.0.1.0/24'
          delegations: []
          privateEndpointNetworkPolicies: 'Disabled'
          privateLinkServiceNetworkPolicies: 'Enabled'
          serviceEndpoints: [
            {
              service: 'Microsoft.Web'
              locations: [
                '*'
              ]
            }
          ]
        }
      }
    ]
  }
}

output vnetId string = vnet.id
output vnetDataSubNetId string = vnet.properties.subnets[0].id
output vnetWebSubNetId string = vnet.properties.subnets[1].id

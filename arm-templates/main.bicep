targetScope = 'subscription'

resource resourceGrup 'Microsoft.Resources/resourceGroups@2020-10-01' = {
  name: 'mercury-school'
  location: deployment().location
}

module vnetdeployment 'vnet/vnet-template.bicep' = {
 name: 'vnetDeployment' 
 scope:resourceGrup
}

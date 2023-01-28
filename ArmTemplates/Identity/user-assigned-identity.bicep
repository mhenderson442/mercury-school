param location string

var config = json(loadTextContent('../configuration-map.json'))

resource userAssignIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' = {
  name: config.userAssignedIdentities[0].name
  location: location
}

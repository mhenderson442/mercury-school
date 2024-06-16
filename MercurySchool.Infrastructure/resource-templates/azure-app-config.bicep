param configStoreName string
param location string

resource configStore  'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: configStoreName
  location: location  
  identity: {
    type:'SystemAssigned'
  }
  sku: {
    name: 'standard'
  }
}

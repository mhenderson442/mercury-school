param cosmosDbName string
param databaseName string
param vnetDataSubNetId string

resource cosmosDb 'Microsoft.DocumentDB/databaseAccounts@2021-03-15' = {
  name: cosmosDbName
  location: resourceGroup().location
  identity: {
    type: 'SystemAssigned'
  }
  kind: 'GlobalDocumentDB'
  properties: {
    enableFreeTier: true
    databaseAccountOfferType: 'Standard'
    consistencyPolicy: {
      defaultConsistencyLevel: 'Session'
    }
    locations: [
      {
        locationName: resourceGroup().location
        failoverPriority: 0
      }
    ]
    isVirtualNetworkFilterEnabled: true
    virtualNetworkRules: [
      {
        id: vnetDataSubNetId
        ignoreMissingVNetServiceEndpoint: false
      }
    ]
    ipRules: [
      {
        ipAddressOrRange: '174.84.162.196'
      }
      {
        ipAddressOrRange: '104.42.195.92'
      }
      {
        ipAddressOrRange: '40.76.54.131'
      }
      {
        ipAddressOrRange: '52.176.6.30'
      }
      {
        ipAddressOrRange: '52.169.50.45'
      }
      {
        ipAddressOrRange: '52.187.184.26'
      }
    ]
  }
}

resource databases 'Microsoft.DocumentDB/databaseAccounts/apis/databases@2016-03-31' = {
  name: '${cosmosDb.name}/sql/${databaseName}'
  properties: {
    options: {
      throughput: '400'
    }
    resource: {
      id: databaseName
    }
  }
}

resource container 'Microsoft.DocumentDB/databaseAccounts/apis/databases/containers@2016-03-31' = {
  name: '${databases.name}/student'
  properties: {
    resource: {
      partitionKey: {
        kind: 'Hash'
        paths: [
          '/school/studentId'
        ]
      }
      id: 'student'
      indexingPolicy: {
        indexingMode: 'Consistent'
        includedPaths: [
          {
            path: '/*'
            indexes: [
              {
                kind: 'Hash'
                dataType: 'String'
                precision: -1
              }
            ]
          }
        ]
      }
    }
    options: {}
  }
}

output cosmosDbPrincipleId string = cosmosDb.identity.principalId

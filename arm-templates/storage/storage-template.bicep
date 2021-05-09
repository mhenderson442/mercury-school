param storageAccountName string
param vnetDataSubNetId string

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: storageAccountName
  location: resourceGroup().location
  identity: {
    type: 'SystemAssigned'
  }
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
    tier: 'Standard'
  }
  properties: {
    accessTier: 'Hot'
    supportsHttpsTrafficOnly: true
    allowBlobPublicAccess: true
    networkAcls: {
      bypass: 'AzureServices'
      resourceAccessRules: []
      defaultAction: 'Deny'
      ipRules: [
        {
          value: '174.84.162.196'
          action: 'Allow'
        }
      ]
      virtualNetworkRules: [
        {
          id: vnetDataSubNetId
          action: 'Allow'
          state: 'succeeded'
        }
      ]
    }
    encryption: {
      keySource: 'Microsoft.Storage'
      services: {
        blob: {
          keyType: 'Account'
        }
        file: {
          keyType: 'Account'
        }
        table: {
          keyType: 'Account'
        }
        queue: {
          keyType: 'Account'
        }
      }
    }
  }
}

resource blobServices 'Microsoft.Storage/storageAccounts/blobServices@2021-02-01' = {
  name: '${storageAccount.name}/default'
  properties: {
    cors: {
      corsRules: []
    }
    deleteRetentionPolicy: {
      enabled: false
    }
  }
}

resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-02-01' = {
  name: '${blobServices.name}/student'
  properties: {
    publicAccess: 'None'
    denyEncryptionScopeOverride: false
    defaultEncryptionScope: '$account-encryption-key'
  }
}

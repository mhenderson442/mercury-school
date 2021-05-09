param keyVaultName string
param adminPrincipleIds array
param vnetDataSubNetId string

var accessPolicies = [for objectId in adminPrincipleIds: {
  tenantId: subscription().tenantId
  objectId: objectId
  permissions: {
    secrets: [
      'get'
      'list'
      'set'
      'delete'
      'recover'
      'backup'
      'restore'
    ]
  }
}]

resource keyVault 'Microsoft.KeyVault/vaults@2018-02-14' = {
  name: keyVaultName
  location: resourceGroup().location
  properties: {
    tenantId: subscription().tenantId
    enabledForDeployment: false
    enabledForTemplateDeployment: true
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableSoftDelete: false
    enabledForDiskEncryption: false
    accessPolicies: accessPolicies
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Deny'
      ipRules: [
        {
          value: '174.84.162.196'
        }
      ]
      virtualNetworkRules: [
        {
          id: vnetDataSubNetId
        }
      ]
    }
  }
}

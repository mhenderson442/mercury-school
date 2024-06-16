targetScope = 'subscription'

param resourceGroupName string
param location string

param configStoreName string
param keyVaultName string

param sqlAdminSid string
param sqlLogin string

param sqlServerName string
param sqlDatabaseName string

param currentDate string = utcNow()

resource group 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
}

module configStore 'resource-templates/azure-app-config.bicep' = {
  scope: group
  name: 'config-store-deployment-${currentDate}'
  params: {
    configStoreName: configStoreName
    location: location
  }
}

module keyVault 'resource-templates/azure-keyvault.bicep' = {
  scope: group
  name: 'key-vault-deployment-${currentDate}'
  params: {
    keyVaultName: keyVaultName
    location: location
    tenantId: subscription().tenantId
  }
}

module sqlDatabase 'resource-templates/azure-sql-database.bicep' = {
  scope: group
  name: 'sql-database-deployment-${currentDate}'
  params: {
    location: location
    sqlAdminSid: sqlAdminSid
    sqlLogin: sqlLogin
    sqlServerName: sqlServerName
    tenantId: subscription().tenantId
    sqlDatabaseName: sqlDatabaseName
  }
}

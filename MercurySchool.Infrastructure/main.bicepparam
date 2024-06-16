using 'main.bicep'

@description('Datacenter location')
param location = 'northcentralus'

@description('Name of resource group')
param resourceGroupName = 'mercury-school-rg'

@description('Configuration storage name')
param configStoreName = 'mercury-school-config'

@description('Name of key  vault')
param keyVaultName = 'mercury-school-keyvault'

@description('Entra object id')
param sqlAdminSid = '7ee3c70b-db6c-4170-9222-b5c5d664c60e'

@description('Entra Group Name')
param sqlLogin = 'Henderson Research and Development'

@description('Name of Azure SQL database server resource')
param sqlServerName = 'mercury-school-sql-server'

param sqlDatabaseName = 'mercuryschool'

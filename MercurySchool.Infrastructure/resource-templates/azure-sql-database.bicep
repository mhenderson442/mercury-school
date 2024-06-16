param sqlServerName string
param location string
param tenantId string
param sqlLogin string
param sqlAdminSid string
param sqlDatabaseName string

resource sqlServer 'Microsoft.Sql/servers@2021-11-01' = {
  name: sqlServerName
  location: location
  identity: {
    type:'SystemAssigned'
  }
  properties:{
    version: '12.0'
    minimalTlsVersion: '1.2'    
    administrators: {
      administratorType: 'ActiveDirectory'
      azureADOnlyAuthentication: true
      principalType:'Group'
      tenantId: tenantId
      login: sqlLogin
      sid: sqlAdminSid
    }
  }
}

resource database 'Microsoft.Sql/servers/databases@2021-11-01' = {
  parent: sqlServer
  name: sqlDatabaseName
  location: location
  sku:{
    name: 'GP_S_Gen5_1'
    tier: 'GeneralPurpose'
  }
  properties:{
    autoPauseDelay: 60        
  }
}

resource firewallrules 'Microsoft.Sql/servers/firewallRules@2021-11-01' = {
  parent: sqlServer
  name: 'AllowAllWindowsAzureIps'
  properties: {
    endIpAddress: '0.0.0.0'
    startIpAddress: '0.0.0.0'
  }
}

param dnsZoneName string
param ventId string

resource dnsZone 'Microsoft.Network/privateDnsZones@2020-06-01' = {
  name: dnsZoneName
  location: 'global'
  properties: {}
}

resource privateDnsZoneSoa 'Microsoft.Network/privateDnsZones/SOA@2020-06-01' = {
  name: '${dnsZone.name}/@'
  properties: {}
}

resource virtualNetworkLink 'Microsoft.Network/privateDnsZones/virtualNetworkLinks@2020-06-01' = {
  name: '${dnsZone.name}/network-link.${dnsZone.name}'
  location: 'global'
  properties: {
    registrationEnabled: true
    virtualNetwork: {
      id: ventId
    }
  }
}

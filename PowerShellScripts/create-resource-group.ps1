$configurationFile = ".\ArmTemplates\configuration-map.json"
$configuration = Get-Content -Path $configurationFile -Raw | ConvertFrom-Json

$subscription = $configuration.subscriptions[0].id
$resourceGroup = $configuration.resourceGroups[0].name
$location = $configuration.resourceGroups[0].location

Write-Host $subscription

Write-Host "Checking if resource group $resourceGroup exists"
$resourceGroupExists = az group exists `
    --resource-group $resourceGroup `
    --subscription $subscription

if ($resourceGroupExists -eq $true) {
    Write-Host "Resource group $resourceGroup exists"
    Write-Host "Skipping create template"
}
else {
    Write-Host "Creating $resourceGroup."
    
    az group create `
        --name $resourceGroup `
        --location $location `
        --subscription $subscription
}    
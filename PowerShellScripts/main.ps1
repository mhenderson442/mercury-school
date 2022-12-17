
$configrutation = Get-Content -Path ".\resource-configuration-mapping.json" | ConvertFrom-Json

$resourceGroupExists = (az group exists --resource-group $configrutation.resourceGroup.name)

if($resourceGroupExists -eq $true){
    $message = "Resource Group {0} exists" -f $configrutation.resourceGroup.name
    Write-Host $message -BackgroundColor Blue -ForegroundColor Yellow

    Deploy-AzureResources($configrutation)

}

$message = "Create Resource Group {0}" -f $configrutation.resourceGroup.name
Write-Host $message -BackgroundColor Blue -ForegroundColor Yellow

$group = (az group create `
    --location $configrutation.resourceGroup.location `
    --resource-group $configrutation.resourceGroup.name) `
    | ConvertFrom-Json

$result = "Resource Group created: {0}" -f $group.properties.provisioningState
Write-Host $result -BackgroundColor Blue -ForegroundColor Yellow

if($group.properties.provisioningState -eq "Sucess"){
    Deploy-AzureResources($configrutation)

    Exit
}


function Deploy-AzureResources {
    param ($configrutation)
    
    $message = "Start {0} deployment" -f $configrutation.resourceGroup.name
    Write-Host $message -BackgroundColor Blue -ForegroundColor Yellow

    $buildId = [DateTimeOffset]::UtcNow.ToUnixTimeMilliseconds()
    $deploymentName = "{0}-deployment-{1}" -f $configrutation.resourceGroup.name, $buildId
    
    Write-Host $deploymentName -BackgroundColor Blue -ForegroundColor Yellow

    az deployment group what-if `
        --name $deploymentName `
        --resource-group $configrutation.resourceGroup.name `
        --template-file "./ArmTemplates/main.bicep" `
        --subscription (az account show | ConvertFrom-Json).id
}
$bicepFile = "main.bicep"
$resourceGroupName = "mercury-school"

az deployment group create -g $resourceGroupName -f $bicepFile -p resourceGroupName=$resourceGroupName
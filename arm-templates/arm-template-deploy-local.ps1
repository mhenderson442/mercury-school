$bicepFile = "main.bicep"
$resourceGroupName = "mercury-school"
$administratorLogin = "administratorLogin=mercdmin"
$administratorLoginPassword = "administratorLoginPassword=<enter admin password>"

az deployment group create -g $resourceGroupName -f $bicepFile --parameters $administratorLogin $administratorLoginPassword


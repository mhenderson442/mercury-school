param (    
    [Parameter(HelpMessage="Azure Subscription Id")]
    [string]$subscription
)

$timestamp = Get-Date -UFormat %s
$name = "mercury-school-deployment-$timestamp"

az deployment sub create `
--name $name `
--location "northcentralus" `
--output table `
--subscription $subscription `
--parameters .\main.bicepparam
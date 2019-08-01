param([string] $subscriptions)

Stop-Service -Name SensuAgent

$agenttext = Get-Content $env:SensuAgent/agent.yml

$newSubscriptions = 'subscriptions: ' + "`"" + "update_agent," +  $subscriptions + "`""

($agenttext -replace 'subscriptions.+ ".+"',$newSubscriptions) | Out-File $env:SensuAgent/agent.yml

Start-Service -Name SensuAgent
$logo = (Invoke-WebRequest "https://raw.githubusercontent.com/FantasticFiasco/logo/master/logo.raw").toString();
Write-Host "$logo" -ForegroundColor Green

& dotnet build

if ($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode)  }

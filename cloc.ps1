Write-Host ((git ls-files).Split() | ForEach {get-content $_} | measure-object).Count Lines of Code
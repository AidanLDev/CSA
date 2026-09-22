# Calculator

## Running it locally

To use the Azure Speech Service we need a key to that service, in-order to not expose the secret key I used:
`dotnet user-secrets set "SpeechService:key" "key_here"`
`dotnet user-secrets set "SpeechService:region" "region_here"`

I then added the following package to read the key:
`dotnet add package Microsoft.Extensions.Configuration.UserSecrets`

Run the actual project from `Microsoft.Calculator`, this uses the `Microsoft.Calculator.CalculatorLibrary` for doing the logging/calculation logic.

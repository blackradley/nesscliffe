::
:: Run all the tests
::
casperjs --baseUrl="https://blackradley-insight-develop.azurewebsites.net" --ignore-ssl-errors=true --web-security=false --verbose=true --loglevel=debug test ./tests
pause
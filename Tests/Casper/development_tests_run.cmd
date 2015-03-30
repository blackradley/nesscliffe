::
:: Run all the tests
::
casperjs --baseUrl="https://localhost:44300/" --ignore-ssl-errors=true --web-security=false --verbose=true --loglevel=debug test ./tests
pause
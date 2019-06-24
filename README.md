# Basic Payment Gateway From Scratch

The following was tested on Windows machine only.

# Prerequisites To install
1. Docker
2. Docker Compose

# Steps To Install
1. Run "docker-compose build".
2. Run "docker-compose up".
3. Go to database folder and run the file "run.sh" or Connect Sql Server "localhost,1434" and run the sql files.

# How To Use
1. On Browser, Go to http://localhost:8000.
2. Create a Merchant with Username and Password, example: Username=test,Password=test.
3. On Browser, Go to http://localhost:8080, a swagger UI will open to test the API.
4. Try out, "/api/v1/Auth" endpoint, and enter Username and Password.
5. In the Response Body, Copy the bearer token, example: ewfndjghg...
6. Click on "Authorize" at top of page and in the value field enter "bearer " followed by the access token, example: bearer ewfndjghg...
7. Click "Authorize" and Click "Close".
8. Try out "/api/v1/Payment" endpoint with PUT method. Enter any UserEmail, UserId should be an empty Guid, enter the following value "00000000-0000-0000-0000-000000000000", to create a new user. This will create a new userId automatically if email does not exist. Example: 16d405cf-d2c6-4ca4-b71a-e93ce190e5d4
9. Copy the UserId received in the response. Try out "/api/v1/Payment" endpoint with POST method. Fill the fields, with the user Id being the one copied previously.
10. Note that there are only 2 payment method implemented: "CreditCard" and "EWallet". 
11. The values field should contain a serialized json string with the following attributed based on "paymentMethod":
    #### Credit Card
        {'CardNumber':'test','FullName':'Bruce','Address':'Gotham','ExpiryMonth':'12','ExpiryYear':'25','CVC':'test'}
    #### EWallet
        {'Username':'Bruce','Password':'Campbell'}
    ##### Complete Request Body Example For Credit Card Payment:
        {"PaymentMethod":"CreditCard","Values":"{'CardNumber':'test','FullName':'Bruce','Address':'Gotham','ExpiryMonth':'12','ExpiryYear':'25','CVC':'test'}","Amount":9000,"UserId":"28279ef7-ae15-48b4-9fe8-39c96f6a8c6a","Details":"book"}
12. Response body should say "Success".
13. Try out to get list of payments for merchant. Endpoint "/api/v1/Payment" WIth GET method.


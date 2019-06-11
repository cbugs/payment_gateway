#!/bin/bash

set -e

sqlcmd -S localhost,1434 -U sa -P Ax+themA -i initdb.sql
sqlcmd -S localhost,1434 -U sa -P Ax+themA -i merchantdb.sql
sqlcmd -S localhost,1434 -U sa -P Ax+themA -i paymentgatewaydb.sql
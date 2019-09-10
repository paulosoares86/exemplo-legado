# Running Docker

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd" \
   -p 1433:1433 \
   mcr.microsoft.com/mssql/server:2017-latest
 ```

# Run DBScript.sql
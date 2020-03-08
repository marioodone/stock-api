# stock-api
This API stores info about stocks to be used as a repositoy of historic of market prices.

### Configuration
The only configuration required is the sqLite database path. 
On appsettings.json, make sure the app accesses the paths in:
```
DBInfo": {
    "ConnectionString": "Data Source=C:\\SQLITEDATABASES\\SQLITEDB1.sqlite;",
    "FilePath": "C:\\SQLITEDATABASES\\SQLITEDB1.sqlite",
    "FileDirectory": "C:\\SQLITEDATABASES\\"
  }
  ```

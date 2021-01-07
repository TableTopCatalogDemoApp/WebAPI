# Data.Design

## Add new migration
```
dotnet ef migrations add InitializeDb `
	--project .\TableTopCatalogDemoApp.Data\TableTopCatalogDemoApp.Data.csproj `
	--startup-project .\TableTopCatalogDemoApp.Data.Design\TableTopCatalogDemoApp.Data.Design.csproj
```

## Generate SQL script
```
dotnet ef migrations script `
	--project .\TableTopCatalogDemoApp.Data\TableTopCatalogDemoApp.Data.csproj `
	--startup-project .\TableTopCatalogDemoApp.Data.Design\TableTopCatalogDemoApp.Data.Design.csproj `
	--output database.sql `
	--idempotent
```

## Run data seeding
```
dotnet `
	.\TableTopCatalogDemoApp.Data.Design.dll `
	"Server=(localdb)\mssqllocaldb;Database=TableTopData"
```
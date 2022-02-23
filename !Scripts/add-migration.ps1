$targetProject = ".\..\PickPoint.TestTask.Storage"
$startupProject = ".\..\PickPoint.TestTask.WebApi"

# do not forget set migration name
$migrationName = "CreateSchema";

if ($migrationName -eq "") {
    Write-Error "Error: migration name is not set"
} else {
    dotnet-ef migrations add $migrationName -s $startupProject -p $targetProject -c DbContextMsSql --output-dir Migrations\SqlServerMigrations
}
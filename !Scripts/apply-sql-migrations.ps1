$targetProject = ".\..\PickPoint.TestTask.Storage"
$startupProject = ".\..\PickPoint.TestTask.WebApi"

dotnet-ef.exe database update -s $startupProject -p $targetProject -c DbContextMsSql
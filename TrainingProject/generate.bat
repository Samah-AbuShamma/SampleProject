dotnet ef dbcontext scaffold "Data Source=Localhost; Initial Catalog=TrainingDB;Trusted_Connection=True;" ^
Microsoft.EntityFrameworkCore.SqlServer ^
-o ./Models ^
-c TrainingDBContext -d -f
pause
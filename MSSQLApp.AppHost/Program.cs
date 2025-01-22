var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MSSQLApp>("mssqlapp");

builder.Build().Run();

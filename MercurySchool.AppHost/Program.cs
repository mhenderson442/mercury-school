var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MercurySchool_Api>("webapi");

builder.Build().Run();
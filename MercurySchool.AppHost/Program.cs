var builder = DistributedApplication.CreateBuilder(args);

// var applicationService = builder.AddProject<Projects.MercurySchool_Api>("webapi");

builder.AddProject<Projects.MercurySchool_Api>("webapi");

builder.Build().Run();
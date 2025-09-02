var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Behesys_ApiService>("apiservice");

builder.AddProject<Projects.Behesys_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();

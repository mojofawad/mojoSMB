using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var api = builder.AddProject<Projects.mojoSMB_Api>("api");

builder.AddProject<Projects.mojoSMB_Web>("web")
    .WithReference(api);

// TODO: Figure out "failed to start executable" issue when launching from Rider in Fedora 40

builder.Build().Run();
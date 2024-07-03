var builder = DistributedApplication.CreateBuilder(args);

// builder.AddServiceDefaults();

var api = builder.AddProject<Projects.mojoSMB_Api>("api");

// TODO: Add volume to the database container
var db = builder.AddPostgres("postgres").AddDatabase("db");

builder.AddProject<Projects.mojoSMB_Web>("web")
    .WithReference(api);

builder.Build().Run();
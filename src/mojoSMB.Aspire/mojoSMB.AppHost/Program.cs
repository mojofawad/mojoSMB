var builder = DistributedApplication.CreateBuilder(args);

// builder.AddServiceDefaults();

// TODO: Add volume to the database container
var postgres = builder.AddPostgres("postgres");
var apidb = postgres.AddDatabase("apidb");

var api = builder.AddProject<Projects.mojoSMB_Api>("api")
    .WithReference(apidb);


builder.AddProject<Projects.mojoSMB_Web>("web")
    .WithReference(api);

builder.Build().Run();
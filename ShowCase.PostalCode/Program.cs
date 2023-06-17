using Microsoft.AspNetCore.Hosting;
using ShowCase.PostalCode;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup();

startup.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

startup.Configure(app, app.Environment);
app.Run();
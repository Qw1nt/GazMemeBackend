global using FastEndpoints;
global using FastEndpoints.Security;
using Application;
using FastEndpoints.Swagger;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddFastEndpoints();

services.AddApplicationServices(configuration);
services.AddInfrastructureServices(configuration);

services.SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
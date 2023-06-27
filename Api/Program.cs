global using FastEndpoints;
using Application;
using FastEndpoints.Swagger;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddApplicationServices(configuration);
services.AddInfrastructureServices(configuration);

services.AddCors(p => p.AddPolicy("CORSApp", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

services.AddSingleton(builder.Environment);
services.AddFastEndpoints();
services.SwaggerDocument();


var app = builder.Build();


app.UseCors("CORSApp");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
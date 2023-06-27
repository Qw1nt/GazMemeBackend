global using FastEndpoints;
global using FastEndpoints.Security;
using Application;
using FastEndpoints.Swagger;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddSingleton(builder.Environment);
services.AddFastEndpoints();

services.AddApplicationServices(configuration);
services.AddInfrastructureServices(configuration);
services.SwaggerDocument();
services.AddCors(p => p.AddPolicy("CORSApp", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


app.UseHttpsRedirection();

app.UseCors("CORSApp");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
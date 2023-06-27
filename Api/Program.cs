global using FastEndpoints;
using Application;
using FastEndpoints.Swagger;
using Infrastructure;
using NSwag;

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
services.SwaggerDocument(/*x => x.DocumentSettings = options =>
{
    options.PostProcess = document =>
    {
        document.Servers.Clear();
        document.Servers.Add(new OpenApiServer()
        {
            Url = "https://clothing-store-ek.ru/"
        });
    };
}*/);


var app = builder.Build();


app.UseCors("CORSApp");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen(x => x.PostProcess = (document, request) =>
{
    document.Servers.Clear();
    document.Servers.Add(new OpenApiServer()
    {
        Url = "https://clothing-store-ek.ru/"
    });
});

app.Run();
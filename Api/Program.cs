global using FastEndpoints;
using Application;
using Application.Common.Interfaces;
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
services.SwaggerDocument();


var app = builder.Build();


app.UseCors("CORSApp");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints(c => c.Binding.Modifier = (req, tReq, ctx, ct) =>
{
    if (req is IHasFiles r)
    {
        
    }
});
app.UseSwaggerGen(x => x.PostProcess = (document, request) =>
{
    document.Servers.Clear();
    document.Servers.Add(new OpenApiServer()
    {
        Url = "https://clothing-store-ek.ru/"
    });
});

app.Run();
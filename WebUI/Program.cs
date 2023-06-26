using Application.Common.Persistence;
using Application.Common.Services;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddDbContext<ApplicationDataContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(Constants.DatabaseSection));
});
services.AddCoreAdmin();
services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.UseCoreAdminCustomTitle("Панель администратора");
app.UseCoreAdminCustomUrl("admin");
// app.UseCoreAdminCustomAuth();

app.MapDefaultControllerRoute();
app.Run();
using Microsoft.EntityFrameworkCore;
using UrlApp.BusinessLogic.Interfaces;
using UrlApp.BusinessLogic.Services;
using UrlApp.DAL.Interfaces;
using UrlApp.DAL.Repositorys;
using UrlApp.Models;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(10, 3, 39));

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IUrlService, UrlService>();
builder.Services.AddTransient<IGeneratorService, GeneratorService>();

builder.Services.AddTransient<IUrlRepository, UrlRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var applicationContext = scope.ServiceProvider
        .GetRequiredService<ApplicationContext>();
    
    applicationContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Url}/{action=Index}/{id?}");

app.MapFallbackToController("Get", "Url");

app.Run();
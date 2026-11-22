using FridgeTrack.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FridgeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FridgeDb")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FridgeContext>();
    context.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Alimentos}/{action=Index}/{id?}");

app.Run();

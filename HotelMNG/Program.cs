using HotelMNG.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Qlks3Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "rooms",
    pattern: "rooms",
    defaults: new { controller = "Home", action = "Rooms" });

app.MapControllerRoute(
    name: "about-us",
    pattern: "about-us",
    defaults: new { controller = "Home", action = "AboutUs" });

app.MapControllerRoute(
    name: "contact",
    pattern: "contact",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "blog",
    pattern: "blog",
    defaults: new { controller = "Home", action = "Blog" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "room-detail",
    pattern: "room-detail/{name}",
    defaults: new { controller = "Room", action = "RoomDetail" });

app.MapControllerRoute(
    name: "blogs",
    pattern: "blogs",
    defaults: new { controller = "Blog", action = "Index" });

app.MapControllerRoute(
    name: "blog-detail",
    pattern: "{alias}",
    defaults: new { controller = "Blog", action = "BlogDetail" });

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();

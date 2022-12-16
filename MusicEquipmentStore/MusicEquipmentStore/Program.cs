using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using MusicEquipmentStore.Context;
//using MusicEquipmentStore.Data;
//using MusicEquipmentStore.Services;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<MusicEquipmentStoreContext>();
//builder.Services.AddScoped<IProductService, ProductService>();

// Add services to the authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.ExpireTimeSpan = TimeSpan.FromMinutes(60 * 1);
        option.LoginPath = "/Home/Login";
        option.AccessDeniedPath = "/Home/Login";
    });

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});



app.MapControllerRoute(
    name: "products",
    pattern: "/products/{categorySlug?}",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<MusicEquipmentStoreContext>();
ProductData.ProductDatabase(context);

app.Run();



using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:MyDBConnection"]);
});

builder.Services.AddScoped<IMyDBRepository, MyDBRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IMyDBRepository, MyDBRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("categoryPage", "{category}/Page{currentPage:int}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{currentPage:int}", new { Controller = "Home", action = "Index", currentPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", currentPage = 1 });
app.MapControllerRoute("default", "Products/Page{currentPage}", new { Controller = "Home", action = "Index", currentPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

MyData.InitData(app);

app.Run();
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:MyDBConnection"]);
});

builder.Services.AddScoped<IMyDBRepository, MyDBRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

MyData.InitData(app);

app.Run();
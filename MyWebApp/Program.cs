var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Service는 Application전역과 의존성 주입(Dependency Injection)이라는 기능을 통해 Access 할수 있는
//Service객체의 설정을 위해 사용되는데 여기서 AddControllersWithViews() Method는 MVC Framework와 Razor View Engine을
//사용하는 Application에서 필요로 하는 공유 객체를 설정합니다.

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Service�� Application������ ������ ����(Dependency Injection)�̶�� ����� ���� Access �Ҽ� �ִ�
//Service��ü�� ������ ���� ���Ǵµ� ���⼭ AddControllersWithViews() Method�� MVC Framework�� Razor View Engine��
//����ϴ� Application���� �ʿ�� �ϴ� ���� ��ü�� �����մϴ�.

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
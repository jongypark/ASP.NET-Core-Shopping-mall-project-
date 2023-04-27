using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public static class MyData
    {
        public static void InitData(IApplicationBuilder app)
        {
            MyDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MyDbContext>();

            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Intel CPU",
                    Description = "최신 20세대 프로세서",
                    Category = "Computer",
                    Price = 1000
                },
                new Product
                {
                    Name = "Memory",
                    Description = "5000Mz 짜리",
                    Category = "Computer",
                    Price = 1500
                },
                new Product
                {
                    Name = "Mainboard",
                    Description = "최신 Serial Port 있음",
                    Category = "Computer",
                    Price = 2000
                },
                new Product
                {
                    Name = "Printer",
                    Description = "8bit 흑백",
                    Category = "Peripheral",
                    Price = 5000
                },
                new Product
                {
                    Name = "Mouse",
                    Description = "부드러운 볼 탑재",
                    Category = "Peripheral",
                    Price = 1500
                },
                new Product
                {
                    Name = "CPU",
                    Description = "Computer1",
                    Category = "Computer",
                    Price = 2000
                },
                new Product
                {
                    Name = "Printer",
                    Description = "Peripheral1",
                    Category = "Peripheral",
                    Price = 5000
                },
                new Product
                {
                    Name = "HardWare",
                    Description = "Computer2",
                    Category = "Computer",
                    Price = 2000
                },
                new Product
                {
                    Name = "Printer",
                    Description = "Peripheral2",
                    Category = "Peripheral",
                    Price = 5000
                },
                new Product
                {
                    Name = "CPU",
                    Description = "Computer13",
                    Category = "Computer",
                    Price = 2000
                },
                new Product
                {
                    Name = "Printer",
                    Description = "Peripheral3",
                    Category = "Peripheral",
                    Price = 5000
                },
                new Product
                {
                    Name = "Ram",
                    Description = "Computer4",
                    Category = "Computer",
                    Price = 2000
                },
                new Product
                {
                    Name = "Printer",
                    Description = "Peripheral4",
                    Category = "Peripheral",
                    Price = 5000
                });
            }

            context.SaveChanges();
        }
    }
}
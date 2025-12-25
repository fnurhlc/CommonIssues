using CommonIssues.Models; // DbContext erişimi
using Microsoft.EntityFrameworkCore; // EF Core SQL Server

var builder = WebApplication.CreateBuilder(args); // Uygulama yapılandırması

builder.Services.AddControllersWithViews(); // MVC servisleri

/*builder.Services.AddDbContext<CommonIssuesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
); // Veritabanı bağlantısı*/

var app = builder.Build(); // Uygulama oluşturulur

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hata sayfası
    app.UseHsts(); // Güvenlik
}

app.UseHttpsRedirection(); // HTTPS yönlendirme
app.UseStaticFiles(); // CSS / JS
app.UseRouting(); // Routing
app.UseAuthorization(); // Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Issues}/{action=Index}/{id?}"
); // Varsayılan route

app.Run(); // Uygulama çalışır

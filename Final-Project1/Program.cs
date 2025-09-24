using Final_Project1.Entities;
using Final_Project1.Repositories;
using Karl.BL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));

builder.Services.AddScoped(typeof(IRepository<>),typeof(DATARepository<>));
builder.Services.AddScoped<IFileService, FileService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
    opt.LoginPath = "/admin/login"; 
    opt.LogoutPath = "/admin/logout"; 


}

);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/hata/{0}");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=Landing}/{id?}");
app.MapControllers();

app.Run();
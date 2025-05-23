﻿using Client.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký HttpClient cho AccountService
builder.Services.AddHttpClient<AccountService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7145/api/"); // Cập nhật URL API của bạn
});
builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7145/api/"); // Thay port theo API server của bạn
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Home/AccessDenied";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.None;   // ⟵ giống trên
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
});


builder.Services.AddAuthorization();
builder.Services.AddTransient<UserService, UserService>();
builder.Services.AddScoped<ImageService, ImageService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

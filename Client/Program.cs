using Client.JWT;
using Client.Services;
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
    client.BaseAddress = new Uri("https://localhost:7145/api/"); // Thay bằng base URL thật của API bạn
});

// Đăng ký AccountService vào DI container
builder.Services.AddScoped<AccountService>();

// Đăng ký Authentication (nếu có)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Chuyển hướng khi chưa đăng nhập
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Home/AccessDenied"; // Trang lỗi quyền truy cập
    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.Events = new JwtBearerEvents
       {
           OnMessageReceived = context =>
           {
               // Đọc JWT từ cookie
               var accessToken = context.Request.Cookies["access_token"];
               if (!string.IsNullOrEmpty(accessToken))
               {
                   context.Token = accessToken;
               }
               return Task.CompletedTask;
           }
       };

       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidAudience = builder.Configuration["AuthSettings:Audience"],
           ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
        GetBytes(builder.Configuration["AuthSettings:Key"])),
       };
   });

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ImageService, ImageService>();

var app = builder.Build();

// Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<JWTMiddleware>(); // Thêm vào trước `app.UseAuthentication();`
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

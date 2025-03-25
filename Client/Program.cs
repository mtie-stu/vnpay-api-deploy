using Client.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký HttpClient cho AccountService
builder.Services.AddHttpClient<AccountService>(client =>
{
	client.BaseAddress = new Uri("https://your-api.com/"); // Cập nhật URL API của bạn
});

// Đăng ký AccountService vào DI container
builder.Services.AddScoped<AccountService>();

// Đăng ký Authentication (nếu có)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Account/Login";
		options.LogoutPath = "/Account/Logout";
	});

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

app.UseRouting();

app.UseAuthentication(); // Quan trọng: Thêm Authentication trước Authorization
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

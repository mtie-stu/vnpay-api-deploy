using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PDP104.Data;
using PDP104.Models;
using PDP104.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddControllers().AddJsonOptions(options =>

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
    System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});
});*/
// Đăng ký ApplicationDbContext với SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddTransient<IWareHousesSvc, WareHouseSvc>();
builder.Services.AddTransient<IStorageSpacesSvc, StorageSpaceSvc>();
builder.Services.AddTransient<IServicesSvc, ServicesSvc>();
builder.Services.AddTransient<IUserStorageOrder, UserStorageOrderSvc>();
builder.Services.AddTransient<IAdminStorageOrderSvc, Admin_StorageOrderSvc>();
builder.Services.AddTransient<IInvetorySvc, InventorySvc>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddIdentity<NguoiDung, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
/*
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters =
    new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["AuthSettings:Audience"],
        ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
        GetBytes(builder.Configuration["AuthSettings:Key"])),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax; // Cho phép cookie hoạt động trong cross-site
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Bắt buộc dùng HTTPS
        options.LoginPath = "/api/Authentication/loginGoogle";
        options.LogoutPath = "/api/Authentication/logout";
    })
   .AddGoogle(options =>
   {
       var googleAuth = builder.Configuration.GetSection("Authentication:Google");
       options.ClientId = googleAuth["ClientId"];
       options.ClientSecret = googleAuth["ClientSecret"];
       options.CallbackPath = "/api/Authentication/callback"; // Đường dẫn callback
       options.SaveTokens = true;
   });
*/
// 2) Chỉ gọi AddAuthentication một lần, thiết lập DefaultAuthenticateScheme là JWT
builder.Services
    .AddAuthentication(options =>
    {
        // Mỗi request MVC/App sẽ được xác thực bằng JWT scheme
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        // Nếu bạn dùng [Authorize] trên MVC controller, nó sẽ dùng JWT
    })
    // 3) Cấu hình JWT Bearer, nhưng OnMessageReceived sẽ lấy token từ cookie “JwtToken”
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
            ValidAudience = builder.Configuration["AuthSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                                           Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:Key"])),
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = ctx =>
            {
                // Lấy token từ cookie thay vì header
                var token = ctx.Request.Cookies["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    ctx.Token = token;
                return Task.CompletedTask;
            }
        };
    })
    // 4) Thêm tiếp CookieAuth (chỉ dùng để handle Login/Logout của Google)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.LoginPath = "/api/Authentication/loginGoogle";
        options.LogoutPath = "/api/Authentication/logout";
    })
    // 5) Và Google OAuth
    .AddGoogle(options =>
    {
        var googleAuth = builder.Configuration.GetSection("Authentication:Google");
        options.ClientId = googleAuth["ClientId"];
        options.ClientSecret = googleAuth["ClientSecret"];
        options.CallbackPath = "/api/Authentication/callback";
        options.SaveTokens = true;
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnly", policy =>
        policy.RequireRole("User"));

    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("https://localhost:7091", "https://localhost:7023")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

/*builder.Services.AddIdentity<NguoiDung, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();*/
// Add services to the container.
builder.Services.AddTransient<IWareHousesSvc, WareHouseSvc>();
builder.Services.AddScoped<IStorageSpacesSvc, StorageSpaceSvc>();
builder.Services.AddTransient<ITokenService, TokenService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}
// Configure the HTTP request pipeline.
// Hiển thị Swagger trong cả môi trường Production & Development
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

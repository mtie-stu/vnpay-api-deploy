using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PDP104.Data;
using PDP104.Models;
using PDP104.Service;

var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});*/

// Add services to the container.
builder.Services.AddTransient<IWareHousesSvc, WareHouseSvc>();
builder.Services.AddScoped<IStorageSpacesSvc, StorageSpaceSvc>();
builder.Services.AddTransient<IServicesSvc, ServicesSvc>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Đăng ký ApplicationDbContext với SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddIdentity<NguoiDung, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

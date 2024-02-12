using Bussiness_Logic_Layer.Interfaces;
using Bussiness_Logic_Layer.Services;
using Data_Access_Layer.Context;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<IStoreRepository, StoreRepository>();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IDbInitializerService, DbInitializerService>();

builder.Services.AddScoped<IStoreService, StoreService>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var dbInitializerService = serviceProvider.GetRequiredService<IDbInitializerService>();

    dbInitializerService.Seed().Wait();
}

app.MapGet("/", () => "Hello World!");

app.Run();

using Company.App.Services;
using Company.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Company.Infrastructure.Dapper;
using Company.Infrastructure.Repository;
using Company.Domain.Interfaces;
using Company.App.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("*", policy =>
    {
        policy.WithOrigins("http://localhost:5174")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddDbContext<CompanyDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=EmployeeExample;Username=postgres;Password=0017"));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IEmployeeDapper, EmployeeDapper>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IUnitService, UnitService>();

builder.Services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();
builder.Services.AddScoped<IEmployeeTaskService, EmployeeTaskService>();

builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("*");

app.UseAuthorization();

app.MapControllers();

app.Run();
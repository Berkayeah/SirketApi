using SirketApp.Business.Services;
using SirketApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using SirektApi;
using SirketApp.DataAccess.Dapper;
using SirketApp.DataAccess.Repository.Abstracts;
using SirketApp.DataAccess.Repository.Concretes;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
builder.Services.AddDbContext<SirketDbContext>(options =>
options.UseNpgsql("Host=localhost;Database=PersonelOrnegi;Username=postgres;Password=0017"));
builder.Services.AddScoped<IPersonelService, PersonelService>();
builder.Services.AddScoped<PersonelDapper>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();


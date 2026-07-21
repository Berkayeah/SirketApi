using Microsoft.EntityFrameworkCore;
using SirektApi;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SirketDbContext>(options =>
options.UseNpgsql("Host=localhost;Database=PersonelOrnegi;Username=postgres;Password=0017"));

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


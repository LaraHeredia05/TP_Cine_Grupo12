
using Microsoft.EntityFrameworkCore;
using Tpi_Cine_Grupo12.Models;
using Tpi_Cine_Grupo12.Interface.Contracts;
using Tpi_Cine_Grupo12.Interface.Implementations;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddScoped<ICineRepository, CineRepository>();

// Add services to the container.

builder.Services.AddControllers();
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

using API.DAL;
using API.services;
using API.services.implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 


builder.Services.AddHttpClient<INasaService>();

builder.Services.AddTransient<INasaService, NasaService>();


var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SpaceContext>(options =>
options.UseSqlServer(
             connString ));

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

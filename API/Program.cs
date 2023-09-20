using API.services;
using API.services.implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 


builder.Services.AddHttpClient<INasaService>();
builder.Services.AddHttpClient<IissDataService>();
builder.Services.AddHttpClient<IWorldMapService>();

builder.Services.AddTransient<INasaService, NasaService>();
builder.Services.AddTransient<IissDataService, issDataService>();
builder.Services.AddTransient<IWorldMapService,  WorldMapService>();

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

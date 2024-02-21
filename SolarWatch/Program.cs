using SolarWatch.Data;
using SolarWatch.Services;
using SolarWatch.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGeoCodingApi,GeoCodingApi>();
builder.Services.AddSingleton<IJsonProcessor,JsonProcessor>();
builder.Services.AddSingleton<ISunApi, SunApi>();
builder.Services.AddSingleton<ICityRepository, CityRepository>();
builder.Services.AddSingleton<ISunsetSunriseRepository, SunriseSunsetRepository>();
builder.Services.AddSingleton<GeoCoordinatesContext>();

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
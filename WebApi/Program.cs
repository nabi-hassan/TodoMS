using Applicaton.Helpers;
using Applicaton.Interfaces;
using Applicaton.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Create Logger from settings from appsettings.json
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.CreateLogger();
//Add Logger
Log.Logger = logger;
builder.Host.UseSerilog(logger);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection not found in configuration");
builder.Services.AddDbContext<AppDbContext>(options => options
.UseLazyLoadingProxies(true)
.UseSqlServer(connectionString));

// Adding Services with dependency injection (likely separate files for each service)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDataService, DataService>();

// Adding AutoMapper
var mapperConfig = new MapperConfiguration(o => o.AddProfile(new AutoMapperProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Adding Controllers
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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

app.UseMiddleware<ExceptionHandlingMiddleware>();

//Use Serilog
app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();

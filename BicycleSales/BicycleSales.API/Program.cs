using BicycleSales.API;
using BicycleSales.API.MapperProfiles;
using BicycleSales.API.Validation;
using BicycleSales.BLL;
using BicycleSales.BLL.Interfaces;
using BicycleSales.DAL;
using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using NLog;
using NLog.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Context>();

builder.Services.AddScoped<IAcceptanceManager, AcceptanceManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();

builder.Services.AddScoped<IMapperBLL, MapperBLL>();
builder.Services.AddScoped<IAcceptanceRepository, AcceptanceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ProductValidator>();

builder.Services.AddAutoMapper(typeof(MapperApiUserProfile), typeof(MapperApiShopProfile), typeof(MapperApiAcceptanceProfile), 
    typeof(MapperApiShipmentProfile), typeof(MapperApiProductProfile), typeof(MapperApiOrderProfile));

InjectLogger(builder);

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

void InjectLogger(WebApplicationBuilder builder)
{
    var config = new LoggingConfiguration();

    // Targets where to log to: File and Console
    var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "Logs.txt" };
    var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

    // Rules for mapping loggers to targets            
    var minLoggingLevelRule = new LoggingRule();
    minLoggingLevelRule.SetLoggingLevels(NLog.LogLevel.Warn, NLog.LogLevel.Fatal);

    config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
    config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logfile);
    config.AddRule(minLoggingLevelRule);

    // Apply config           
    LogManager.Configuration = config;

    var logger = LogManager.Setup().GetCurrentClassLogger();
    builder.Services.AddSingleton<NLog.ILogger>(logger);
}
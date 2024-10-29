using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using NlogDemo;

using NlogDemo.Controllers;
using NlogDemo.Log;
using System;
using System.Globalization;


//Logger _logger = LogManager.GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<BaseController_old>();
//builder.Services.AddTransient<BaseErrorLogger_old>();


//builder.Services.AddScoped<IBaseLogger,BaseLogger>();
builder.Services.AddTransient<BaseLogger>();

//builder.Services.AddTransient<BaseController_1>();
var logger = NLog.LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();
logger.Debug("Start Application");
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Error);
builder.Host.UseNLog();
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

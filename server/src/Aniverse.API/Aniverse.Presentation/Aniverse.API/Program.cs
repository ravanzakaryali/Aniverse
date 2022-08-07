using Aniverse.API.Middelwares;
using Aniverse.Application.Mappers;
using Aniverse.Application.Validators.Auth;
using Aniverse.Domain.Entities.Identity;
using Aniverse.Persistence;
using Aniverse.Persistence.Context;
using Aniverse.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:5500")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials();
                      });
});

builder.Services.AddControllers()
                .AddFluentValidation(fl => fl.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddMapperService();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseExceptionMiddelware();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
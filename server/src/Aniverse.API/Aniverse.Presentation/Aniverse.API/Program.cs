using Aniverse.API.Middelwares;
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
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddControllers()
                .AddFluentValidation(fl => fl.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddelware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.UseRouting();

app.MapControllers();

app.Run();
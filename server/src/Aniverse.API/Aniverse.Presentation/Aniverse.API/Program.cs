using Aniverse.API.Middelwares;
using Aniverse.Application.Validators.Auth;
using Aniverse.Persistence;
using Aniverse.Services;
using FluentValidation.AspNetCore;
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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseExceptionMiddelware();
app.UseRouting();
app.MapControllers();
app.Run();
using Aniverse.API.ColumnWriters;
using Aniverse.API.Middelwares;
using Aniverse.Application.Mappers;
using Aniverse.Application.Validators.Auth;
using Aniverse.Persistence;
using Aniverse.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpLogging;
using NpgsqlTypes;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("Database"), "Logs",
    needAutoCreateTable: true,
    columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"Timespan", new TimestampColumnWriter() },
        {"Message", new RenderedMessageColumnWriter()},
        { "MessageTemplate", new MessageTemplateColumnWriter()},
        {"Level",new LevelColumnWriter(true,NpgsqlDbType.Varchar)},
        {"LogEvent", new LogEventSerializedColumnWriter()},
        {"Username", new UsernameColumnWriter() },
        {"Exception", new ExceptionColumnWriter()},

    })
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

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

app.UseExceptionMiddelware();

app.UseSerilogRequestLogging();

app.UseHttpLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    string? username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("username", username);
    await next();
});
app.MapControllers();
app.Run();
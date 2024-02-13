using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;
using Jazani.Application.Cores.Contexts;
using Jazani.Infrastructure.Cores.Contexts;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        path: ".." + Path.DirectorySeparatorChar + "logapi.log",
        restrictedToMinimumLevel: LogEventLevel.Warning,
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;

});

// RouteOptions
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

// Application
builder.Services.AddAplicationService();


//Autofact
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfraestructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

// Api
builder.Services.AddTransient<ExceptionMiddleware>();


// FluentValidation
builder.Services
    .AddFluentValidationRulesToSwagger()
    .AddFluentValidationRulesToSwagger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
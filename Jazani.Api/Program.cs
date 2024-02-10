using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jazani.Application.Cores.Contexts;
using Jazani.Infrastructure.Cores.Contexts;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        path:".." + Path.DirectorySeparatorChar + "loggapi.log",
        restrictedToMinimumLevel:LogEventLevel.Warning,
        rollingInterval: RollingInterval.Day
    ).CreateLogger();


builder.Logging.AddSerilog(logger);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//infrastructure
//builder.Services.AddDbContext;
builder.Services.AddInfrastructureServices(builder.Configuration);

//domain-Infraestrcuture
//builder.Services.AddTransient<IAreaTypeRepository, AreaTypeRepository>();

//Application
builder.Services.AddAplicationService();


//AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfraestructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });



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

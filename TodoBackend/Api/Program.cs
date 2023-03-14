using Aplicacao;
using Aplicacao.Abstracoes;
using Aplicacao.Behaviors;
using Aplicacao.TodoItens.Comandos.CriarTodoItem;
using Dominio.Abstracoes;
using Infra;
using Infra.MessageBroker;
using Infra.Repositorios;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AplicacaoDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o => o.SchemaBehavior(MySqlSchemaBehavior.Ignore));
});

builder.Services.AddDbContext<AplicacaoDbContext>();

builder.Services.AddTransient<IEventBus, EventBus>();

builder.Services.AddAplicacao();

builder.Services.AddScoped<ITodoItemRepositorio, TodoItemRepositorio>();

builder.Services.AddScoped<IUnitOfWork>(
            factory => factory.GetRequiredService<AplicacaoDbContext>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MessageBrokerSettings>(
    builder.Configuration.GetSection("MessageBroker"));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<CriarTodoItemEventoConsumer>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.Host(new Uri(settings.Host), h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped(
    typeof(IPipelineBehavior<,>),
    typeof(LoggingPipelineBehavior<,>));

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AplicacaoDbContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

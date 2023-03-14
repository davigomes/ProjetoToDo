using MassTransit;
using Microsoft.Extensions.Logging;

namespace Aplicacao.TodoItens.Comandos.CriarTodoItem
{
    public class CriarTodoItemEventoConsumer : IConsumer<CriarTodoItemEvento>
    {
        private readonly ILogger<CriarTodoItemEventoConsumer> _logger;

        public CriarTodoItemEventoConsumer(ILogger<CriarTodoItemEventoConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CriarTodoItemEvento> context)
        {
            _logger.LogInformation("TodoItem criado: {@TodoItem}", context.Message);

            return Task.CompletedTask;
        }
    }
}

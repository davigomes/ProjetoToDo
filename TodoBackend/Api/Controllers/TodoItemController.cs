using Aplicacao.TodoItens.Comandos.CriarTodoItem;
using Aplicacao.TodoItens.Consultas.ObterTodoItens;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodoItens(CancellationToken cancellationToken)
        {
            var consulta = new ObterTodoItensConsulta();

            var todoItens = await _mediator.Send(consulta, cancellationToken);

            return Ok(todoItens);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTodoItem([FromBody] CriarTodoItemRequest criarTodoItemRequest, CancellationToken cancellationToken)
        {
            var comando = criarTodoItemRequest.Adapt<CriarTodoItemComando>();

            var todoItem = await _mediator.Send(comando, cancellationToken);

            return CreatedAtAction(nameof(ObterTodoItens), new { todoItem }, todoItem);
        }
    }
}

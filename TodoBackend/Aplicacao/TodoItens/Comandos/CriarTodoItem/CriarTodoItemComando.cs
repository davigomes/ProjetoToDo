using MediatR;

namespace Aplicacao.TodoItens.Comandos.CriarTodoItem
{
    public class CriarTodoItemComando : IRequest<CriarTodoItemResponse>
    {
        public string Descricao { get; set; } = string.Empty;        
    }
}

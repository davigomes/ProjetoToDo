using Dominio.Abstracoes;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.TodoItens.Consultas.ObterTodoItens
{
    public class ObterTodoItensConsultaHandler : IRequestHandler<ObterTodoItensConsulta, IEnumerable<ObterTodoItensResponse>>
    {
        private readonly ITodoItemRepositorio _todoItemRepositorio;

        public ObterTodoItensConsultaHandler(ITodoItemRepositorio todoItemRepositorio)
        {
            _todoItemRepositorio = todoItemRepositorio;
        }

        public async Task<IEnumerable<ObterTodoItensResponse>> Handle(ObterTodoItensConsulta request, CancellationToken cancellationToken)
        {
            var todoItens = await _todoItemRepositorio.GetTodoItensAsync(cancellationToken);

            return todoItens.Adapt<IEnumerable<ObterTodoItensResponse>>();
        }
    }
}

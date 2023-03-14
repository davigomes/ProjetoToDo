using Aplicacao.Abstracoes;
using Dominio.Abstracoes;
using Dominio.Entidades;
using Mapster;
using MediatR;

namespace Aplicacao.TodoItens.Comandos.CriarTodoItem
{
    public class CriarTodoItemComandoHandler : IRequestHandler<CriarTodoItemComando, CriarTodoItemResponse>
    {
        private readonly ITodoItemRepositorio _todoItemRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;

        public CriarTodoItemComandoHandler(
            ITodoItemRepositorio todoItemRepositorio,
            IUnitOfWork unitOfWork,
            IEventBus eventBus)
        {
            _todoItemRepositorio = todoItemRepositorio;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

        public async Task<CriarTodoItemResponse> Handle(CriarTodoItemComando request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem(Guid.NewGuid(), request.Descricao);

            _todoItemRepositorio.Inserir(todoItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _eventBus.PublishAsync(new CriarTodoItemEvento
            {
                Id = todoItem.Id,
                Data = todoItem.Data,
                Descricao = todoItem.Descricao,
                Status = todoItem.Status
            });

            

            return todoItem.Adapt<CriarTodoItemResponse>();
        }
    }
}

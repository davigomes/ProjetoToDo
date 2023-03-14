using Dominio.Abstracoes;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class TodoItemRepositorio : ITodoItemRepositorio
    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        public TodoItemRepositorio(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItensAsync(CancellationToken cancellationToken)
        {
            return await _aplicacaoDbContext.Set<TodoItem>().ToListAsync(cancellationToken);
        }

        public void Inserir(TodoItem todoItem)
        {
            _aplicacaoDbContext.Set<TodoItem>().Add(todoItem);
        }
    }
}

using Dominio.Entidades;

namespace Dominio.Abstracoes
{
    public interface ITodoItemRepositorio
    {
        void Inserir(TodoItem todoItem);

        Task<IEnumerable<TodoItem>> GetTodoItensAsync(CancellationToken cancellationToken);
    }
}

namespace Aplicacao.TodoItens.Comandos.CriarTodoItem
{
    public class CriarTodoItemResponse
    {
        public string Descricao { get; private set; } = string.Empty;
        public DateTime Data { get; private set; }
        public bool Status { get; private set; }
    }
}

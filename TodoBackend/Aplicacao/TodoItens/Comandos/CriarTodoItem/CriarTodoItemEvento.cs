namespace Aplicacao.TodoItens.Comandos.CriarTodoItem
{
    public class CriarTodoItemEvento
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public bool Status { get; set; }
    }
}

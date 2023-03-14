using Dominio.Base;

namespace Dominio.Entidades
{
    public sealed class TodoItem : Entidade
    {
        public TodoItem(Guid id, string descricao)
            :base(id)
        {
            Descricao = descricao;
            Data = DateTime.UtcNow;
            Status = false;
        }

        private TodoItem() { }

        public string Descricao { get; private set; } = string.Empty;
        public DateTime Data { get; private set; }
        public bool Status { get; private set; }
    }
}

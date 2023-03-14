namespace Dominio.Base
{
    public abstract class Entidade
    {
        protected Entidade(Guid id) => Id = id;

        protected Entidade()
        {
        }

        public Guid Id { get; protected set; }
    }
}

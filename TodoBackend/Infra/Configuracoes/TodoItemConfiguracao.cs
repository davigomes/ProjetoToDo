using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuracoes
{
    public class TodoItemConfiguracao : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItem");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(50).IsRequired();
            builder.Property(p => p.Data).HasColumnName("Data").IsRequired();
            builder.Property(p => p.Status).HasColumnName("Status").IsRequired();
        }
    }
}

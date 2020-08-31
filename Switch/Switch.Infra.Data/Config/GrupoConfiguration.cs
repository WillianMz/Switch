using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        //Configuração de mapeamento de forma explicita
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Nome)
                            .IsRequired()
                            .HasMaxLength(100);
            builder.Property(g => g.Descricao)
                            .IsRequired()
                            .HasMaxLength(200);
            
        }
    }
}

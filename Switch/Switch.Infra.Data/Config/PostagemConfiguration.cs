using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class PostagemConfiguration : IEntityTypeConfiguration<Postagem>
    {
        //Configuração de mapeamento de forma explicita
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPublicacao).IsRequired();

            builder.Property(p => p.Texto)
                            .IsRequired()
                            .HasMaxLength(400);
            
            //postagem so pode ter 1 unico usuario, um usuario pode ter muitas postagens
            builder.HasOne(p => p.Usuario).WithMany(u => u.Postagens);

        }

    }
}

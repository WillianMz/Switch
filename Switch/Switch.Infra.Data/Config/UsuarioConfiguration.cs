﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        //Configuração de mapeamento de forma explicita
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Nome)
                            .HasMaxLength(400)
                            .IsRequired();

            builder.Property(u => u.Sobrenome)
                             .HasMaxLength(400)
                             .IsRequired();

            builder.Property(u => u.Senha)
                            .HasMaxLength(400)
                            .IsRequired();

            builder.Property(u => u.Sexo)
                            .IsRequired();
            
            builder.Property(u => u.UrlFoto)
                            .HasMaxLength(400)
                            .IsRequired();

            builder.Property(u => u.DataNascimento)
                            .IsRequired();
            
            builder.Property(u => u.Email)
                            .HasMaxLength(400)
                            .IsRequired();
            
            //relacionamento 1 para 1
            builder.HasOne(u => u.Identificacao)
                            .WithOne(i => i.Usuario)
                            .HasForeignKey<Identificacao>(i => i.UsuarioId);

            //relacionamento 1 para N
            //builder.HasMany(u => u.Postagens).WithOne(p => p.Usuario);
            builder.HasMany(u => u.Comentarios).WithOne(c => c.Usuario);
            builder.HasMany(u => u.Amigos).WithOne(a => a.Usuario);
            builder.HasMany(u => u.Postagens).WithOne(p => p.Usuario);
            builder.HasMany(u => u.UsuarioGrupos).WithOne(p => p.Usuario);
            builder.HasOne(u => u.StatusRelacionamento);
            builder.HasOne(u => u.ProcurandoPor);
        }
    }
}

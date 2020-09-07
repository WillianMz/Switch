using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Infra.Data.Config;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        //conf. o mapeamento por convensão, as tabelas são criadas automaticamente pelo EF
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagems { get; set; }
        public DbSet<StatusRelacionamento> StatusRelacionamento { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Identificacao> Identificacao { get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }

        public SwitchContext(DbContextOptions options) : base(options)
        {

        }

        //FluentAPI
        //precisar estar na classe que possui herança do DbContext
        //Faz a sobreposição
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioGrupoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}

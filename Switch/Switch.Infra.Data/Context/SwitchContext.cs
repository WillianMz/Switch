using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Infra.Data.Config;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        //conf. o mapeamento por convensão, as tabelas são criadas automaticamente pelo EF
        public DbSet<Usuario> Usuarios { get; set; }

        public SwitchContext(DbContextOptions options) : base(options)
        {

        }

        //FluentAPI
        //precisar estar na classe que possui herança do DbContext
        //Faz a sobreposição
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}

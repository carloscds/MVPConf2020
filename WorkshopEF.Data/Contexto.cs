using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WorkshopEF.Data.Dominio;

namespace WorkshopEF.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Dictionary<string, object>> Configuracao => Set<Dictionary<string, object>>("Configuracao");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);

            modelBuilder.SharedTypeEntity<Dictionary<string,object>>("Configuracao", f =>
            {
                f.Property<int>("Id");
                f.Property<string>("Config");
                f.Property<string>("Valor");
            });
        }
    }
}

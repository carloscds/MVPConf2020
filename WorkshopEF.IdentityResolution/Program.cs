using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Workshop.IdentityResolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();

            using var db = new ExemploContexto();
            Console.WriteLine("Banco Criado..");

            var consulta = db
               .Departamentos
               .Include(p => p.Funcionarios);

            var script = consulta.ToQueryString();

            var departamentos = db
                .Departamentos
                .Include(p => p.Funcionarios)
                .AsNoTrackingWithIdentityResolution()
                .ToList();

            Console.WriteLine("Finalizado..");
        }

        static void Setup()
        {
            using var db = new ExemploContexto();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var departamento = new Departamento
            {
                Descricao = "Departamento ",
                Funcionarios = Enumerable.Range(1, 100)
                .Select(x => new Funcionario
                {
                    Nome = $"Funcionario {x}"
                }).ToList()
            };

            db.Departamentos.Add(departamento);
            db.SaveChanges();
        }
    }




    public class Departamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }

    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }

    public class ExemploContexto : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Departamento> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlite("Data Source=identity-resolution.db");
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Workshop.SplitQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new ExemploContexto();
            Setup(db);
            Console.WriteLine("Banco Criado..");

            var departamentos = db.Departamentos.Include(p => p.Funcionarios).ToList();
            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao}");

                foreach (var funcionario in departamento.Funcionarios)
                {
                    Console.WriteLine($"\t - {funcionario.Nome}");
                }
            }

            Console.WriteLine("Finalizado..");
        }

        static void Setup(ExemploContexto db)
        {
            if (db.Database.EnsureCreated())
            {
                var departamentos = Enumerable.Range(1, 2)
                .Select(p => new Departamento
                {
                    Descricao = "Departamento " + p,
                    Funcionarios = Enumerable.Range(1, 10)
                    .Select(x => new Funcionario
                    {
                        Nome = $"Funcionario {p}-{x}"
                    }).ToList()
                }).ToList();

                db.Departamentos.AddRange(departamentos);

                db.SaveChanges();
            }
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
                .UseSqlite("Data Source=split-query.db");
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace WorkshopEF.ScriptComTransacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ExemploContexto : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlite("Data Source=teste.db");
    }
}

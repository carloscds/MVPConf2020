using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Workshop.ContadoresDeEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            var processId = Process.GetCurrentProcess().Id;// Environment.ProcessId;
            Console.WriteLine($"Iniciando processo: {processId}");

            using var db = new ExemploContexto();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.WriteLine("Banco Criado..");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                db.Cursos.Add(new Curso { Descricao = "Workshop EF Core"});
                db.SaveChanges();

                var courses = db.Cursos.AsNoTracking().Where(p => p.Id > 0).ToArray();

                Console.WriteLine($"Cursos: {courses.Length}");
            }

            Console.WriteLine("Finalizado..");
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
                .UseSqlite("Data Source=contador-evento.db");
    }
}

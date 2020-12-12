using System;
using Microsoft.EntityFrameworkCore;
using WorkshopEF.Data;
using System.Linq;

var connection = "Data Source=teste.db";
var options = new DbContextOptionsBuilder<Contexto>()
    .UseSqlite(connection)
    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

var db = new Contexto(options.Options);
SeedData.SetupBD(db);

var configBanco = db.Configuracao.FirstOrDefault(w => w["Config"] == "ConexaoBanco");
Console.WriteLine($"Configuracao Banco: {configBanco["Valor"]}");


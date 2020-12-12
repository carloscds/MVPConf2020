﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using WorkshopEF.Data;

var connection = "Data Source=teste.db";
var options = new DbContextOptionsBuilder<Contexto>()
    .UseSqlite(connection)
    .LogTo(Console.WriteLine,new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted }, Microsoft.Extensions.Logging.LogLevel.Information);

var db = new Contexto(options.Options);
SeedData.SetupBD(db);

var grupos = db.Grupo.Include(i => i.Produto);
foreach (var g in grupos)
{
    Console.WriteLine($"{g.Id} - {g.Nome} - Produtos: {g.Produto.Count}");
}

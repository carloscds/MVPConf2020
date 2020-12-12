using System;
using System.Collections.Generic;
using WorkshopEF.Data.Dominio;

namespace WorkshopEF.Data
{
    public class SeedData
    {
        // EF Seed
        public static void SetupBD(Contexto db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var grupo1 = new Grupo { Nome = "Grupo 1" };
            db.Grupo.Add(grupo1);
            var grupo2 = new Grupo { Nome = "Grupo 2" };
            db.Grupo.Add(grupo2);

            var forn1 = new Fornecedor { Nome = "Fornecedor 1" };
            var forn2 = new Fornecedor { Nome = "Fornecedor 2" };
            var forn3 = new Fornecedor { Nome = "Fornecedor 3" };
            db.Fornecedor.Add(forn1);
            db.Fornecedor.Add(forn2);
            db.Fornecedor.Add(forn3);

            db.Produto.AddRange(
                new() { Grupo = grupo1, Nome = "Produto 1", Preco = 10, Fornecedor = new[] { forn1, forn2 } },
                new() { Grupo = grupo1, Nome = "Produto 2", Preco = 5.5M, Fornecedor = new[] { forn1, forn2, forn3 } },
                new() { Grupo = grupo2, Nome = "Produto 3", Preco = 20, Fornecedor = new[] { forn1, forn3 } },
                new() { Grupo = grupo2, Nome = "Produto 4", Preco = 16.50M, Fornecedor = new[] { forn1, forn2, forn3 } },
                new() { Grupo = grupo2, Nome = "Produto 5", Preco = 3, Fornecedor = new[] { forn1, forn2 } });

            var profor4 = new Produto { Grupo = grupo2, Nome = "Produto 6", Preco = 3 };
            var forn4 = new Fornecedor { Nome = "Fornecedor 4", Produto = new[] { profor4 } };
            db.Fornecedor.Add(forn4);

            db.Configuracao.Add(new Dictionary<string, object>
            {
                {"Config", "ConexaoBanco"  },
                { "Valor", "data source=teste.db"}
            });
            db.SaveChanges();
        }
    }
}

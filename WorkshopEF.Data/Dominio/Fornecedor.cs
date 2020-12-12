
using System.Collections.Generic;

namespace WorkshopEF.Data.Dominio
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}


using System.Collections.Generic;

namespace WorkshopEF.Dominio
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}

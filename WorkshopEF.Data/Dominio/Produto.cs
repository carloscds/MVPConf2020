using System.Collections.Generic;

namespace WorkshopEF.Data.Dominio
{
    public class Produto 
    {
        public int Id { get; set; }
        public virtual Grupo Grupo { get; set; }
        public int GrupoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
    }
}

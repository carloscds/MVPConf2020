using System.Collections.Generic;
using WorkshopEF.Dominio.Abstract;

namespace WorkshopEF.Dominio
{
    public class Produto : EntityBase
    {
        public virtual Grupo Grupo { get; set; }
        public int GrupoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
    }
}

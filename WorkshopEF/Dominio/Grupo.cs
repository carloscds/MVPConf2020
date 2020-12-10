using System.Collections.Generic;
using WorkshopEF.Dominio.Abstract;

namespace WorkshopEF.Dominio
{
    public class Grupo : EntityBase
    {
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
        public Grupo()
        {
            Produto = new List<Produto>();
        }
    } 
}

using System.Collections.Generic;

namespace WorkshopEF.Data.Dominio
{
    public class Grupo 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
        public Grupo()
        {
            Produto = new List<Produto>();
        }
    } 
}

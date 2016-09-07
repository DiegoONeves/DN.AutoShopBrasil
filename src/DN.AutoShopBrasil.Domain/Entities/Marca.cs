using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.AutoShopBrasil.Domain.Entities
{
    public class Marca
    {
        public Marca()
        {
            MarcaId = Guid.NewGuid();
            Modelos = new List<Modelo>();
        }
        public Guid MarcaId { get; set; }
        public string Nome { get; set; }
        public bool Principal { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}

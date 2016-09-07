using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.AutoShopBrasil.Domain.Entities
{
    public class AnoModelo
    {
        public AnoModelo()
        {
            AnoModeloId = Guid.NewGuid();
        }
        public Guid AnoModeloId { get; set; }
        public int Ano { get; set; }
        public Guid ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}

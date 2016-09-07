using System;
using System.Collections.Generic;

namespace DN.AutoShopBrasil.Domain.Entities
{
    public class Modelo
    {
        public Modelo()
        {
            ModeloId = Guid.NewGuid();
        }
        public Guid ModeloId { get; set; }
        public string NomeCompacto { get; set; }
        public string NomeCompleto { get; set; }
        public Guid MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual ICollection<AnoModelo> AnoModelos { get; set; }

        public override string ToString()
        {
            return NomeCompleto;
        }
    }
}

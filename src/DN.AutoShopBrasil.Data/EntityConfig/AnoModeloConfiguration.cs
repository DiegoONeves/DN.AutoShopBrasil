using DN.AutoShopBrasil.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.AutoShopBrasil.Data.EntityConfig
{
    public class AnoModeloConfiguration : EntityTypeConfiguration<AnoModelo>
    {
        public AnoModeloConfiguration()
        {
            ToTable("AnoModelo");
            HasKey(x => x.AnoModeloId);

            Property(x => x.Ano)
                .IsRequired();

            //UM PARA MUITOS
            HasRequired(x => x.Modelo)
                .WithMany(x => x.AnoModelos)
                .HasForeignKey(x => x.ModeloId);
        }
    }
}

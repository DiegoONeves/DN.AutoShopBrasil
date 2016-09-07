using DN.AutoShopBrasil.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.AutoShopBrasil.Data.EntityConfig
{
    public class ModeloConfiguration : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguration()
        {
            ToTable("Modelo");
            HasKey(x => x.ModeloId);

            Property(x => x.NomeCompacto)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.NomeCompleto)
                .HasMaxLength(100)
                .IsRequired();

            //UM PARA MUITOS
            HasRequired(x => x.Marca)
                .WithMany(x => x.Modelos)
                .HasForeignKey(x => x.MarcaId);

        }
    }
}

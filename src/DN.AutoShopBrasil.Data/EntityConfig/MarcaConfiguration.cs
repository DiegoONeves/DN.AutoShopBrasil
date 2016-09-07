using DN.AutoShopBrasil.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DN.AutoShopBrasil.Data.EntityConfig
{
    public class MarcaConfiguration : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguration()
        {
            ToTable("Marca");
            HasKey(x => x.MarcaId);

            Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();
        
            Property(x => x.Principal)
                .IsRequired();
        }
    }
}

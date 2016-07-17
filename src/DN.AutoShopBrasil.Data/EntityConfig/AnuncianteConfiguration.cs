using DN.AutoShopBrasil.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DN.AutoShopBrasil.Data.EntityConfig
{
    public class AnuncianteConfiguration : EntityTypeConfiguration<Anunciante>
    {
        public AnuncianteConfiguration()
        {
            HasKey(x => x.AnuncianteId);

            Property(x => x.Nome)
                .HasMaxLength(50);

            Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            Property(x => x.Email)
              .HasMaxLength(100)
              .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_ANUNCIANTE_EMAIL")
              {
                  IsUnique = true
              }))
              .IsRequired();

            Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength();

            Ignore(x => x.ValidationResult);
        }
    }
}

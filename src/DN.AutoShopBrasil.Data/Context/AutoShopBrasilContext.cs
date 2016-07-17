using DN.AutoShopBrasil.Data.EntityConfig;
using DN.AutoShopBrasil.Domain.Entities;
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DN.AutoShopBrasil.Data.Context
{
    public class AutoShopBrasilContext : DbContext
    {
        public AutoShopBrasilContext()
            : base("AutoShopBrasilContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            ContextId = Guid.NewGuid();
        }
        public Guid  ContextId { get; set; }
        public DbSet<Anunciante> Anunciantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AnuncianteConfiguration());
        }

       
    }
}

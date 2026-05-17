using Microsoft.EntityFrameworkCore;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Repository.Databases.Interfaces;

namespace OE.PDU.Module.LittleHelpBook.Repository
{
    public class LittleHelpBookContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Provider> Providers { get; set; }
        public virtual DbSet<Models.Address> Addresses { get; set; }
        public virtual DbSet<Models.LhbAttribute> Attributes { get; set; }
        public virtual DbSet<Models.PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<Models.ProviderAttribute> ProviderAttributes { get; set; }
        public virtual DbSet<Models.CategoryView> CategoryViews { get; set; }
        public virtual DbSet<Models.SubCategoryView> SubCategoryViews { get; set; }
        public virtual DbSet<Models.ProviderWithCatsView> ProviderWithCatsViews { get; set; }

        public LittleHelpBookContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("lhb");

            builder.Entity<Models.CategoryView>().ToView("CategoryView").HasKey(v => v.AttributeId);
            builder.Entity<Models.SubCategoryView>().ToView("SubCategoryView").HasKey(v => v.AttributeId);
            builder.Entity<Models.ProviderWithCatsView>().ToView("ProviderWithCatsView").HasKey(v => v.ProviderId);
        }
    }
}

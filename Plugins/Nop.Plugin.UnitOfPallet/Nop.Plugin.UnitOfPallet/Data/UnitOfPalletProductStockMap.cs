using Nop.Plugin.UnitOfPallet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Nop.Plugin.UnitOfPallet.Data
{
    public class UnitOfPalletProductStockMap : EntityTypeConfiguration<UnitOfPalletProduct>
    {
        public UnitOfPalletProductStockMap()
        {
            this.ToTable("UpProductStock");
            this.HasKey(x => x.Id);
            this.HasKey(x => x.Group);
            Property(x => x.SubGroup);
            Property(x => x.Price);
            Property(x => x.Weight);
            Property(x => x.Description);
        }
    }
}

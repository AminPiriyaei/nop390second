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
            this.Property(x => x.PalletId);
            this.Property(x => x.GroupId);
            Property(x => x.SubGroup);
            Property(x => x.Price);
            Property(x => x.Weight);
            Property(x => x.Description);

            this.HasRequired(x => x.palletProductTabModel)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            this.HasRequired(x => x.palletProductTabModel)
                .WithMany()
                .HasForeignKey(x => x.SubGroup);
        }
    }
}

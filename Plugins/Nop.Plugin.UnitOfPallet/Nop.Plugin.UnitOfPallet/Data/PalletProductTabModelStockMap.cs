using Nop.Plugin.UnitOfPallet.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.UnitOfPallet.Data
{
    public class PalletProductTabModelStockMap: EntityTypeConfiguration<PalletProductTabModel>
    {

       public PalletProductTabModelStockMap()
        {

            this.ToTable("UpGroupstock");
            this.HasKey(x => x.Id);
            this.Property(x => x.GroupId);
            this.Property(x => x.GroupTitle);

            this.HasRequired(x => x.palletProductTabModels)
                .WithMany()
                .HasForeignKey(x => x.ParentId);
        }
    }
}

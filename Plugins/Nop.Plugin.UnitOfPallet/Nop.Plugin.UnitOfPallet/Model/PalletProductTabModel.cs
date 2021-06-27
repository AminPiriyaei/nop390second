using Nop.Core;
using Nop.Plugin.UnitOfPallet.Domain;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.UnitOfPallet.Model
{
    public class PalletProductTabModel :BaseEntity
    {

        [Key]
        public int GroupId { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا عنوان را  وارد کنید")]
        public string GroupTitle { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public List<PalletProductTabModel> palletProductTabModels { get; set; }
        [InverseProperty("PalletProductTabModel")]
        public List<UnitOfPalletProduct> unitOfPalletProducts { get; set; }
        [InverseProperty("Group")]
        public List<UnitOfPalletProduct> SubGroup { get; set; }

    }
}

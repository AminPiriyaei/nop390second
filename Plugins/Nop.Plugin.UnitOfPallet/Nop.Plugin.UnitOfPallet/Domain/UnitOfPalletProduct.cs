using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***
using Nop.Core;
using Nop.Plugin.UnitOfPallet.Model;

namespace Nop.Plugin.UnitOfPallet.Domain
{
    public class UnitOfPalletProduct:BaseEntity
    {
        [Key]
        public int PalletId {get; set;}
        public int GroupId { get; set; }
        public int? SubGroup { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set;}
        [Display(Name = "قیمت")]
        public int Price { get; set;}
        [Display(Name = "وزن")]
        public int Weight { get; set; }
        //
        [ForeignKey("GroupId")]
        public PalletProductTabModel palletProductTabModel { get; set; }
        [ForeignKey("SubGroup")]
        public PalletProductTabModel Group {get; set;}
    }
}

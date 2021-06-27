using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.UnitOfPallet.Model
{
    public class ConfigurationModel : BaseNopModel
    {
        public ConfigurationModel()
        {
            AvailableAttributes = new List<SelectListItem>();
        }
        [DisplayName("فیلد ویژگی اختصاصی")]
        public int SpecialAttributeId { get; set; }
        public IList<SelectListItem> AvailableAttributes { get; set; }
        public IList<SelectListItem> AvailableGroup { get; set; }
        [Key]
        public int PalletId { get; set; }
        public int GroupId { get; set; }
        public int? SubGroup { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا توضیحات را  وارد کنید")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا قیمت را  وارد کنید")]
        public int Price { get; set; }
        [Display(Name = "وزن")]
        [Required(ErrorMessage = "لطفا وزن  را  وارد کنید")]
        public int Weight { get; set; }
        //
        [ForeignKey("GroupId")]
        public PalletProductTabModel palletProductTabModel { get; set; }
        [ForeignKey("SubGroup")]
        public PalletProductTabModel Group { get; set; }
    }
}

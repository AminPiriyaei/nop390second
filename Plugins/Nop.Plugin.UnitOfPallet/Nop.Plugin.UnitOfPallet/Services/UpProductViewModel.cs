using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.UnitOfPallet.Services
{
   public  class UpProductViewModel:BaseNopModel
    {

        public int Id { get; set; }
        public int PalletId { get; set;}
        public int Price { get; set; }
        public int Weight { get; set; }
        public string GroupTitle { get; set; }


    }
}

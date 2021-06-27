using Nop.Core;
using Nop.Plugin.UnitOfPallet.Domain;
using Nop.Plugin.UnitOfPallet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.UnitOfPallet.Services
{
    public interface IUnitOfPalletServices
    {
        // GetId an UnitOfPalletProduct
        UnitOfPalletProduct GetUpProductById(int PalletProductId);

        // SelectAll UnitOfPalletProduct
        UnitOfPalletProduct SelectAllUpProduct(int productId);

        // Insert an UnitOfPalletProduct
        void InsertUpProduct(UnitOfPalletProduct unitOfPalletProduct);

        // Update an UnitOfPalletProduct
        void UpdateUpProduct(UnitOfPalletProduct unitOfPalletProduct);
        // Deletes an UnitOfPalletProduct
        void DeleteUpProduct(UnitOfPalletProduct unitOfPalletProduct);
        IPagedList<UnitOfPalletProduct> GetAllUpProducts(int productId = 0, int pageIndex = 0, int pageSize = int.MaxValue);
        //IPagedList<PalletProductTabModel> GetAllGroups(int groupId = 0, int pageIndex = 0, int pageSize = int.MaxValue);
        List<SelectListItem> GetGroupForManageNews();
        List<SelectListItem> GetSubGroupForManageNews(int groupId);
    }
}

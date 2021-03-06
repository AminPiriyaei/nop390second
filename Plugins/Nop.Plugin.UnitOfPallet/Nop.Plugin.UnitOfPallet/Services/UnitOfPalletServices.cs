using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Data;
using Nop.Plugin.UnitOfPallet.Data;
using Nop.Plugin.UnitOfPallet.Domain;
using Nop.Plugin.UnitOfPallet.Model;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.UnitOfPallet.Services
{
    public class UnitOfPalletServices : IUnitOfPalletServices
    {
        private readonly IRepository<UnitOfPalletProduct> _unitOfPalletProduct;
        private readonly IEventPublisher _eventPublisher;
        private readonly IDbContext _context;
        private readonly ICacheManager _cacheManager;
        public UnitOfPalletServices(IRepository<UnitOfPalletProduct> unitOfPalletProduct,
            IEventPublisher eventPublisher,
            IDbContext dbContext, ICacheManager cacheManager)
        {
            _unitOfPalletProduct = unitOfPalletProduct;
            _eventPublisher = eventPublisher;
            _context = dbContext;
            _cacheManager = cacheManager;
        }
        public void DeleteUpProduct(UnitOfPalletProduct unitOfPalletProduct)
        {
            if (unitOfPalletProduct == null)
                throw new ArgumentNullException("unitOfPalletProduct");

            _unitOfPalletProduct.Delete(unitOfPalletProduct);
            //event notification
            _eventPublisher.EntityDeleted(unitOfPalletProduct);
        }

        public IPagedList<UnitOfPalletProduct> GetAllproductGroup(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            //string key = string.Format(PRODUCTATTRIBUTES_ALL_KEY, pageIndex, pageSize);
            //return _cacheManager.Get(key, () =>
            //{
            //    var query = from pa in _unitOfPalletProduct.Table
            //                orderby pa.Id
            //                orderby pa.palletProductTabModel.GroupTitle
            //                select pa;
            //    var productGroups = new PagedList<UnitOfPalletProduct>(query, pageIndex, pageSize);
            //    return productGroups;
            //};
            return null;
        }
        public IPagedList<UnitOfPalletProduct> GetAllUpProducts(int productId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            //    //var query = _unitOfPalletProduct.Table;

            //    //if (productId > 0)
            //    //    query = query.Where(x => x.PalletId == productId);
            //    ////string key = string.Format(PRODUCTATTRIBUTES_ALL_KEY, pageIndex, pageSize);
            //    ////return _cacheManager.Get(key, () =>
            //    {
            //        var query = from pa in _unitOfPalletProduct.Table
            //                    orderby pa.GroupId
            //                    select pa;
            //        var UnitOfPalletProducts = new PagedList<UnitOfPalletProduct>(query, pageIndex, pageSize);
            //        return UnitOfPalletProducts;
            //    };
            ////});
            return null;
        }

        public List<SelectListItem> GetGroupForManageNews()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetSubGroupForManageNews(int groupId)
        {
            throw new NotImplementedException();
        }

        public UnitOfPalletProduct GetUpProductById(int PalletProductId)
        {

            if (PalletProductId == 0)
                return null;

            return _unitOfPalletProduct.GetById(PalletProductId);
        }

        public void InsertUpProduct(UnitOfPalletProduct unitOfPalletProduct)
        {
            if (unitOfPalletProduct == null)
                throw new ArgumentNullException("unitOfPalletProduct");

            _unitOfPalletProduct.Insert(unitOfPalletProduct);

            //event notification
            _eventPublisher.EntityDeleted(unitOfPalletProduct);
        }

        public UnitOfPalletProduct SelectAllUpProduct(int productId)
        {
            //if (productId <= 0)
            //    throw new ArgumentNullException("UpProductId");
            //var query = _unitOfPalletProduct.Table
            //query = query.Where(x => x.PalletId == productId);

            //query = query.OrderBy(x => x.Id);

            //return query.ToList();
            return null;
        }
        public void UpdateUpProduct(UnitOfPalletProduct unitOfPalletProduct)
        {
            if (unitOfPalletProduct == null)
                throw new ArgumentNullException("unitOfPalletProduct");
            _unitOfPalletProduct.Update(unitOfPalletProduct);
            //event notification
            _eventPublisher.EntityUpdated(unitOfPalletProduct);
        }
    }
}

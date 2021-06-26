using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nop.Admin.Controllers;
using Nop.Admin.Infrastructure.Cache;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.UnitOfPallet.Domain;
using Nop.Plugin.UnitOfPallet.Model;
using Nop.Plugin.UnitOfPallet.Services;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.UnitOfPallet.Controllers
{
    //
    public class UnitOfPalletAdminController : BaseAdminController
    {
        private readonly UnitOfPalletSettings _pluginSettings;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IUnitOfPalletServices _unitOfPalletServices;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IWorkContext _workContext;
        private readonly IMeasureService _measureService;
        private readonly IProductService _productService;

        public UnitOfPalletAdminController(UnitOfPalletSettings unitOfPalletSettings,
            ISettingService settingService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            IUnitOfPalletServices unitOfPalletServices,
            IProductAttributeService productAttributeService,
            IWorkContext workContext,
            IMeasureService measureService,
            IProductService productService)
        {
            _pluginSettings = unitOfPalletSettings;
            _settingService = settingService;
            _localizationService = localizationService;
            _permissionService = permissionService;
            _unitOfPalletServices = unitOfPalletServices;
            _productAttributeService = productAttributeService;
            _workContext = workContext;
            _measureService = measureService;
            _productService = productService;

        }

        [AdminAuthorize]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel();
            model.SpecialAttributeId = _pluginSettings.SpecialAttributeId;
            model.GroupId = _pluginSettings.GroupId;
            model.Price = _pluginSettings.Price;
            model.SubGroup = _pluginSettings.SubGroup;
            model.Weight = _pluginSettings.Weight;
            model.Description = _pluginSettings.Description;
            model.AvailableAttributes.Add(new SelectListItem { Text = _localizationService.GetResource("Admin.Catalog.Categories.Fields.Parent.None"), Value = "0" });
            //product attributes
            foreach (var productAttribute in _productAttributeService.GetAllProductAttributes())
            {
                model.AvailableAttributes.Add(new SelectListItem
                {
                    Text = productAttribute.Name,
                    Value = productAttribute.Id.ToString()
                });            
            }
            //model.LastUpdateDateTime = _pluginSettings.LastUpdateDateTime;
            //model.LastUpdateWidgetZone = _pluginSettings.LastUpdateWidgetZone;

            return View("~/Plugins/UnitOfPallet/Views/Admin/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();
            //save settings
            _pluginSettings.SpecialAttributeId = model.SpecialAttributeId;
            _pluginSettings.GroupId = model.GroupId;
            _pluginSettings.Group = model.Group;
            _pluginSettings.SubGroup = model.SubGroup;
            _pluginSettings.Price = model.Price;
            _pluginSettings.Weight = model.Weight;
            _pluginSettings.PalletId = model.PalletId;
            _settingService.SaveSetting(_pluginSettings);
            SuccessNotification(this._localizationService.GetResource("Admin.Plugins.Saved"), true);
            return this.Configure();

        }

        public ActionResult UnitOfPalletTab(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageProducts))
                return AccessDeniedKendoGridJson();
            var model = new UnitOfPalletProduct();
            //product
            var product = _productService.GetProductById(id);
            if (product == null || product.Deleted)
                return Content("product is not available.");
            model.PalletId = product.Id;
            return View("~/Plugins/UnitOfPallet/Views/Admin/_UnitOfPalletAdminTab.cshtml", model);
        }

        [HttpPost]
        public virtual ActionResult UpProductsSelect(int productId, DataSourceRequest command)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageProducts))
                return AccessDeniedKendoGridJson();

            var products = _productService.GetProductById(productId);
            if (products == null)
                throw new ArgumentException("No product found with the specified id");
            //  var UpProducts = _unitOfPalletServices.SelectAllUpProduct(productId: productId, pageIndex: command.Page - 1, pageSize: command.PageSize);
            //if (UpProducts == null)
            //    throw new ArgumentException("No UpProducts found with the specified id");

            //a vendor does not have access to this functionality
            if (_workContext.CurrentVendor != null)
                return Content("");

            //var referenceUnit = _measureService.GetMeasureWeightById(product.BasepriceBaseUnitId);

            //order notes
            var UpProductModels = new List<UpProductViewModel>();
            //foreach (var Up in products)
            //{
            //    UpProductModels.Add(new UpProductViewModel
            //    {


            //    });
            //}
            return null;
        }



        [ValidateInput(false)]
        public virtual ActionResult UpProductAdd(int productId, int price, int GroupId, int SubGroup, string Description, int Weight)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageOrders))
                return AccessDeniedView();
            if (_workContext.CurrentVendor != null)
                return Json(new { Result = false }, JsonRequestBehavior.AllowGet);

            var UpProduct = _unitOfPalletServices.GetUpProductById(productId);
            UpProduct = new UnitOfPalletProduct
            {
                PalletId = productId,
                Price = price,
                GroupId = GroupId,
                SubGroup = SubGroup,
                Description = Description,
                Weight = Weight

            };
            _unitOfPalletServices.InsertUpProduct(UpProduct);

            return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult UpProductDelete(int id, int productId)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageOrders))
                return AccessDeniedView();

            var product = _productService.GetProductById(productId);
            if (product == null)
                throw new ArgumentException("No Product found with the specified id");

            //a vendor does not have access to this functionality
            if (_workContext.CurrentVendor != null)
                return RedirectToAction("Edit", "Product", new { id = productId });

            var UpProduct = _unitOfPalletServices.GetUpProductById(id);
            if (UpProduct == null)
                throw new ArgumentException("No UpProduct found with the specified id");

            _unitOfPalletServices.DeleteUpProduct(UpProduct);

            return new NullJsonResult();
        }

    }

}

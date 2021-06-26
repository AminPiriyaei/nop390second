using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Web.Framework.Events;
using System;
using Nop.Services.Catalog;
using System.Web;
using System.Web.Routing;

namespace Nop.Plugin.UnitOfPallet.AdminTabConsumers
{
    public class AdminTabStripConsumers : IConsumer<AdminTabStripCreated>
    {
        private readonly ILocalizationService _localizationService;
        private readonly IProductService _productService;
        private readonly UnitOfPalletSettings _pluginSettings;

        public AdminTabStripConsumers(ILocalizationService localizationService,
            IProductService productService,
            UnitOfPalletSettings pluginSettings)
        {
            this._localizationService = localizationService;
            this._productService = productService;
            this._pluginSettings = pluginSettings;
        }
        public void HandleEvent(AdminTabStripCreated eventMessage)
        {
            int productId = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["id"]);

            if (eventMessage.TabStripName == "product-edit")
            {
                var product = _productService.GetProductById(productId);
                if (product == null || product.Deleted)
                    return;

                //var checkMoneys = _checkMoneyService.SearchCheckMoneys(product.CustomerId, order.Id).ToList();
                //if (!checkMoneys.Any())
                //    return;

                var actionName = "UnitOfPalletTab";
                var controllerName = "UnitOfPalletAdmin";
                var routeValues = new RouteValueDictionary() { { "Namespaces", "Plugin.UnitOfPallet.Controllers" }, { "area", null }, { "id", productId } };

                //  var htmlString = HtmlExtensions.AdminTabStripFor("موجودی کالای متغییر", actionName, controllerName, routeValues, tabEventInfo);
                // tabEventInfo.BlocksToRender.Add(htmlString);

            }
        }
    }
}
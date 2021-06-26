using Nop.Core.Plugins;
using Nop.Plugin.UnitOfPallet.Data;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Security;
using Nop.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Nop.Plugin.UnitOfPallet
{
    public class UnitOfPalletPlugin:BasePlugin,IMiscPlugin
    {

        private readonly ISettingService _settingService;
        private readonly UnitOfPalletSettings _pluginSettings;
        private readonly IPermissionService _permissionService;
        private readonly UnitOfPalletObjectContext _pluginObjectContext;
        private readonly IScheduleTaskService _scheduleTaskService;

        public UnitOfPalletPlugin(ISettingService settingService,
            UnitOfPalletSettings pluginSettings,
            IPermissionService permissionService,
            UnitOfPalletObjectContext polishiObjectContext,
            IScheduleTaskService scheduleTaskService)
        {
            this._settingService = settingService;
            this._pluginSettings = pluginSettings;
            _permissionService = permissionService;
            _pluginObjectContext = polishiObjectContext;
            _scheduleTaskService = scheduleTaskService;
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "UnitOfPalletAdmin";
            routeValues = new RouteValueDictionary()
            {
                { "Namespaces", "Nop.Plugin.UnitOfPallet.Controllers" },{ "area", null }
            };
        }

        /// <summary>
        /// Gets a route for displaying widget
        /// </summary>
        /// <param name="widgetZone">Widget zone where it's displayed</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "UnitOfPallet";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Plugin.UnitOfPallet.Controllers" }, { "area", null }, { "widgetZone", widgetZone } };
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new UnitOfPalletSettings()
            {
            };
            _settingService.SaveSetting(settings);

            //install synchronization task
            //if (_scheduleTaskService.GetTaskByType("Plugin.Misc.KeshNavar.Services.KeshnavarProductCrawlerTask, Plugin.Misc.KeshNavar") == null)
            //{
            //    _scheduleTaskService.InsertTask(new ScheduleTask
            //    {
            //        Name = "Competitor Price Web Crawler",
            //        Seconds = 21600,
            //        Type = "Plugin.Misc.KeshNavar.Services.KeshnavarProductCrawlerTask, Plugin.Misc.KeshNavar",
            //        Enabled = true,

            //    });
            //}

            //locals
            //this.AddOrUpdatePluginLocaleResource("Plugin.Misc.KeshNavar.LastUpdate", "آخرین به روزرسانی");

            //install database
            _pluginObjectContext.Install();

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            //_settingService.DeleteSetting<KeshNavarSettings>();

            //remove scheduled task
            //var task = _scheduleTaskService.GetTaskByType("Plugin.Misc.KeshNavar.Services.KeshnavarProductCrawlerTask, Plugin.Misc.KeshNavar");
            //if (task != null)
            //    _scheduleTaskService.DeleteTask(task);

            //locales
            //this.DeletePluginLocaleResource("Plugin.Misc.KeshNavar.LastUpdate");

            //uninstall database
            _pluginObjectContext.Uninstall();

            base.Uninstall();
        }

    }
}

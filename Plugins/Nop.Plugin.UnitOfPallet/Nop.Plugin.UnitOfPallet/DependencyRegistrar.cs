using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.UnitOfPallet.Data;
using Nop.Plugin.UnitOfPallet.Domain;
using Nop.Plugin.UnitOfPallet.Services;
using Nop.Services.Catalog;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Nop.Plugin.UnitOfPallet
{
    public class DependencyRegistrar : IDependencyRegistrar
    {

        private const string CONTEXT_NAME = "fgplugin_object_context_UnitOfPallet";

        public int Order
        {
            get
            {
                return 100;
            }
        }
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //db context
            this.RegisterPluginDataContext<UnitOfPalletObjectContext>(builder, CONTEXT_NAME);
            ////domains
            builder.RegisterType<EfRepository<UnitOfPalletProduct>>()
            .As<IRepository<UnitOfPalletProduct>>()
            .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
            .InstancePerLifetimeScope();
            // services
            builder.RegisterType<UnitOfPalletServices>().As<IUnitOfPalletServices>().InstancePerLifetimeScope();

        }
    }
}

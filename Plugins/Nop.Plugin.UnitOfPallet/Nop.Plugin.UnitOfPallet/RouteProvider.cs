using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Nop.Plugin.UnitOfPallet
{
    public class RouteProvider:IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {

        }
        public int Priority
        {
            get
            {
                return int.MaxValue;
            }
        }
    }
}

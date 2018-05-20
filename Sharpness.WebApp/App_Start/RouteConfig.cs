using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name:"CotrolPanel",
                url: "{controller}/{action}/{Link}/{Stain}/{Organ}/{Tissue}/{SharpnessMapPath}",
                defaults: new { controller = "ControlPanel", action = "Report", Link = UrlParameter.Optional, Stain = UrlParameter.Optional, Organ = UrlParameter.Optional, Tissue= UrlParameter.Optional, SharpnessMapPath = UrlParameter.Optional }

                );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
            name: "Home",
            url: "trang-chu",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "WebASP.Controllers" }
        );

            routes.MapRoute(
            name: "GioiThieu",
            url: "gioi-thieu",
            defaults: new { controller = "Home", action = "GioiThieu", id = UrlParameter.Optional },
            namespaces: new[] { "WebASP.Controllers" }
        );

            routes.MapRoute(
            name: "ChuongTrinhDaoTao",
            url: "chuong-trinh-dao-tao",
            defaults: new { controller = "TypeCourse", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "WebASP.Controllers" }
        );

            routes.MapRoute(
            name: "XemThem",
            url: "chuong-trinh-dao-tao/{metatitle}-{id}",
            defaults: new { controller = "TypeCourse", action = "XemThem", id = UrlParameter.Optional },
            namespaces: new[] { "WebASP.Controllers" }
        );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebASP.Controllers" }
            );
        }
    }
}

using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MaksimHladki.Web.Infrastructure;
using MaksimHladki.Web.Mapper;

namespace MaksimHladki.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DepotProfile>();
                cfg.AddProfile<DrugUnitProfile>();
                cfg.AddProfile<DrugTypeProfile>();
            });

            AutofacConfig.ConfigureContainer();
        }
    }
}
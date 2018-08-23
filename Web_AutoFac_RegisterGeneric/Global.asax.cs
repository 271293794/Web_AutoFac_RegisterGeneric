using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web_AutoFac_RegisterGeneric.Models;

namespace Web_AutoFac_RegisterGeneric
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterGeneric(typeof(IRepository<>));
            // 注册 app
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();


            // 注册 IRepository
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).PropertiesAutowired();
            //builder.RegisterControllers(Assembly.GetCallingAssembly()).PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            #region 原来的代码
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            #endregion

        }
    }
}

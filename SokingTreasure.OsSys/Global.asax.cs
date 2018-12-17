using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SokingTreasure.OsSys
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //删除数据库重新创建数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApiDbContext>());
            //当models发生改变时修改数据库
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MvcDbContext, Configuration>());
        }
    }
}

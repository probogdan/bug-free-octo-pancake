using _IBS_VetPlus.Models;
using Ninject;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _IBS_VetPlus
{
    public class MvcApplication : HttpApplication
    {
        public static KernelBase _kernelBase = new StandardKernel(new DataProvider()); //DI

        protected void Application_Start()
        {
            
            
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles); //сделаем по3же
        }
    }
}
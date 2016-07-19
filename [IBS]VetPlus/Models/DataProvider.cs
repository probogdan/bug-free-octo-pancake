using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _IBS_InterfacesBLL;
using _IBS_AuthBLL;
using Ninject.Modules;
using _IBS_InfoBLL;

namespace _IBS_VetPlus.Models
{
    public class DataProvider : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthBLL>().To<AuthenticationBLL>().InSingletonScope();
            this.Bind<AuthenticationBLL>().ToSelf().InSingletonScope();
            this.Bind<IInfoBLL>().To<InfoBLL>().InSingletonScope();
            this.Bind<InfoBLL>().ToSelf().InSingletonScope();             
        }
    }
}
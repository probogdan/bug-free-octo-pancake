using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using AutoMapper;
using _IBS_InterfacesBLL;
using _IBS_VetPlus.Models;
using _IBS_Entities;

namespace _IBS_VetPlus.Controllers
{
    public class HomeController : Controller
    {
        public KernelBase _kernelBase = MvcApplication._kernelBase;

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult MainNews()
        {
            var info = _kernelBase.Get<IInfoBLL>();
            var news = info.GetNews();

            var newsVM = Mapper.Map<List<Post>, List<PostViewModel>>(news);

            return Json(newsVM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTopSpecialists()
        {
            var auth = _kernelBase.Get<IAuthBLL>();
            var specialists = auth.GetAllAccounts();

            var specialistsVM = Mapper.Map<List<Account>, List<AccountViewModel>>(specialists);

            return Json(specialistsVM, JsonRequestBehavior.AllowGet);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Web.Framework.Attributes;
using ATP2.BDAID.Web.Framework.Util;
using Newtonsoft.Json;

namespace ATP2.BDAID.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "You have no access to the page.";
            return View();
        }
    }
}
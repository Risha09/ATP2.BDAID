using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Web.Framework.Base;

namespace ATP2.BDAID.Web.Controllers
{
    public class AdminPostController : BaseController
    {
        // GET: AdminUser
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.ID = id;
            return View();
        }
    }
}
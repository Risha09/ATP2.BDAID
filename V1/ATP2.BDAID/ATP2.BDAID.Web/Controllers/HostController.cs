using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Web.Framework.Attributes;
using ATP2.BDAID.Web.Framework.Base;

namespace ATP2.BDAID.Web.Controllers
{
    [BDAIDAuthorize(EnumCollection.UserType.Admin)]

    public class HostController : BaseController
    {
        //
        // GET: /RegisteredUser/Host/
        public ActionResult Index()
        {
            var userinfo = userInfoService.GetAll();
            return View(userinfo);
        }

        public ActionResult DetailView()
        {
            var userinfo = new UserInfo();
            return View(userinfo);
        }
        public ActionResult Save(int id)
        {
            var user = userInfoService.GetByID(id).Data;
            return View("DetailView", user);

        }
        [HttpPost]
        public ActionResult Save(UserInfo userinfo)
        {
            if (!ModelState.IsValid)
            {
                return View("DetailView",userinfo);
            }

            try
            {
                var result = userInfoService.Save(userinfo);
                if (result.HasError)
                {
                    ViewBag.Message = result.Message;
                    return View("DetailView", userinfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            userInfoService.Delete(id);
            return RedirectToAction("Index");
        }
	}
}
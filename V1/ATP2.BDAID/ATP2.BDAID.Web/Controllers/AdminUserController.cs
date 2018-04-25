using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Model.Admin;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Web.Framework.Base;

namespace ATP2.BDAID.Web.Controllers
{
    public class AdminUserController : BaseController
    {
        // GET: AdminUser
        public ActionResult List(string key="")
        {
            var model = Reg_UserService.GetAll(key);

            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
            }

            return View(model);
        }

        public ActionResult Detail(int id)
        {

            var result = Reg_UserService.GetByID(id);

            if (result.HasError)
            {
                TempData["Error"] = result.Message;
                return RedirectToAction("List");
            }

            var model = new UserModel()
            {
                User = result.Data,
                Posts = PostService.GetAllByUserId(result.Data.UserInfo.ID)
            };
            return View(model);
        }

        public ActionResult UpdateStatus(int id)
        {
            var result = Reg_UserService.UpdateStatus(id);

            if (result.HasError)
            {
                TempData["Error"] = result.Message;
            }

            return RedirectToAction("List");
        }
        
    }
}
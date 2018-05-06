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
using ATP2.BDAID.Web.Framework.Util;

namespace ATP2.BDAID.Web.Controllers
{
    [BDAIDAuthorize(new int[] { (int)EnumCollection.UserTypeEnum.RegisteredUser, (int)EnumCollection.UserTypeEnum.NonRegisteredUser })]
    public class RegisteredHostController : BaseController
    {
        //
        // GET: /RegisteredUser/Host/
        public ActionResult Index(int id=-1)
        {
            if (id == -1)
                id = 1;

            ViewBag.ID = id;
            ViewBag.Services = ServiceTypeService.GetAll();
            return View();
        }

        public ActionResult Index2(int id = -1)
        {
            if (id == -1)
                id = 1;

            ViewBag.ID = id;
            ViewBag.Services = ServiceTypeService.GetAll();
            return View();
        }

        public ActionResult Profile()
        {
            var result = Reg_UserService.GetByID(HttpUtil.UserProfile.ID);
            var model = result.Data ?? new Reg_User() {UserInfo = new UserInfo()};
            return View(model);
        }

        public ActionResult EditProfile()
        {
            var model = new Reg_User(){ID = HttpUtil.UserProfile.ID,DOB = DateTime.Now};
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(Reg_User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = Reg_UserService.Save(model);

            if (result.HasError)
            {
                ViewBag.Message = result.Message;
                return View(model);
            }

            return RedirectToAction("Profile");
        }

        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult MessageIndex()
        {
            return View();
        }
	}
}
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
    [BDAIDAuthorize(new int[] { (int)EnumCollection.UserTypeEnum.RegisteredUser })]
    public class RegisteredHostController : BaseController
    {
        //
        // GET: /RegisteredUser/Host/
        public ActionResult Index()
        {
            ViewBag.Services = ServiceTypeService.GetAll();
            return View();
        }

        public ActionResult Profile()
        {
            var result = Reg_UserService.GetByID(HttpUtil.UserProfile.ID);
            var model = result.Data ?? new Reg_User() {UserInfo = new UserInfo()};
            return View(model);
        }

        public ActionResult DashBoard()
        {
            return View();
        }
	}
}
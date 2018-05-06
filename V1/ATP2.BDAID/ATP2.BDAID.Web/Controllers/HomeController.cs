using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Model.Account;
using ATP2.BDAID.Web.Framework.Attributes;
using ATP2.BDAID.Web.Framework.Base;
using ATP2.BDAID.Web.Framework.Util;
using Newtonsoft.Json;

namespace ATP2.BDAID.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new LoginModel(){Password = "123456789"};
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = userInfoService.Login2(model.Email);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            if (result.Data.StatusID != (int)EnumCollection.UserStatusEnum.Active)
            {
                ViewBag.Error = "Sorry You are not active User.";
                return View(model);
            }

            var userprofile = new UserProfile()
            {
                ID = result.Data.ID,
                Name = result.Data.Name,
                Email = result.Data.Email,
                UserTypeID = result.Data.UserTypeID,
            };

            var userprofileJson = JsonConvert.SerializeObject(userprofile);
            FormsAuthentication.SetAuthCookie(userprofileJson, false);
            if (result.Data.UserTypeID == (int)EnumCollection.UserTypeEnum.Admin || result.Data.UserTypeID == (int)EnumCollection.UserTypeEnum.Employee)
            {
                return RedirectToAction("Index", "AdminHost");
            }
            if (result.Data.UserTypeID == (int)EnumCollection.UserTypeEnum.RegisteredUser)
            {
                return RedirectToAction("Index", "RegisteredHost");
            }
            if (result.Data.UserTypeID == (int)EnumCollection.UserTypeEnum.NonRegisteredUser)
            {
                return RedirectToAction("Index2", "RegisteredHost");
            }
            return View(model);
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
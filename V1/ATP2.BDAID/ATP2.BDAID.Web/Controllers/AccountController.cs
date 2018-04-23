using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ATP2.BDAID.Data.Migrations;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Model;
using ATP2.BDAID.Model.Account;
using ATP2.BDAID.Web.Framework.Base;
using ATP2.BDAID.Web.Framework.Util;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using UserInfo = ATP2.BDAID.Entities.UserInfo;

namespace ATP2.BDAID.Web.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/
        public ActionResult Registration()
        {
           
            var model = new RegistrationModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userinfos = new UserInfo()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                UserTypeID = (int)EnumCollection.UserTypeEnum.RegisteredUser,
                StatusID = (int)EnumCollection.UserStatusEnum.Active

            };

            var result = userInfoService.Save(userinfos);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
           
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {

            if (User.Identity.IsAuthenticated && HttpUtil.UserProfile!=null)
            {

                if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.Admin)
                {
                    return RedirectToAction("Index", "AdminHost");
                }
            }
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = userInfoService.Login(model.Email, model.Password);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            if (result.Data.StatusID!=(int)EnumCollection.UserStatusEnum.Active)
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
            FormsAuthentication.SetAuthCookie(userprofileJson,false);
            if (result.Data.UserTypeID == (int)EnumCollection.UserTypeEnum.Admin)
            {
                return RedirectToAction("Index", "AdminHost");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}
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
using ATP2.BDAID.Repo.Account;
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
                Username = model.Username,
                Email = model.Email,
                Contact = model.Contact,
                Password = model.Password,
                Gender = model.Gender,
                Age = model.Age,
                UsertypeID = (int)EnumCollection.UserType.RegisteredUser
            };

            var result = userInfoDao.Save(userinfos);

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

                if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserType.Admin)
                {
                    return RedirectToAction("Index", "Host");
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
            var result = userInfoDao.Login(model.Email, model.Password);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            var userprofile = new UserProfile()
            {
                ID = result.Data.ID,
                Name = result.Data.Name,
                UserName = result.Data.Username,
                Email = result.Data.Email,
                UserTypeID = result.Data.UsertypeID,
            };

            var userprofileJson = JsonConvert.SerializeObject(userprofile);
            FormsAuthentication.SetAuthCookie(userprofileJson,false);
            if (result.Data.UsertypeID == (int)EnumCollection.UserType.Admin)
            {
                return RedirectToAction("Index", "Host");
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
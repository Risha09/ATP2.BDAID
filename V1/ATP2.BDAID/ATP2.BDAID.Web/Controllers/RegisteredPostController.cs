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
    public class RegisteredPostController : BaseController
    {
        //
        // GET: /RegisteredUser/Host/
        public ActionResult Index(int sid)
        {
            ViewBag.ServiceID = sid;
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ActionResult Donations()
        {
            ViewBag.ID = HttpUtil.UserProfile.ID;
            return View();
        }

        public ActionResult NewDonation(int pid)
        {
            var model = new Donation();
            model.PostID = pid;
            model.UserID = HttpUtil.UserProfile.ID;
            return View(model);
        }
        [HttpPost]
        public ActionResult NewDonation(Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return View(donation);
            }

            var donations = new Donation()
            {
                Mobile = donation.Mobile,
                Amount = donation.Amount,
                Transaction = donation.Transaction,
                UserID = donation.UserID,
                PostID = donation.PostID,
                Type = "Bkash"
            };

            var result = DonationService.Save(donations);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(donation);
            }

            return RedirectToAction("Index", "RegisteredPost", new { sid = -1 });
        }

        public ActionResult NewPost()
        {
            return View();
        }

        public ActionResult Response()
        {
            return View();
        }
	}
}
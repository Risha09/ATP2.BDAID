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
    public class RegisteredPostController : BaseController
    {
        //
        // GET: /RegisteredUser/Host/
        public ActionResult Index(int sid)
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            return View();
        }

        public ActionResult Donations()
        {
            return View();
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
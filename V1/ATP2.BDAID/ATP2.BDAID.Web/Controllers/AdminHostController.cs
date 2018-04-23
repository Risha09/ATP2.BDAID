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
    [BDAIDAuthorize(new int[] { (int)EnumCollection.UserTypeEnum.Admin, (int)EnumCollection.UserTypeEnum.Employee })]
    public class AdminHostController : BaseController
    {
        //
        // GET: /RegisteredUser/Host/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Web.Framework.Util;

namespace ATP2.BDAID.Web.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public class BDAIDAuthorize:FilterAttribute,IAuthorizationFilter
    {
        public EnumCollection.UserType UserType;
        public BDAIDAuthorize(EnumCollection.UserType userType)
        {
            UserType = userType;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated || HttpUtil.UserProfile == null)
            {
                filterContext.Result=new HttpUnauthorizedResult();
                return;
            }
            if (HttpUtil.UserProfile.UserTypeID != (int) UserType)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        Controller="Home",
                        Action="UnAuthorized"
                    }));
                return;
            }
        }
    }
}

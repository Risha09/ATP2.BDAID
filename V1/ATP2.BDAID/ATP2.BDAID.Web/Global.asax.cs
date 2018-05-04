using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ATP2.BDAID.Services.Account;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Services2.Interfaces;
using Unity;

namespace ATP2.BDAID.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUserInfoService, UserInfoService>();
            container.RegisterType<IDonationService, DonationService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IPostCommentService, PostCommentService>();
            container.RegisterType<IPostService, PostService>();
            container.RegisterType<IReg_UserService, Reg_UserService>();
            container.RegisterType<IServiceAuditService, ServiceAuditService>();
            container.RegisterType<IServiceTypeService, ServiceTypeService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}

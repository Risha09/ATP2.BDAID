using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using ATP2.BDAID.Data;
using ATP2.BDAID.Services.Account;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Services2.Interfaces;

namespace ATP2.BDAID.Web.Framework.Base
{
    public class BaseApiController : ApiController
    {
        private static IUserInfoService _userInfoService;
        public static IUserInfoService userInfoService
        {
            get
            {
                if (_userInfoService == null)
                    _userInfoService = new UserInfoService();
                return _userInfoService;

                //return DependencyResolver.Current.GetService<IUserInfoService>();
            }
        }

        private static IServiceTypeService _serviceTypeService;
        public static IServiceTypeService ServiceTypeService
        {
            get
            {
                if (_serviceTypeService == null)
                    _serviceTypeService = new ServiceTypeService();
                return _serviceTypeService;
            }
        }

        private static IEmployeeService _EmployeeService;
        public static IEmployeeService EmployeeService
        {
            get
            {
                if (_EmployeeService == null)
                    _EmployeeService = new EmployeeService();
                return _EmployeeService;
            }
        }

        private static IReg_UserService _Reg_UserService;
        public static IReg_UserService Reg_UserService
        {
            get
            {
                if (_Reg_UserService == null)
                    _Reg_UserService = new Reg_UserService();
                return _Reg_UserService;
            }
        }

        private static IPostService _PostService;
        public static IPostService PostService
        {
            get
            {
                if (_PostService == null)
                    _PostService = new PostService();
                return _PostService;
            }
        }

        private static IDonationService _DonationService;
        public static IDonationService DonationService
        {
            get
            {
                if (_DonationService == null)
                    _DonationService = new DonationService();
                return _DonationService;
            }
        }

        private static IPostCommentService _PostCommentService;
        public static IPostCommentService PostCommentService
        {
            get
            {
                if (_PostCommentService == null)
                    _PostCommentService = new PostCommentService();
                return _PostCommentService;
            }
        }

        private static IServiceAuditService _ServiceAuditService;
        public static IServiceAuditService ServiceAuditService
        {
            get
            {
                if (_ServiceAuditService == null)
                    _ServiceAuditService = new ServiceAuditService();
                return _ServiceAuditService;
            }
        }
    }
}

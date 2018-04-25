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

namespace ATP2.BDAID.Web.Framework.Base
{
    public class BaseApiController : ApiController
    {
        private static BDAIDDbContext _context;
        public static  BDAIDDbContext DbContext
        {
            get
            {
                if(_context==null)
                    _context=new BDAIDDbContext();
                return _context;
            }
        }

        private static UserInfoService _userInfoService;
        public static UserInfoService userInfoService
        {
            get
            {
                if (_userInfoService == null)
                    _userInfoService = new UserInfoService();
                return _userInfoService;
            }
        }

        private static ServiceTypeService _serviceTypeService;
        public static ServiceTypeService ServiceTypeService
        {
            get
            {
                if (_serviceTypeService == null)
                    _serviceTypeService = new ServiceTypeService();
                return _serviceTypeService;
            }
        }

        private static EmployeeService _EmployeeService;
        public static EmployeeService EmployeeService
        {
            get
            {
                if (_EmployeeService == null)
                    _EmployeeService = new EmployeeService();
                return _EmployeeService;
            }
        }

        private static Reg_UserService _Reg_UserService;
        public static Reg_UserService Reg_UserService
        {
            get
            {
                if (_Reg_UserService == null)
                    _Reg_UserService = new Reg_UserService();
                return _Reg_UserService;
            }
        }

        private static PostService _PostService;
        public static PostService PostService
        {
            get
            {
                if (_PostService == null)
                    _PostService = new PostService();
                return _PostService;
            }
        }

        private static DonationService _DonationService;
        public static DonationService DonationService
        {
            get
            {
                if (_DonationService == null)
                    _DonationService = new DonationService();
                return _DonationService;
            }
        }

        private static PostCommentService _PostCommentService;
        public static PostCommentService PostCommentService
        {
            get
            {
                if (_PostCommentService == null)
                    _PostCommentService = new PostCommentService();
                return _PostCommentService;
            }
        }

        private static ServiceAuditService _ServiceAuditService;
        public static ServiceAuditService ServiceAuditService
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

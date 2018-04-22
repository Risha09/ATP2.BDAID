using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATP2.BDAID.Data;
using ATP2.BDAID.Services.Account;

namespace ATP2.BDAID.Web.Framework.Base
{
    public class BaseController:Controller
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ATP2.BDAID.Data;
using ATP2.BDAID.Repo.Account;

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

        private static UserInfoRepo _userInfoRepo;
        public static UserInfoRepo userInfoRepo
        {
            get
            {
                if (_userInfoRepo == null)
                    _userInfoRepo = new UserInfoRepo();
                return _userInfoRepo;
            }
        }

        private static UserInfoDao _userInfoDao;
        public static UserInfoDao userInfoDao
        {
            get
            {
                if (_userInfoDao == null)
                    _userInfoDao = new UserInfoDao();
                return _userInfoDao;
            }
        }
    }
}

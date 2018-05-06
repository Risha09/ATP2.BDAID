using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Web.Framework.Base;
using ATP2.BDAID.Web.Framework.Util;

namespace ATP2.BDAID.Web.Controllers.api
{
    public class UserInfo2Controller : BaseApiController
    {
        [HttpGet]
        public List<UserInfo> GetAllRegisteredUser()
        {
            return userInfoService.GetAllByTypeID((int) EnumCollection.UserTypeEnum.RegisteredUser);
        }
    }
}

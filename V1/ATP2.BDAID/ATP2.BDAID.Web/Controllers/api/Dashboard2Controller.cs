using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Model.Admin;
using ATP2.BDAID.Web.Framework.Base;
using ATP2.BDAID.Web.Framework.Util;

namespace ATP2.BDAID.Web.Controllers.api
{
    public class Dashboard2Controller : BaseApiController
    {
        [HttpGet]
        public DashboardModel GetPosts2()
        {
            var model = new DashboardModel()
            {
                Labels = new List<string>(),
                Datas = new List<int>()
            };

            var services = ServiceTypeService.GetPostCount();

            foreach (var s in services)
            {
                model.Labels.Add(s.Name);
                model.Datas.Add(s.ServiceTypeID);
            }

            return model;
        }

        [HttpGet]
        public DashboardModel GetUsers()
        {
            var model = new DashboardModel()
            {
                Labels = new List<string>(),
                Datas = new List<int>()
            };

            var list = userInfoService.GetAll();
            var types = EnumCollection.GetUserTypeEnum();

            foreach (var s in types)
            {
                model.Labels.Add(s.Name);
                model.Datas.Add(list.Count(l => l.UserTypeID == s.ID));
            }

            return model;
        }

        [HttpGet]
        public DashboardModel GetResponses()
        {
            var model = new DashboardModel()
            {
                Labels = new List<string>(),
                Datas = new List<int>()
            };

            var list = PostCommentService.GetAll();
            var date = DateTime.Now.AddDays(-6);
            int i=1;
            for(var d=date;i<=7;d=d.AddDays(1),i++)
            {
                model.Labels.Add(d.ToString("ddd,dd"));
                model.Datas.Add(list.Count(l => l.COMMENTDATE.Day == d.Day));
            }

            return model;
        }


        [HttpGet]
        public DashboardModel GetPosts2ByCurrentUser()
        {
            var model = new DashboardModel()
            {
                Labels = new List<string>(),
                Datas = new List<int>()
            };

            if (HttpUtil.UserProfile == null)
                return model;

            var list = PostService.GetAllByUserId(HttpUtil.UserProfile.ID);
            var services = ServiceTypeService.GetAll();

            foreach (var s in services)
            {
                model.Labels.Add(s.Name);
                model.Datas.Add(list.Count(l => l.ServiceID == s.ID));
            }

            return model;
        }
    }
}

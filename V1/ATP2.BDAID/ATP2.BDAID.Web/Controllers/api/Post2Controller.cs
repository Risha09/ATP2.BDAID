using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Web.Framework.Base;
using ATP2.BDAID.Web.Framework.Util;

namespace ATP2.BDAID.Web.Controllers.api
{
    public class Post2Controller : BaseApiController
    {
        [HttpGet]
        public List<Post> GetAll(string key="")
        {
            return PostService.GetAll(key);
        }

        [HttpGet]
        public List<Post> GetAllByUserId(int uid)
        {
            return PostService.GetAllByUserId(uid);
        }

        [HttpGet]
        public List<Post> GetByService(int sid=-1)
        {
            return PostService.GetAllByServiceId(sid);
        }

        [HttpGet]
        public Result<Post> GetByID(int id)
        {
            return PostService.GetByID(id);
        }

        [HttpGet]
        public List<Service> GetAllServices()
        {
            return ServiceTypeService.GetAll();
        }

        [HttpGet]
        public Result<Post> UpdateStatus(int id,int statusId)
        {
            return PostService.UpdateStatus(id, statusId);
        }

        [HttpGet]
        public Result<Post> UpdateSupported(int id)
        {
            return PostService.UpdateSupport(id);
        }

        [HttpPost]
        public Result<Post> Save(Post post)
        {
            post.UserID = HttpUtil.UserProfile.ID;
            return PostService.Insert(post);
        }
    }
}

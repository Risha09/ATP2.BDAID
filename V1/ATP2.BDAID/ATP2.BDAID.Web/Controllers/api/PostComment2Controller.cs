using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Web.Framework.Base;

namespace ATP2.BDAID.Web.Controllers.api
{
    public class PostComment2Controller : BaseApiController
    {
        [HttpGet]
        public List<PostComment> GetAll()
        {
            return PostCommentService.GetAll();
        }

        [HttpGet]
        public List<PostComment> GetByPostID(int pid)
        {
            return PostCommentService.GetByPostID(pid);
        }

        [HttpGet]
        public List<PostComment> GetByUserID(int uid)
        {
            return PostCommentService.GetByUserID(uid);
        }
    }
}

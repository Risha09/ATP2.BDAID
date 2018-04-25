﻿using System;
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
    public class Post2Controller : BaseApiController
    {
        [HttpGet]
        public List<Post> GetAll(string key="")
        {
            return PostService.GetAll(key);
        }

        [HttpGet]
        public Result<Post> GetByID(int id)
        {
            return PostService.GetByID(id);
        }

        [HttpGet]
        public Result<Post> UpdateStatus(int id,int statusId)
        {
            return PostService.UpdateStatus(id, statusId);
        }
    }
}
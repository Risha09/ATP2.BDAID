using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Services.Admin;
using ATP2.BDAID.Web.Framework.Base;
using ATP2.BDAID.Web.Framework.Util;

namespace ATP2.BDAID.Web.Controllers.api
{
    public class Message2Controller : BaseApiController
    {
        [HttpGet]
        public List<Message> GetMessages(string receiver)
        {
            return MessageService.GetAllBySenderReceiver(HttpUtil.UserProfile.Email,receiver);
        }

        [HttpPost]
        public Result<Message> Send(Message message)
        {
            message.SenderEmail = HttpUtil.UserProfile.Email;
            return MessageService.Save(message);
        }
    }
}

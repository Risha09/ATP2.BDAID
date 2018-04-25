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
    public class Donation2Controller : BaseApiController
    {
        [HttpGet]
        public List<Donation> GetAll()
        {
            return DonationService.GetAll();
        }

        [HttpGet]
        public List<Donation> GetByPostID(int pid)
        {
            return DonationService.GetByPostID(pid);
        }

        [HttpGet]
        public List<Donation> GetByUserID(int uid)
        {
            return DonationService.GetByUserID(uid);
        }
    }
}

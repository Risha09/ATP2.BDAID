using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ATP2.BDAID.Framework.Object;
using Newtonsoft.Json;

namespace ATP2.BDAID.Web.Framework.Util
{
    public static class HttpUtil
    {
        public static UserProfile UserProfile
        {
            get
            {
                try
                {
                    var userprofileJson = JsonConvert.DeserializeObject<UserProfile>(HttpContext.Current.User.Identity.Name);
                    return userprofileJson;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    }
}

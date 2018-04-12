using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Framework.Constant
{
    
    public class EnumCollection
    {
        #region UserType
        public enum UserType
        {
            Admin=1,
            Employee=2,
            RegisteredUser=4,
            NonRegisteredUder=16
        }

        public static List<EnumDetail> GetUserTypeEnum()
        {
            var list = new List<EnumDetail>();
            list.Add(new EnumDetail()
            {
                ID = 1,
                Name = "Admin"
            });
            list.Add(new EnumDetail()
            {
                ID = 2,
                Name = "Employee"
            });
            list.Add(new EnumDetail()
            {
                ID = 4,
                Name = "Registered User"
            });
            list.Add(new EnumDetail()
            {
                ID = 16,
                Name = "Non-Registered User"
            });

            return list;
        }

        #endregion

    }
}

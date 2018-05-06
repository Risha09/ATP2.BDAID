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
        public enum UserTypeEnum
        {
            Admin=1,
            Employee=2,
            RegisteredUser=4,
            NonRegisteredUser=16
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

        public enum UserStatusEnum
        {
            Active = 1,
            Inactive = 2
        }

        public static List<EnumDetail> GetUserStatusEnum()
        {
            var list = new List<EnumDetail>();
            list.Add(new EnumDetail()
            {
                ID = 1,
                Name = "Active"
            });
            list.Add(new EnumDetail()
            {
                ID = 2,
                Name = "Inactive"
            });

            return list;
        }

        #endregion

        #region ServiceType

        public enum ServiceTypeEnum
        {
            Monetary = 1,
            NonMonetary = 2
        }

        public static List<EnumDetail> GetServiceTypeEnum()
        {
            var list = new List<EnumDetail>();
            list.Add(new EnumDetail()
            {
                ID = 1,
                Name = "Monetary"
            });
            list.Add(new EnumDetail()
            {
                ID = 2,
                Name = "Non Monetary"
            });
            return list;
        }

        #endregion

        #region Post


        public enum PostStausEnum
        {
            Pending = 1,
            Approved = 2,
            Verified=4,
            Rejected=16
        }

        public static List<EnumDetail> GetPostStatusEnum()
        {
            var list = new List<EnumDetail>();
            list.Add(new EnumDetail()
            {
                ID = 1,
                Name = "Pending"
            });
            list.Add(new EnumDetail()
            {
                ID = 2,
                Name = "Non Approved"
            });
            list.Add(new EnumDetail()
            {
                ID = 4,
                Name = "Verified"
            });
            list.Add(new EnumDetail()
            {
                ID = 16,
                Name = "Rejected"
            });
            return list;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;


namespace ATP2.BDAID.Services2.Interfaces
{
    public interface IUserInfoService:IBaseService<UserInfo>
    {
        Result<UserInfo> Login(string email, string password);
        Result<UserInfo> Login2(string email);
        List<UserInfo> GetAllByTypeID(int typeID);
    }
}

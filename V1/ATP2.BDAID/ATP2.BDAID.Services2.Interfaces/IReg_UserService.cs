using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Services2.Interfaces
{
    public interface IReg_UserService:IBaseService<Reg_User>
    {
        List<Reg_User> GetAll(string key);
        Result<Reg_User> GetByName(string name);
        Result<Reg_User> UpdateStatus(int id);
    }
}

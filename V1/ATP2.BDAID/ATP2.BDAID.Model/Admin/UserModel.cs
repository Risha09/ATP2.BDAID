using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;

namespace ATP2.BDAID.Model.Admin
{
    public class UserModel
    {
        public Reg_User User { get; set; }
        public List<Post> Posts { get; set; }
    }
}

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
    public interface IDonationService : IBaseService<Donation>
    {
        List<Donation> GetByPostID(int pid);
        List<Donation> GetByUserID(int uid);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;

namespace ATP2.BDAID.Data
{
    public class BDAIDDbContext:DbContext
    {
        public BDAIDDbContext()
            : base("BDAIDDBConnectionString")
        {
            
        }
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}

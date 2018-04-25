using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class ServiceAudit
    {
        public int ID { get; set; }
        public int SID { get; set; }
        public string Name { get; set; }
        public int ServiceTypeID { get; set; }
        public string USERNAME { get; set; }
        public DateTime CHANGEDATE { get; set; }
        public string ACTIONNAME { get; set; }
    }
}

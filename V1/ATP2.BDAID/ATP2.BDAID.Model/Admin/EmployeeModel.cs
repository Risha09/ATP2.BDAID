using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Model.Admin
{
    public class EmployeeModel
    {
        public Employee Employee { get; set; }
        public List<EnumDetail> Statuses { get; set; }
    }
}

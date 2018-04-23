using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Model.Admin
{
    public class ServiceModel
    {
        public Service Service { get; set; }
        public List<EnumDetail> ServiceTypes { get; set; }
    }
}

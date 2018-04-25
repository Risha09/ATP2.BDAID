using System;
using System.Collections.Generic;
using ATP2.BDAID.Data;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Services2.Interfaces;
using ServiceAudit = ATP2.BDAID.Entities.ServiceAudit;

namespace ATP2.BDAID.Services.Admin
{
    public class ServiceAuditService : IServiceAuditService
    {
        public List<ServiceAudit> GetAll()
        {
            var result = new List<ServiceAudit>();
            try
            {
                string query = "select * from ServiceAudit order by ID";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ServiceAudit u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                result=new List<ServiceAudit>();
            }
            return result;
        }

        private ServiceAudit ConvertToEntity(DataRow row)
        {
            try
            {
                ServiceAudit u = new ServiceAudit();
                u.ID = Int32.Parse(row["ID"].ToString());
                u.SID = Int32.Parse(row["SID"].ToString());
                u.Name = row["Name"].ToString();
                u.USERNAME = row["USERNAME"].ToString();
                u.ACTIONNAME = row["ACTIONNAME"].ToString();
                u.CHANGEDATE = Convert.ToDateTime(row["CHANGEDATE"].ToString());
                u.ServiceTypeID = Int32.Parse(row["ServiceTypeID"].ToString());
                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}

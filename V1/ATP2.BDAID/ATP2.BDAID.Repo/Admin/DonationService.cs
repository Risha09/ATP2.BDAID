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
using Donation = ATP2.BDAID.Entities.Donation;

namespace ATP2.BDAID.Services.Admin
{
    public class DonationService:IDonationService
    {
        public Result<Donation> Save(Donation value)
        {
            throw new NotImplementedException();
        }

        public List<Donation> GetAll()
        {
            var result = new List<Donation>();
            try
            {
                string query = "select d.*,u.Email from Donation d,UserInfo u where d.UserID=u.ID";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Donation u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Result<Donation> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Donation> GetByPostID(int pid)
        {
            var result = new List<Donation>();
            try
            {
                string query = "select c.*,u.Email from Donation c,UserInfo u where c.UserID=u.ID and c.PostID=" + pid;
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Donation u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Donation> GetByUserID(int uid)
        {
            var result = new List<Donation>();
            try
            {
                string query = "select c.*,u.Email from Donation c,UserInfo u where c.UserID=u.ID and c.UserID=" + uid;
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Donation u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        private Donation ConvertToEntity(DataRow row)
        {
            try
            {
                Donation u = new Donation();
                u.ID = Int32.Parse(row["ID"].ToString());
                u.POSTID = Int32.Parse(row["POSTID"].ToString());
                u.USERID = Int32.Parse(row["USERID"].ToString());
                u.AMOUNT = Int32.Parse(row["AMOUNT"].ToString());
                u.Type = row["TYPE"].ToString();
                u.UserEmail = row["EMAIL"].ToString();
                u.DONATEDATE = Convert.ToDateTime(row["DONATEDATE"].ToString());
                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}

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
            var result = new Result<Donation>();
            try
            {
                string query = "select * from Donation where ID=" + value.ID;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    value.ID = GetID();
                    var date = Convert.ToDateTime(System.DateTime.Now);
                    //query = "insert into Donation values(" + value.ID + "," + date + ",'" + value.Type + "','" + value.Amount + "','" + value.PostID + "','" + value.UserID + "','" + value.Transaction + "','" + value.Mobile + "')";
                    query = "insert into Donation values(1,23-JAN-19,'Bkash',1000.0,3,4,547897,0987654567)";
                }

                result.HasError = DataAccess.ExecuteQuery(query) <= 0;

                if (result.HasError)
                {
                    result.Message = "Something Went Wrong";
                    return result;
                }

                result.Data = value;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        private int GetID()
        {
            string query = "select * from Donation order by ID desc";
            var dt = DataAccess.GetDataTable(query);
            int id = 1;

            if (dt != null && dt.Rows.Count != 0)
                id = Int32.Parse(dt.Rows[0]["ID"].ToString()) + 1;

            return id;
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
                u.PostID = Int32.Parse(row["POSTID"].ToString());
                u.UserID = Int32.Parse(row["USERID"].ToString());
                u.Amount = Int32.Parse(row["AMOUNT"].ToString());
                u.Type = row["TYPE"].ToString();
                u.DonateDate = Convert.ToDateTime(row["DONATEDATE"].ToString());
                u.Mobile = Int32.Parse(row["MOBILE"].ToString());
                u.Transaction = Int32.Parse(row["TRANSACTION"].ToString());
                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}

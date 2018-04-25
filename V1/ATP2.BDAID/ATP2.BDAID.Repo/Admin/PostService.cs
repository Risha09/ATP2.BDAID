using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Globalization;
using ATP2.BDAID.Data;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using Oracle.ManagedDataAccess.Client;

namespace ATP2.BDAID.Services.Admin
{
    public class PostService
    {
        private int GetID()
        {
            string query = "select * from Post order by ID desc";
            var dt = DataAccess.GetDataTable(query);
            int id = 1;

            if (dt != null && dt.Rows.Count != 0)
                id = Int32.Parse(dt.Rows[0]["ID"].ToString()) + 1;

            return id;
        }

        public List<Post> GetAll(string key = "")
        {
            var result = new List<Post>();
            try
            {
                string query = "select * from PostView";

                if (ValidationHelper.IsStringValid(key))
                {
                    query += " where Title like '%" + key + "%' or DESCRIPTION like '%" + key + "%' or UName like '%" + key + "%' or Email like '%" + key + "%'";
                }

                query += " order by ID desc";

                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Post u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Post> GetAll2(int sid)
        {
            var result = new List<Post>();
            try
            {
                string query = "select * from PostView where (StatusID=" + (int)EnumCollection.PostStausEnum.Approved + " or StatusID=" + (int)EnumCollection.PostStausEnum.Verified + ")";

                if (sid != -1)
                {
                    query += " and ServiceID=" + sid ;
                }

                query += " order by ID desc";

                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Post u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Post> GetAllByUserId(int userId)
        {
            var result = new List<Post>();
            try
            {
                string query = "select * from PostView where UserID=" + userId;


                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Post u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Result<Post> GetByID(int id)
        {
            var result = new Result<Post>();
            try
            {
                string query = "select * from PostView where ID=" + id;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    result.HasError = true;
                    result.Message = "Invalid ID";
                    return result;
                }

                result.Data = ConvertToEntity(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Post> Insert(Post post)
        {
            var result = new Result<Post>();
            try
            {
                post.ID = GetID();

                post.Area = ValidationHelper.IsStringValid(post.Area) ? post.Area : "-";
                post.Address = ValidationHelper.IsStringValid(post.Address) ? post.Address : "-";
                post.Payment = ValidationHelper.IsStringValid(post.Payment) ? post.Payment : "-";
                post.InCharge = ValidationHelper.IsStringValid(post.InCharge) ? post.InCharge : "-";
                post.Funding = post.Funding;
                post.People = post.People;
                post.Disease = ValidationHelper.IsStringValid(post.Disease) ? post.Disease : "-";
                post.Contact = ValidationHelper.IsStringValid(post.Contact) ? post.Contact : "-";
                post.ServiceID = post.ServiceID;
                post.UserID = post.UserID;
                post.StatusID = (int)EnumCollection.PostStausEnum.Pending;
                post.Supported = 0;

                string query = "insert into Post Values(" + post.ID + ",'" + post.Title + "','" 
                               + post.Description + "','" + post.Area + "','" + post.Address + "','" 
                               + post.Payment + "','" + post.InCharge + "'," + post.Funding + "," + post.People 
                               + ",'" + post.Disease + "','" + post.Contact + "'," + post.ServiceID + "," 
                               + post.UserID + ",SYSDATE," + post.StatusID + "," + post.Supported + ")";

                result.HasError = DataAccess.ExecuteQuery(query)<=0;

                if (result.HasError)
                {
                    result.Message = "Something Went Wrong";
                    return result;
                }

                result.Data = post;

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Post> UpdateStatus(int id, int statusID)
        {
            var result = new Result<Post>();
            string query = "select * from PostView where ID=" + id;

            var dt = DataAccess.GetDataTable(query);

            if (dt == null || dt.Rows.Count == 0)
            {
                result.HasError = true;
                result.Message = "Invalid ID";
                return result;
            }
            try
            {
                query = "update Post set statusID=" + statusID + " where ID=" + id;
                result.HasError = DataAccess.ExecuteQuery(query) <= 0;

                if (result.HasError)
                    result.Message = "Something Went Wrong";
                else
                {
                    result = GetByID(id);
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }

        public bool Delete(int id)
        {
            var result = new Result<Post>();
            try
            {
                string query = "delete from Post where ID=" + id;
                return DataAccess.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsValid(Post obj, Result<Post> result)
        {
            if (!ValidationHelper.IsStringValid(obj.UserInfo.Name))
            {
                result.HasError = true;
                result.Message = "Invalid Name";
                return false;
            }
            if (!ValidationHelper.IsStringValid(obj.UserInfo.Email))
            {
                result.HasError = true;
                result.Message = "Invalid Email";
                return false;
            }
            return true;
        }

        private Post ConvertToEntity(DataRow row)
        {
            try
            {
                Post post = new Post() { UserInfo = new UserInfo(), Service = new Service() };
                post.ID = Int32.Parse(row["ID"].ToString());
                post.Title = row["Title"].ToString();
                post.Description = row["Description"].ToString();
                post.Area = row["Area"].ToString();
                post.Address = row["Address"].ToString();
                post.Payment = row["Payment"].ToString();
                post.InCharge = row["InCharge"].ToString();
                post.Funding = float.Parse(row["FUNDING"].ToString());
                post.People = Int32.Parse(row["People"].ToString());
                post.Disease = row["Disease"].ToString();
                post.Contact = row["Contact"].ToString();
                post.ServiceID = Int32.Parse(row["ServiceID"].ToString());
                post.UserID = Int32.Parse(row["UserID"].ToString());
                post.StatusID = Int32.Parse(row["StatusID"].ToString());
                post.Supported = Int32.Parse(row["Supported"].ToString());
                string dob = row["PostDate"].ToString();
                post.PostDate = Convert.ToDateTime(dob);

                post.UserInfo.ID = Int32.Parse(row["UserID"].ToString());
                post.UserInfo.Email = row["Email"].ToString();
                post.Service.ID = Int32.Parse(row["SID"].ToString());
                post.Service.Name = row["Name"].ToString();
                post.Service.ServiceTypeID = Int32.Parse(row["ServiceTypeID"].ToString());

                return post;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}

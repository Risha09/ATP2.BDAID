using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Data;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Services2.Interfaces;

namespace ATP2.BDAID.Services.Admin
{
    public class Reg_UserService : IReg_UserService
    {
        public List<Reg_User> GetAll(string key)
        {
            var result = new List<Reg_User>();
            try
            {
                //string query = "DECLARE  CURSOR USERS_cur is select * from userinfo left outer join reg_user using (ID) WHERE ID NOT IN(1,2);USERS_rec USERS_cur%rowtype; BEGIN OPEN USERS_cur; LOOP FETCH USERS_cur into USERS_rec; EXIT WHEN USERS_cur%notfound; DBMS_OUTPUT.put_line(USERS_rec.id || ' ' || USERS_rec.Uname);  END LOOP; END; ";
                string query = "select * from UserView";

                if (ValidationHelper.IsStringValid(key))
                {
                    query += " where UName like '%" + key + "%' or Email like '%" + key + "%'";
                }

                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Reg_User u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Result<Reg_User> Save(Reg_User value)
        {
            throw new NotImplementedException();
        }

        public List<Reg_User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<Reg_User> GetByID(int id)
        {
            var result = new Result<Reg_User>();
            try
            {
                string query = "select * from UserView where ID=" + id;
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result<Reg_User> GetByName(string name)
        {
            var result = new Result<Reg_User>();
            try
            {
                string query = "select * from UserView where uname=" + name;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
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

        public Result<Reg_User> UpdateStatus(int id)
        {
            var result = GetByID(id);
            if (result.HasError)
            {
                return result;
            }

            try
            {
                int s = -1;

                if (result.Data.UserInfo.StatusID == (int) EnumCollection.UserStatusEnum.Active)
                    s = (int) EnumCollection.UserStatusEnum.Inactive;
                else
                    s = (int) EnumCollection.UserStatusEnum.Active;

                string query = "update UserInfo set statusID=" + s + " where ID=" + id;
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

        private Reg_User ConvertToEntity(DataRow row)
        {
            try
            {
                Reg_User rg = new Reg_User() { UserInfo= new UserInfo() };
                rg.ID = Int32.Parse(row["ID"].ToString());
                string dob = row["DOB"].ToString();
                
                if (dob != "")
                    rg.DOB = Convert.ToDateTime(dob);

                rg.Contact = row["Contact"].ToString();
                rg.Profession = row["Profession"].ToString();
                rg.Gender = row["Gender"].ToString();
                rg.Address = row["Address"].ToString();
                rg.RefID = -1;
                rg.UserInfo.ID = Int32.Parse(row["ID"].ToString());
                rg.UserInfo.Name = row["UName"].ToString();
                rg.UserInfo.Email = row["Email"].ToString();
                rg.UserInfo.Password = row["Password"].ToString();
                rg.UserInfo.UserTypeID = Int32.Parse(row["UserTypeID"].ToString());
                rg.UserInfo.StatusID = Int32.Parse(row["StatusID"].ToString());

                return rg;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

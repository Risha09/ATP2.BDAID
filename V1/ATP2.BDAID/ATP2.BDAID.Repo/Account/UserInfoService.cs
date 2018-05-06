using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Data;
using ATP2.BDAID.Data.Migrations;
using ATP2.BDAID.Framework.Constant;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Model.Account;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Services2.Interfaces;
using UserInfo = ATP2.BDAID.Entities.UserInfo;

namespace ATP2.BDAID.Services.Account
{
    public class UserInfoService : IUserInfoService
    {
        public Result<UserInfo> Save(UserInfo userinfo)
        {
            var result = new Result<UserInfo>();
            try
            {
                string query = "select * from UserInfo where ID=" + userinfo.ID;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    userinfo.ID = GetID();
                    query = "insert into UserInfo values(" + userinfo.ID + ",'" + userinfo.Name + "','" + userinfo.Email + "','" + userinfo.Password + "'," + userinfo.UserTypeID + "," + userinfo.StatusID + ")";
                }
                else
                {
                    query =
                        "update UserInfo set UName='" + userinfo.Name + "',Email='" + userinfo.Email + "',Password=" + userinfo.Password + ",UsertypeID=" + userinfo.UserTypeID + ",StatusID=" + userinfo.StatusID + " where ID=" +
                        userinfo.ID;
                }

                if (!IsValid(userinfo, result))
                {
                    return result;
                }

                result.HasError = DataAccess.ExecuteQuery(query) <= 0;

                if (result.HasError)
                    result.Message = "Something Went Wrong";
                else
                {
                    result.Data = userinfo;
                }
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
            string query = "select * from UserInfo order by ID desc";
            var dt = DataAccess.GetDataTable(query);
            int id = 1;

            if (dt != null && dt.Rows.Count != 0)
                id = Int32.Parse(dt.Rows[0]["ID"].ToString()) + 1;

            return id;
        }

        public Result<UserInfo> Login(string email, string password)
        {
            var result = new Result<UserInfo>();
            try
            {
                string query = "select * from UserInfo where Email='" + email + "' and Password='" + password + "'";
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    result.HasError = true;
                    result.Message = "Invalid Email or Pssword";
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

        public Result<UserInfo> Login2(string email)
        {
            var result = new Result<UserInfo>();
            try
            {
                string query = "select * from UserInfo where Email='" + email +"'";
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    var userInfo = new UserInfo()
                    {
                        ID=0,Email = email,Name = email,Password = "123456789",StatusID = (int)EnumCollection.UserStatusEnum.Active,UserTypeID = (int)EnumCollection.UserTypeEnum.NonRegisteredUser
                    };

                    return this.Save(userInfo);
                }

                result.Data = ConvertToEntity(dt.Rows[0]);
                if (result.Data.UserTypeID != (int) EnumCollection.UserTypeEnum.NonRegisteredUser)
                {
                    result.HasError = true;
                    result.Message = "Only Non-Registered User Can Use This Feature";
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public List<UserInfo> GetAll()
        {
            var result = new List<UserInfo>();
            try
            {
                string query = "select * from UserInfo";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UserInfo u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<UserInfo> GetAllByTypeID(int typeID)
        {
            var result = new List<UserInfo>();
            try
            {
                string query = "select * from UserInfo where USERTYPEID="+typeID;
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UserInfo u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Result<UserInfo> GetByID(int id)
        {
            var result = new Result<UserInfo>();
            try
            {
                string query = "select * from UserInfo where ID=" + id;
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
            var result = new Result<UserInfo>();
            try
            {
                string query = "delete from UserInfo where ID=" + id;
                return DataAccess.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsValid(UserInfo obj, Result<UserInfo> result)
        {
            if (!ValidationHelper.IsStringValid(obj.Name))
            {
                result.HasError = true;
                result.Message = "Invalid Name";
                return false;
            }

            if (!ValidationHelper.IsStringValid(obj.Email))
            {
                result.HasError = true;
                result.Message = "Invalid Email";
                return false;
            }

            if (!ValidationHelper.IsStringValid(obj.Password) || obj.Password.Length < 8)
            {
                result.HasError = true;
                result.Message = "Invalid Password";
                return false;
            }

            string query = "select * from UserInfo where Email='" + obj.Email + "' and ID!=" + obj.ID;
            var dt = DataAccess.GetDataTable(query);
            if (dt!=null && dt.Rows.Count>0)
            {
                result.HasError = true;
                result.Message = "Email Exists";
                return false;
            }
            return true;
        }

        private UserInfo ConvertToEntity(DataRow row)
        {
            try
            {
                UserInfo u = new UserInfo();
                u.ID = Int32.Parse(row["ID"].ToString());
                u.Name = row["UName"].ToString();
                u.Email = row["Email"].ToString();
                u.Password = row["Password"].ToString();
                u.UserTypeID = Int32.Parse(row["UserTypeID"].ToString());
                u.StatusID = Int32.Parse(row["StatusID"].ToString());
                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}

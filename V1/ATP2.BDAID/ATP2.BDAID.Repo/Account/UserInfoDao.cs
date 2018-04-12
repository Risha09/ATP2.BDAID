using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Data;
using ATP2.BDAID.Data.Migrations;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Model.Account;
using ATP2.BDAID.Repo.Base;
using ATP2.BDAID.Entities;
using UserInfo = ATP2.BDAID.Entities.UserInfo;

namespace ATP2.BDAID.Repo.Account
{
     public class UserInfoDao
    {
         public Result<UserInfo> Save(UserInfo userinfo)
         {
             var result = new Result<UserInfo>();
             try
             {
                 string query = "select * from UserInfo where ID="+userinfo.ID;
                 var dt = DataAccess.GetDataTable(query);

                 if (dt == null || dt.Rows.Count==0)
                 {
                     userinfo.ID = GetID();
                     query = "insert into UserInfo values("+userinfo.ID+",'" + userinfo.Username + "','" + userinfo.Name + "','" + userinfo.Email + "','" + userinfo.Contact + "','" + userinfo.Password + "'," + userinfo.Age + ",'" + userinfo.Gender + "'," + userinfo.UsertypeID + ")";
                 }
                 else
                 {
                     query =
                         "update UserInfo set UserName='" + userinfo.Username + "',Name='" + userinfo.Name + "',Email='" + userinfo.Email + "',Contact='" + userinfo.Contact + "',Password=" + userinfo.Password + ",Age=" + userinfo.Age + ",Gender='" + userinfo.Gender + "',UsertypeID=" + userinfo.UsertypeID + " where ID=" +
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

         public Result<UserInfo> Login(string email,string password)
         {
             var result = new Result<UserInfo>();
             try
             {
                 string query = "select * from UserInfo where Email='"+email+"' and Password='"+password+"'";
                 var dt = DataAccess.GetDataTable(query);

                 if (dt == null || dt.Rows.Count==0)
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

         public List<UserInfo> GetAll()
         {
             var result = new List<UserInfo>();
             try
             {
                 string query = "select * from UserInfo";
                 var dt = DataAccess.GetDataTable(query);

                 if (dt != null && dt.Rows.Count != 0)
                 {
                     for (int i = 0; i <= dt.Rows.Count; i++)
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
             if (!ValidationHelper.IsStringValid(obj.Username))
             {
                 result.HasError = true;
                 result.Message = "Invalid UserName";
                 return false;
             } 
             if (!ValidationHelper.IsStringValid(obj.Password)|| obj.Password.Length<8)
             {
                 result.HasError = true;
                 result.Message = "Invalid Password";
                 return false;
             }
             //if (DbContext.UserInfos.Any(u => u.Username == obj.Username && u.ID != obj.ID))
             //{
             //    result.HasError = true;
             //    result.Message = "UserName already exists";
             //    return false;
             //}
             //if (DbContext.UserInfos.Any(u => u.Email == obj.Email && u.ID != obj.ID))
             //{
             //    result.HasError = true;
             //    result.Message = "Invalid Email";
             //    return false;
             //}
             return true;
         }

         private UserInfo ConvertToEntity(DataRow row)
         {
             try
             {
                 UserInfo u = new UserInfo();
                 u.ID = Int32.Parse(row["ID"].ToString());
                 u.Username = row["Username"].ToString();
                 u.Name = row["Name"].ToString();
                 u.Email = row["Email"].ToString();
                 u.Password = row["Password"].ToString();
                 u.Contact = row["Contact"].ToString();
                 u.Gender = row["Gender"].ToString();
                 u.Age = Int32.Parse(row["Age"].ToString());
                 u.UsertypeID = Int32.Parse(row["UsertypeID"].ToString());
                 return u;
             }
             catch (Exception)
             {
                 return null;
             }
             
         }
    }
}

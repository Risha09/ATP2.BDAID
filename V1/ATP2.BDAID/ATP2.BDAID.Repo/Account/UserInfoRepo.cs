using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Data.Migrations;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Model.Account;
using ATP2.BDAID.Repo.Base;
using ATP2.BDAID.Entities;
using UserInfo = ATP2.BDAID.Entities.UserInfo;

namespace ATP2.BDAID.Repo.Account
{
     public class UserInfoRepo:BaseRepo
    {
         public Result<UserInfo> Save(UserInfo userinfo)
         {
             var result = new Result<UserInfo>();
             try
             {
                 var objtosave = DbContext.UserInfos.FirstOrDefault(u => u.ID == userinfo.ID);
                 if (objtosave == null)
                 {
                     objtosave = new UserInfo();
                     DbContext.UserInfos.Add(objtosave);
                 }
                 objtosave.Name = userinfo.Name;
                 objtosave.Username = userinfo.Username;
                 objtosave.UsertypeID = userinfo.UsertypeID;
                 objtosave.Email = userinfo.Email;
                 objtosave.Password = userinfo.Password;
                 objtosave.Gender = userinfo.Gender;
                 objtosave.Age = userinfo.Age;
                 objtosave.Contact = userinfo.Contact;

                 if (!IsValid(objtosave, result))
                 {
                     return result;
                 }
                 DbContext.SaveChanges();
             }
             catch (Exception ex)
             {
                 result.HasError = true;
                 result.Message = ex.Message;
             }
             return result;
         }

         public Result<UserInfo> Login(string email,string password)
         {
             var result = new Result<UserInfo>();
             try
             {
                 var obj = DbContext.UserInfos.FirstOrDefault(u => u.Email == email && u.Password==password);
                 if (obj == null)
                 {
                     result.HasError = true;
                     result.Message = "Invalid Email or Pssword";
                     return result;
                 }

                 result.Data = obj;
             }
             catch (Exception ex)
             {
                 result.HasError = true;
                 result.Message = ex.Message;
             }
             return result;
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
             if (DbContext.UserInfos.Any(u => u.Username == obj.Username && u.ID != obj.ID))
             {
                 result.HasError = true;
                 result.Message = "UserName already exists";
                 return false;
             }
             if (DbContext.UserInfos.Any(u => u.Email == obj.Email && u.ID != obj.ID))
             {
                 result.HasError = true;
                 result.Message = "Invalid Email";
                 return false;
             }
             return true;
         }
    }
}

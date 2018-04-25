using System;
using System.Collections.Generic;
using System.Globalization;
using ATP2.BDAID.Data;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Services2.Interfaces;

namespace ATP2.BDAID.Services.Admin
{
    public class EmployeeService : IEmployeeService
    {
        public Result<Employee> Save(Employee employee)
        {
            var result = new Result<Employee>();
            try
            {
                string query = "select * from Employee where ID=" + employee.ID;
                var dt = DataAccess.GetDataTable(query);
                string queryUser, queryEmployee;

                if (dt == null || dt.Rows.Count == 0)
                {
                    employee.ID = GetID();
                    queryUser = "insert into UserInfo values(" + employee.ID + ",'" + employee.UserInfo.Name + "','" + employee.UserInfo.Email + "','" + employee.UserInfo.Password + "'," + employee.UserInfo.UserTypeID + "," + employee.UserInfo.StatusID + ")";
                    queryEmployee = "insert into Employee values(" + employee.ID + ",TO_DATE('" + employee.DOB.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd')," + employee.Salary + ",'" + employee.Contact + "','" + employee.Gender + "')";
                }
                else
                {
                    queryUser =
                        "update UserInfo set UName='" + employee.UserInfo.Name + "',Email='" + employee.UserInfo.Email + "',Password='" + employee.UserInfo.Password + "',UsertypeID=" + employee.UserInfo.UserTypeID + ",StatusID=" + employee.UserInfo.StatusID + " where ID=" +
                        employee.ID;
                    queryEmployee =
                        "update Employee set DOB=TO_DATE('" + employee.DOB.ToString("yyyy/MM/dd") + "', 'yyyy/mm/dd'),Salary=" + employee.Salary + ",Contact='" + employee.Contact + "',Gender='" + employee.Gender + "' where ID=" +
                        employee.ID;
                }

                if (!IsValid(employee, result))
                {
                    return result;
                }

                result.HasError = DataAccess.ExecuteTransactionQuery(queryUser,queryEmployee) <= 0;

                if (result.HasError)
                    result.Message = "Something Went Wrong";
                else
                {
                    result.Data = employee;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
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

        public List<Employee> GetAll(string key)
        {
            var result = new List<Employee>();
            try
            {
                string query = "select * from EmployeeView";

                if (ValidationHelper.IsStringValid(key))
                {
                    query += " where UName like '%" + key + "%' or Email like '%" + key + "%'";
                }

                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Employee u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Result<Employee> GetByID(int id)
        {
            var result = new Result<Employee>();
            try
            {
                string query = "select * from EmployeeView where ID=" + id;
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
            var result = new Result<Employee>();
            try
            {
                string query = "delete from Employee where ID=" + id;
                return DataAccess.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsValid(Employee obj, Result<Employee> result)
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

        private Employee ConvertToEntity(DataRow row)
        {
            try
            {
                Employee emp = new Employee(){UserInfo = new UserInfo()};
                emp.ID = Int32.Parse(row["ID"].ToString());
                string dob = row["DOB"].ToString();
                emp.DOB = Convert.ToDateTime(dob);
                emp.Salary = float.Parse(row["Salary"].ToString());
                emp.Contact = row["Contact"].ToString();
                emp.Gender = row["Gender"].ToString();
                emp.UserInfo.ID = Int32.Parse(row["UserID"].ToString());
                emp.UserInfo.Name = row["UName"].ToString();
                emp.UserInfo.Email = row["Email"].ToString();
                emp.UserInfo.Password = row["Password"].ToString();
                emp.UserInfo.UserTypeID = Int32.Parse(row["UserTypeID"].ToString());
                emp.UserInfo.StatusID = Int32.Parse(row["StatusID"].ToString());

                return emp;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using ATP2.BDAID.Data;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using Service = ATP2.BDAID.Entities.Service;

namespace ATP2.BDAID.Services.Admin
{
    public class ServiceTypeService
    {
        public Result<Service> Save(Service service)
        {
            var result = new Result<Service>();
            try
            {
                string query = "select * from Service where ID=" + service.ID;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    service.ID = GetID();
                    query = "insert into Service values(" + service.ID + ",'" + service.Name + "'," + service.ServiceTypeID + ")";
                }
                else
                {
                    query =
                        "update Service set Name='" + service.Name + "',ServiceTypeID=" + service.ServiceTypeID + "where ID=" +service.ID;
                }

                if (!IsValid(service, result))
                {
                    return result;
                }

                result.HasError = DataAccess.ExecuteQuery(query) <= 0;

                if (result.HasError)
                    result.Message = "Something Went Wrong";
                else
                {
                    result.Data = service;
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
            string query = "select * from Service order by ID desc";
            var dt = DataAccess.GetDataTable(query);
            int id = 1;

            if (dt != null && dt.Rows.Count != 0)
                id = Int32.Parse(dt.Rows[0]["ID"].ToString()) + 1;

            return id;
        }

        public List<Service> GetAll()
        {
            var result = new List<Service>();
            try
            {
                string query = "select * from Service";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {
                        Service u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Result<Service> GetByID(int id)
        {
            var result = new Result<Service>();
            try
            {
                string query = "select * from Service where ID=" + id;
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
            var result = new Result<Service>();
            try
            {
                string query = "delete from Service where ID=" + id;
                return DataAccess.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsValid(Service obj, Result<Service> result)
        {
            if (!ValidationHelper.IsStringValid(obj.Name))
            {
                result.HasError = true;
                result.Message = "Invalid Name";
                return false;
            }
            if (!ValidationHelper.IsIntValid(obj.ServiceTypeID.ToString()))
            {
                result.HasError = true;
                result.Message = "Invalid service type";
                return false;
            }
            return true;
        }

        private Service ConvertToEntity(DataRow row)
        {
            try
            {
                Service u = new Service();
                u.ID = Int32.Parse(row["ID"].ToString());
                u.Name = row["Name"].ToString();
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

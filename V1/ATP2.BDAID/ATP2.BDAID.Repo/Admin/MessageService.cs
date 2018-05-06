using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Data;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;
using ATP2.BDAID.Services2.Interfaces;

namespace ATP2.BDAID.Services.Admin
{
    public class MessageService:IMessageService
    {
        public Result<Message> Save(Message value)
        {
            var result = new Result<Message>();
            try
            {
                value.ID = GetID();
                string query="insert into Message values(" +value.ID+ ",'"+value.SenderEmail+"','"+value.ReceiverEmail+"','"+value.Messages+"',SYSDATE)";
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

        public List<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<Message> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllBySenderReceiver(string SenderEmail, string ReceiverEmail)
        {
            var result = new List<Message>();
            try
            {
                string query = "select * from Message where (SenderEmail='" + SenderEmail + "' and ReceiverEmail='" +
                               ReceiverEmail + "') or (SenderEmail='" + ReceiverEmail + "' and ReceiverEmail='" +
                               SenderEmail + "') order by ID";

                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Message u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return result;
        }

        private Message ConvertToEntity(DataRow row)
        {
            try
            {
                Message msg = new Message();
                msg.ID = Int32.Parse(row["ID"].ToString());
                msg.MessageDate = Convert.ToDateTime(row["MessageDate"].ToString());
                msg.SenderEmail = row["SenderEmail"].ToString();
                msg.ReceiverEmail = row["ReceiverEmail"].ToString();
                msg.Messages = row["Messages"].ToString();

                return msg;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private int GetID()
        {
            string query = "select * from Message order by ID desc";
            var dt = DataAccess.GetDataTable(query);
            int id = 1;

            if (dt != null && dt.Rows.Count != 0)
                id = Int32.Parse(dt.Rows[0]["ID"].ToString()) + 1;

            return id;
        }
    }
}

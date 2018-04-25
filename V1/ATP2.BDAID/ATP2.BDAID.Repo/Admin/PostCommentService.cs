using System;
using System.Collections.Generic;
using ATP2.BDAID.Data;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Framework.Helper;
using ATP2.BDAID.Framework.Object;
using PostComment = ATP2.BDAID.Entities.PostComment;

namespace ATP2.BDAID.Services.Admin
{
    public class PostCommentService
    {
        public List<PostComment> GetAll()
        {
            var result = new List<PostComment>();
            try
            {
                string query = "select c.*,u.Email from PostComment c,UserInfo u where c.UserID=u.ID order by c.ID";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PostComment u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<PostComment> GetByPostID(int pid)
        {
            var result = new List<PostComment>();
            try
            {
                string query = "select c.*,u.Email from PostComment c,UserInfo u where c.UserID=u.ID and c.PostID=" + pid + " order by c.ID";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PostComment u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<PostComment> GetByUserID(int uid)
        {
            var result = new List<PostComment>();
            try
            {
                string query = "select c.*,u.Email from PostComment c,UserInfo u where c.UserID=u.ID and c.UserID=" + uid + " order by c.ID";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PostComment u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        private PostComment ConvertToEntity(DataRow row)
        {
            try
            {
                PostComment u = new PostComment();
                u.ID = Int32.Parse(row["ID"].ToString());
                u.POSTID = Int32.Parse(row["POSTID"].ToString());
                u.USERID = Int32.Parse(row["USERID"].ToString());
                u.COMMENTS = row["COMMENTS"].ToString();
                u.UserEmail = row["EMAIL"].ToString();
                u.COMMENTDATE = Convert.ToDateTime(row["COMMENTDATE"].ToString());
                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}

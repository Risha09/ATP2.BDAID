using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Services2.Interfaces
{
    public interface IPostCommentService:IBaseService<PostComment>
    {
        Result<PostComment> Insert(PostComment comment);
        List<PostComment> GetByPostID(int pid);
        List<PostComment> GetByUserID(int uid);
    }
}

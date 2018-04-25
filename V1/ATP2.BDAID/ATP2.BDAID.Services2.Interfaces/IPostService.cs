using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Services2.Interfaces
{
    public interface IPostService:IBaseService<Post>
    {
        List<Post> GetAll(string key);
        List<Post> GetAllByServiceId(int sid);
        List<Post> GetAllByUserId(int userId);
        Result<Post> Insert(Post post);
        Result<Post> UpdateStatus(int id, int statusID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Framework.Object;

namespace ATP2.BDAID.Services2.Interfaces
{
    public interface IBaseService<T>
    {
        Result<T> Save(T value);
        List<T> GetAll();
        Result<T> GetByID(int id);
        bool Delete(int id);
    }
}

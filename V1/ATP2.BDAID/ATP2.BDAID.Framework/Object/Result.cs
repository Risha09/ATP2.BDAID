using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Framework.Object
{
    public class Result<T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

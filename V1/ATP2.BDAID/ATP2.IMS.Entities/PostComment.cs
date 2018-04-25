using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class PostComment
    {
        public int ID { get; set; }
        public string COMMENTS { get; set; }
        public DateTime COMMENTDATE { get; set; }
        public int POSTID { get; set; }
        public int USERID { get; set; }
        public string UserEmail { get; set; }
    }
}

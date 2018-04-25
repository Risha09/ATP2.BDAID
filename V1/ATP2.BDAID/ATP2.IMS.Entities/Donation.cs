using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class Donation
    {
        public int ID { get; set; }
        public DateTime DONATEDATE { get; set; }
        public string Type { get; set; }
        public float AMOUNT { get; set; }
        public int POSTID { get; set; }
        public int USERID { get; set; }
        public string UserEmail { get; set; }
    }
}

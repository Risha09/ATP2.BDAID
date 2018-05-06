using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class Donation
    {
        
        public int ID { get; set; }
        public DateTime DonateDate { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }
        [Display(Name = "ID")]
        public int PostID { get; set; }
        public int UserID { get; set; }
        public int Mobile { get; set; }
        public int Transaction { get; set; }
        public string Email { get; set; }
    }
}

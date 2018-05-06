using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class Reg_User
    {
        public int ID { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        public int? RefID { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public float Salary { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Gender { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}

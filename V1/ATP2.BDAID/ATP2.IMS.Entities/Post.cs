using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Framework.Constant;

namespace ATP2.BDAID.Entities
{
    public class Post
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Payment { get; set; }
        [Required]
        public string InCharge { get; set; }
        public float Funding { get; set; }
        public int People { get; set; }
        [Required]
        public string Disease { get; set; }
        [Required]
        public string Contact { get; set; }
        public DateTime PostDate { get; set; }
        public int StatusID { get; set; }

        public string Status
        {
            get { return ((EnumCollection.PostStausEnum) this.StatusID).ToString(); }
        }

        public Service Service { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}

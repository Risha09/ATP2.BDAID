using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Messages { get; set; }
        public DateTime MessageDate { get; set; }

        public string Duration
        {
            get
            {
                var days = (int)(DateTime.Now - MessageDate).TotalDays;

                if (days > 0)
                    return days + " days ago";

                var hours = (int)(DateTime.Now - MessageDate).TotalHours;
                if (hours > 0)
                    return hours + " hours ago";

                var mins = (int)(DateTime.Now - MessageDate).TotalMinutes;
                if (mins > 0)
                    return mins + " mins ago";

                return "a few seconds ago";
            }
        }
    }
}

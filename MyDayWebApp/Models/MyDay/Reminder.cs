using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDayWebApp.Models.MyDay
{
    public class Reminder
    {
        public int ID { get; set; }
        [StringLength(450)]
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Content { get; set; }

    }
}

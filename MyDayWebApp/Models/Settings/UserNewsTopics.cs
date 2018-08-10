using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDayWebApp.Models.Settings
{
    public class UserNewsTopics
    {
        public int ID { get; set; }

        [StringLength(450)]
        public string UserID { get; set; }

        public int NewsTopicsID { get; set; }
    }
}

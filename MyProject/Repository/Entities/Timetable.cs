using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Entities
{
   public class Timetable
    {
        public int Id { get; set; }
        public int DriverCode { get; set; }
        [ForeignKey("DriverCode")]
        public Drivers  Drivers { get; set; }
        
        public DateTime Date { get; set; }

        public TimeSpan FromHour { get; set; }
        public TimeSpan UntilHour { get; set; }
        public Cordination Source { get; set; }

        public Cordination Destination { get; set; }
        //מרחק שמוכן לסטות
        public long Km { get; set; }
    }
}

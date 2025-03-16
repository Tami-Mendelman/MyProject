using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Respository.Entities
{
   public class Destination
    {
        public int Id { get; set; }
        public int UserCode { get; set; }
        [ForeignKey("UserCode")]
        public User User { get; set; }
       
        public Cordination Source { get; set; }
        public Cordination Destinations { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}

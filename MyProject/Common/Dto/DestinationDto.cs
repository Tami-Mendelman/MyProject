using Respository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.Dto
{
   public class DestinationDto
    {
        public int Id { get; set; }
        public int UserCode { get; set; }
       
        public Cordination Source { get; set; }
        public Cordination Destinations { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}

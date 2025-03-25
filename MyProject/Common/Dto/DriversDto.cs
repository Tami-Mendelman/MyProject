using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    
   public class DriversDto
    {
        [Key]
        public int DriverCode { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }  
        public string Mail { get; set; }
        //האם נגיש לכסא גלגלים
        public bool Accessible { get; set; }
        //האם תא מטען גדול
        public bool Trunk { get; set; }
        public int NumberOfSeatsInTheCar { get; set; }


        ////תמונת פרופיל
        public byte[] ArrImage { get; set; }
        public IFormFile? fileImage { get; set; }

        //למחוק?????
        //public ICollection<Timetable> timetables { get; set; }

    }
}

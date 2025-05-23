﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Entities
{
   public class Comments
    {
        public int Id { get; set; }

        public int DriverCode { get; set; }

        [ForeignKey("DriverCode")]
        public Drivers Driver { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }



    }
}

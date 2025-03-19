using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Entities
{
     [NotMapped]
    public class Cordination
    {
         public long X { get; set; }
        public long Y { get; set; }
    }
}

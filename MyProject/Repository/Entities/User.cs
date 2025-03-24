using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Entities
{
    public class User
    {
        [Key]
        public int CodeUser { get; set; }
        public string   Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public string? Image { get; set; }
        public ICollection<Destination>? Destination { get; set; }


    }
}

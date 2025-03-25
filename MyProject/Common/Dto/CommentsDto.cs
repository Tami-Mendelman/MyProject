using Respository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
   public class CommentsDto
    {
        public int Id { get; set; }
        public List<DriversDto> DriversList { get; set; }
        public string Description { get; set; }
        
        public int UserId { get; set; }
      
    }
}

using Microsoft.AspNetCore.Http;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
  public  class UserDto
    {
        [Key]
        public int CodeUser { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }

        public byte[]? ArrImage { get; set; }
        public IFormFile? fileImage { get; set; }

    }
}

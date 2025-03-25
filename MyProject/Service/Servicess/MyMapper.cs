using AutoMapper;
using Common.Dto;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servicess
{
   public class MyMapper:Profile
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Images/");
        public MyMapper()
        {
            //string to byte[]
            CreateMap<User, UserDto>().ForMember("ArrImage", x => x.MapFrom(y => File.ReadAllBytes(path + y.Image)));
            CreateMap<UserDto, User>().ForMember("Image", x => x.MapFrom(y => y.ArrImage));
            CreateMap<Drivers, DriversDto>().ForMember("ArrImage", x => x.MapFrom(y => File.ReadAllBytes(path + y.Image)));
            CreateMap<DriversDto, Drivers>().ForMember("Image", x => x.MapFrom(y => y.ArrImage));
            
            
            //צריך את זה?????
           // CreateMap<Comments, CommentsDto>().ReverseMap();
        }
    }
}

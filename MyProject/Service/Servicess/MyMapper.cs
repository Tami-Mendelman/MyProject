
using AutoMapper;
using Common.Dto;
using Respository.Entities;
using System.IO;

namespace Service.Servicess
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.ArrImage, opt => opt.MapFrom(src =>
                    !string.IsNullOrEmpty(src.Image) && File.Exists(Path.Combine(imagePath, src.Image))
                        ? File.ReadAllBytes(Path.Combine(imagePath, src.Image))
                        : null));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Image, opt => opt.Ignore()); // שמירה ידנית ב־UserService

            CreateMap<Drivers, DriversDto>()
                .ForMember(dest => dest.ArrImage, opt => opt.MapFrom(src =>
                    !string.IsNullOrEmpty(src.Image) && File.Exists(Path.Combine(imagePath, src.Image))
                        ? File.ReadAllBytes(Path.Combine(imagePath, src.Image))
                        : null));

            CreateMap<DriversDto, Drivers>()
                .ForMember(dest => dest.Image, opt => opt.Ignore()); // שמירה ידנית
            CreateMap<Comments, CommentsDto>();
            CreateMap<CommentsDto, Comments>();

            CreateMap<Destination, DestinationDto>();
            CreateMap<DestinationDto, Destination>();

            CreateMap<Timetable, TimetableDto>();
            CreateMap<TimetableDto, Timetable>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}

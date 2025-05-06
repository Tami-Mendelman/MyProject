using AutoMapper;
using Common.Dto;
using Repository.Interfaces;
using Respository.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servicess
{
    public class UserService : IService<UserDto>
    {
        private readonly IRepository<User> repository;
        private readonly IMapper mapper;
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

      
        public async Task<UserDto> AddItem(UserDto item)
        {
            var user = mapper.Map<UserDto, User>(item);

            // יצירת תיקיית Images אם לא קיימת
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!Directory.Exists(imagePath))
                Directory.CreateDirectory(imagePath);

            // שמירת התמונה אם קיימת
            if (item.ArrImage != null)
            {
                string fileName = $"user_{Guid.NewGuid()}.jpg";
                string fullPath = Path.Combine(imagePath, fileName);
                File.WriteAllBytes(fullPath, item.ArrImage);

                user.Image = fileName; // שמירה לשם התמונה
            }

            var added =await repository.AddItem(user);
            return  mapper.Map<User, UserDto>(added);
        }


        public async Task DeleteItem(int id)
        {
          await  repository.DeleteItem(id);
        }

        public async Task< List<UserDto>> GetAll()
        {
            return mapper.Map<List<User>, List<UserDto>>(await repository.GetAll());
        }

        public async Task <UserDto> GetById(int id)
        {
            return mapper.Map<User, UserDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(int id, UserDto item)
        {
          await  repository.UpdateItem(id, mapper.Map<UserDto, User>(item));
        }
    }
    
}

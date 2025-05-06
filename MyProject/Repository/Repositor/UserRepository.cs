using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Repositor
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext context;
        public UserRepository(IContext context)
        {
            this.context = context;
        }


        public async Task< User> AddItem(User item)
        {
           await this.context.Users.AddAsync(item);
          await  this.context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            this.context.Users.Remove( await GetById(id));
          await  this.context.Save();
        }

        public async Task< List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task< User> GetById(int CodeUser)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.CodeUser == CodeUser);
        }

        public async Task UpdateItem(int id, User item)
        {
            var user =await GetById(id);
            user.Name = item.Name;
            user.Destination = item.Destination;
            user.Password = item.Password;
            user.Role = item.Role;
            user.Mail = item.Mail;
            user.Image = item.Image;
          await  context.Save();
        }
    }
}

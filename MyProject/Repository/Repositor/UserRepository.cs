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


        public User AddItem(User item)
        {
            this.context.Users.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.Users.Remove(GetById(id));
            this.context.Save();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int CodeUser)
        {
            return context.Users.FirstOrDefault(x => x.CodeUser == CodeUser);
        }

        public void UpdateItem(int id, User item)
        {
            var user = GetById(id);
            user.Name = item.Name;
            user.Destination = item.Destination;
            user.Password = item.Password;
            user.Role = item.Role;
            user.Mail = item.Mail;
            user.Image = item.Image;
            context.Save();
        }
    }
}

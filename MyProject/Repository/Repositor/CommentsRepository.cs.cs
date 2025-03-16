using Repository.Interfaces;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositor
{
   public class CommentsRepository:IRepository<Comments>
    {
        private readonly IContext context;
        public CommentsRepository(IContext context)
        {
            this.context = context;
        }


        public Comments AddItem(Comments item)
        {
            this.context.Comment.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.Comment.Remove(GetById(id));
            this.context.Save();
        }

        public List<Comments> GetAll()
        {
            return context.Comment.ToList();
        }

        public Comments GetById(int id)
        {
            return context.Comment.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(int id, Comments item)
        {
            var comments = GetById(id);
            comments.DriversList = item.DriversList;
            comments.Description = item.Description;
            comments.User = item.User;
            context.Save();
        }
    }
}

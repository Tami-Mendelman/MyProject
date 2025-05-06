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
   public class CommentsRepository:IRepository<Comments>
    {
        private readonly IContext context;
        public CommentsRepository(IContext context)
        {
            this.context = context;
        }


        public async Task<Comments> AddItem(Comments item)
        {
          await  this.context.Comment.AddAsync(item);
            await this.context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            this.context.Comment.Remove(await GetById(id));
           await this.context.Save();
        }

        public async Task< List<Comments>> GetAll()
        {
            return await context.Comment.ToListAsync();
        }

        public async Task< Comments> GetById(int id)
        {
            return await context.Comment.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateItem(int id, Comments item)
        {
            var comments =await GetById(id);
            comments.DriversList = item.DriversList;
            comments.Description = item.Description;
            comments.User = item.User;
          await  context.Save();
        }
    }
}

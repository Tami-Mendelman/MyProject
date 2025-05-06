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
   public class DestinationRepository:IRepository<Destination>
    {
        private readonly IContext context;
        public DestinationRepository(IContext context)
        {
            this.context = context;
        }


        public async Task< Destination> AddItem(Destination item)
        {
          await  this.context.Destinations.AddAsync(item);
          await  this.context.Save();
            return item;
        }


        public async Task DeleteItem(int id)
        {
            this.context.Destinations.Remove( await GetById(id));
          await  this.context.Save();
        }

        public async Task< List<Destination> >GetAll()
        {
            return await context.Destinations.ToListAsync();
        }

        public async Task< Destination> GetById(int id)
        {
            return await context.Destinations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateItem(int id, Destination item)
        {
            var destination =await GetById(id);
            destination.User = item.User;
            destination.Source = item.Source;
            destination.Destinations = item.Destinations;
            destination.Date = item.Date;
            destination.Time = item.Time;
           await context.Save();
        
         }
    }
}

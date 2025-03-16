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


        public Destination AddItem(Destination item)
        {
            this.context.Destinations.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.Destinations.Remove(GetById(id));
            this.context.Save();
        }

        public List<Destination> GetAll()
        {
            return context.Destinations.ToList();
        }

        public Destination GetById(int id)
        {
            return context.Destinations.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(int id, Destination item)
        {
            var destination = GetById(id);
            destination.User = item.User;
            destination.Source = item.Source;
            destination.Destinations = item.Destinations;
            destination.Date = item.Date;
            destination.Time = item.Time;
            context.Save();
        
    }
    }
}

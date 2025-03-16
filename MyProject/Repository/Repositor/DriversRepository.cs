using Repository.Interfaces;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositor
{
  public  class DriversRepository:IRepository<Drivers>
    {
        private readonly IContext context;
        public DriversRepository(IContext context)
        {
            this.context = context;
        }


        public Drivers AddItem(Drivers item)
        {
            this.context.Driver.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.Driver.Remove(GetById(id));
            this.context.Save();
        }

        public List<Drivers> GetAll()
        {
            return context.Driver.ToList();
        }

        public Drivers GetById(int id)
        {
            return context.Driver.FirstOrDefault(x => x.DriverCode == id);
        }

        public void UpdateItem(int id, Drivers item)
        {
            var drivers = GetById(id);
            drivers.Name = item.Name;
            drivers.Password = item.Password;
            drivers.Mail = item.Mail;
            drivers.Accessible = item.Accessible;
            drivers.Trunk = item.Trunk;
            drivers.NumberOfSeatsInTheCar = item.NumberOfSeatsInTheCar;
            drivers.Image = item.Image;
            drivers.timetables = item.timetables;
        context.Save();

        }
    }
}

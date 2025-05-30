﻿using Microsoft.EntityFrameworkCore;
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


        public async Task< Drivers> AddItem(Drivers item)
        {
            await this.context.Driver.AddAsync(item);
           await  this.context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            this.context.Driver.Remove( await GetById(id));
          await  this.context.Save();
        }

        public async Task< List<Drivers>> GetAll()
        {
            return await context.Driver.ToListAsync();
        }

        public async Task< Drivers> GetById(int id)
        {
            return await context.Driver.FirstOrDefaultAsync(x => x.DriverCode == id);
        }

        public async Task UpdateItem(int id, Drivers item)
        {
            var drivers = await GetById(id);
            drivers.Name = item.Name;
            drivers.Password = item.Password;
            drivers.Mail = item.Mail;
            drivers.Accessible = item.Accessible;
            drivers.Trunk = item.Trunk;
            drivers.NumberOfSeatsInTheCar = item.NumberOfSeatsInTheCar;
            drivers.Image = item.Image;
            drivers.timetables = item.timetables;
            await context.Save();

        }
    }
}

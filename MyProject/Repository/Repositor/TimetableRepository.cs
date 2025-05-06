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
   public class TimetableRepository:IRepository<Timetable>
    {
        private readonly IContext context;
        public TimetableRepository(IContext context)
        {
            this.context = context;
        }


        public async Task< Timetable> AddItem(Timetable item)
        {
           await this.context.Timetables.AddAsync(item);
          await  this.context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            this.context.Timetables.Remove( await GetById(id));
           await this.context.Save();
        }

        public async Task< List<Timetable>> GetAll()
        {
            return await context.Timetables.ToListAsync();
        }

        public async Task< Timetable> GetById(int id)
        {
            return await context.Timetables.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateItem(int id, Timetable item)
        {
            var timetable =await GetById(id);
            timetable.Drivers = item.Drivers;
            timetable.Date = item.Date;
            timetable.FromHour = item.FromHour;
            timetable.UntilHour = item.UntilHour;
            timetable.Source = item.Source;
            timetable.Destination = item.Destination;
            timetable.Km = item.Km;
           await context.Save();
        }
    }
}

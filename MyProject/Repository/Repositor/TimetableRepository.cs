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


        public Timetable AddItem(Timetable item)
        {
            this.context.Timetables.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.Timetables.Remove(GetById(id));
            this.context.Save();
        }

        public List<Timetable> GetAll()
        {
            return context.Timetables.ToList();
        }

        public Timetable GetById(int id)
        {
            return context.Timetables.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(int id, Timetable item)
        {
            var timetable = GetById(id);
            timetable.Drivers = item.Drivers;
            timetable.Date = item.Date;
            timetable.FromHour = item.FromHour;
            timetable.UntilHour = item.UntilHour;
            timetable.Source = item.Source;
            timetable.Destination = item.Destination;
            timetable.Km = item.Km;
            context.Save();
        }
    }
}

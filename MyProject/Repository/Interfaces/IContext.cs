using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    //ממשק שמתאר את הנתונים
    public interface IContext
    {
      public DbSet<Comments> Comment { get; set; }
       public DbSet<Destination> Destinations { get; set; }
        public DbSet<Drivers> Driver { get; set; }

        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<User> Users { get; set; }
        public void Save();
    }
}

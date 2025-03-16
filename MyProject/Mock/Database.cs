using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mock
{
    public class Database:DbContext ,IContext
    {
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Drivers> Driver { get; set; }

        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<User> Users { get; set; }

        public void Save()
        {
           SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //??? איך קוראים לDATABASE שאני רוצה הלתחבר אליהם
            optionsBuilder.UseSqlServer("server=sql;database=projectShopDb;trusted_connection=true;TrustServerCertificate=True");
        }
    }
}

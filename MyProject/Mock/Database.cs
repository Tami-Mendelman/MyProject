﻿using Microsoft.EntityFrameworkCore;
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

        public async Task Save()
        {          
             await   SaveChangesAsync();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("server=DESKTOP-FVA15IL;database=ProjectTandT;trusted_connection=true;TrustServerCertificate=True");
        }
    }
}

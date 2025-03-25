using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Respository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositor
{
   public static class ExtentionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddScoped<IRepository<Drivers>, DriversRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Comments>, CommentsRepository>();
            services.AddScoped<IRepository<Destination>, DestinationRepository>();
            services.AddScoped<IRepository<Timetable>, TimetableRepository>();
            return services;
        }
    }
}

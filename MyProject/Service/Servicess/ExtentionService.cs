﻿using  Common.Dto;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositor;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servicess
{
   public static class ExtentionService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddRepository();
            services.AddScoped<IService<DriversDto>, DriverService>();
            services.AddScoped<IService<UserDto>, UserService>();
            services.AddScoped<IService<CommentsDto>, CommentsService>();
            services.AddScoped<IService<DestinationDto>, DestinationService>();
            services.AddScoped<IService<TimetableDto>, TimetableService>();
           
            services.AddAutoMapper(typeof(MyMapper));
            return services;
        }
    }
}

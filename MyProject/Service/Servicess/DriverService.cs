using AutoMapper;
using Common.Dto;
using Repository.Interfaces;
using Respository.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servicess
{
    public class DriverService : IService<DriversDto>
    {
        private readonly IRepository<Drivers> repository;
        private readonly IMapper mapper;
        public DriverService(IRepository<Drivers> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        DriversDto IService<DriversDto>.AddItem(DriversDto item)
        {
            return mapper.Map<Drivers, DriversDto>(repository.AddItem(mapper.Map<DriversDto, Drivers>(item)));
        }

        void IService<DriversDto>.DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        List<DriversDto> IService<DriversDto>.GetAll()
        {
            return mapper.Map<List<Drivers>, List<DriversDto>>(repository.GetAll());
        }

        DriversDto IService<DriversDto>.GetById(int id)
        {
            return mapper.Map<Drivers, DriversDto>(repository.GetById(id));
        }

        void IService<DriversDto>.UpdateItem(int id, DriversDto item)
        {
            repository.UpdateItem(id, mapper.Map<DriversDto, Drivers>(item));
        }
    }
}

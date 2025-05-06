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

        public async Task<DriversDto> AddItem(DriversDto item)
        {
            return mapper.Map<Drivers, DriversDto>(await repository.AddItem(mapper.Map<DriversDto, Drivers>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<DriversDto>> GetAll()
        {
            return mapper.Map<List<Drivers>, List<DriversDto>>(await repository.GetAll());
        }


        public async Task<DriversDto> GetById(int id)
        {
            return mapper.Map<Drivers, DriversDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(int id, DriversDto item)
        {
            await repository.UpdateItem(id, mapper.Map<DriversDto, Drivers>(item));
        }

        
    }
}

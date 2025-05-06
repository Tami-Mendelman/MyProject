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
    public class DestinationService : IService<DestinationDto>
    {
        private readonly IRepository<Destination> repository;
        private readonly IMapper mapper;
        public DestinationService(IRepository<Destination> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task< DestinationDto> AddItem(DestinationDto item)
        {
            return mapper.Map<Destination, DestinationDto>(await repository.AddItem(mapper.Map<DestinationDto, Destination>(item)));
        }

        public async Task DeleteItem(int id)
        {
          await  repository.DeleteItem(id);
        }

        public async Task< List<DestinationDto>> GetAll()
        {
            return mapper.Map<List<Destination>, List<DestinationDto>>(await repository.GetAll());
        }

        public async Task< DestinationDto> GetById(int id)
        {
            return mapper.Map<Destination, DestinationDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(int id, DestinationDto item)
        {
           await repository.UpdateItem(id, mapper.Map<DestinationDto, Destination>(item));
        }
    }
}

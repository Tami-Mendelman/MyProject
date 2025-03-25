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
        public DestinationDto AddItem(DestinationDto item)
        {
            return mapper.Map<Destination, DestinationDto>(repository.AddItem(mapper.Map<DestinationDto, Destination>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<DestinationDto> GetAll()
        {
            return mapper.Map<List<Destination>, List<DestinationDto>>(repository.GetAll());
        }

        public DestinationDto GetById(int id)
        {
            return mapper.Map<Destination, DestinationDto>(repository.GetById(id));
        }

        public void UpdateItem(int id, DestinationDto item)
        {
            repository.UpdateItem(id, mapper.Map<DestinationDto, Destination>(item));
        }
    }
}

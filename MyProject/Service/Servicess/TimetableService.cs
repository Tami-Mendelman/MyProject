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
    public class TimetableService : IService<TimetableDto>
    {
        private readonly IRepository<Timetable> repository;
        private readonly IMapper mapper;
        public TimetableService(IRepository<Timetable> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task< TimetableDto> AddItem(TimetableDto item)
        {
            return mapper.Map<Timetable, TimetableDto>(await repository.AddItem(mapper.Map<TimetableDto, Timetable>(item)));
        }

        public async Task DeleteItem(int id)
        {
           await repository.DeleteItem(id);
        }

        public async Task< List<TimetableDto>> GetAll()
        {
            return mapper.Map<List<Timetable>, List<TimetableDto>>(await repository.GetAll());
        }

        public async Task< TimetableDto> GetById(int id)
        {
            return mapper.Map<Timetable, TimetableDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(int id, TimetableDto item)
        {
          await  repository.UpdateItem(id, mapper.Map<TimetableDto, Timetable>(item));
        }
    }
}

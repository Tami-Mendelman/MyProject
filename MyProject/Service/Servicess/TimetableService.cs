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

        public TimetableDto AddItem(TimetableDto item)
        {
            return mapper.Map<Timetable, TimetableDto>(repository.AddItem(mapper.Map<TimetableDto, Timetable>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<TimetableDto> GetAll()
        {
            return mapper.Map<List<Timetable>, List<TimetableDto>>(repository.GetAll());
        }

        public TimetableDto GetById(int id)
        {
            return mapper.Map<Timetable, TimetableDto>(repository.GetById(id));
        }

        public void UpdateItem(int id, TimetableDto item)
        {
            repository.UpdateItem(id, mapper.Map<TimetableDto, Timetable>(item));
        }
    }
}

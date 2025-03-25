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
    public class CommentsService : IService<CommentsDto>
    {
        private readonly IRepository<Comments> repository;
        private readonly IMapper mapper;
        public CommentsService(IRepository<Comments> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public CommentsDto AddItem(CommentsDto item)
        {
            return mapper.Map<Comments, CommentsDto>(repository.AddItem(mapper.Map<CommentsDto, Comments>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<CommentsDto> GetAll()
        {
            return mapper.Map<List<Comments>, List<CommentsDto>>(repository.GetAll());
        }

        public CommentsDto GetById(int id)
        {
            return mapper.Map<Comments, CommentsDto>(repository.GetById(id));
        }

        public void UpdateItem(int id, CommentsDto item)
        {
            repository.UpdateItem(id, mapper.Map<CommentsDto, Comments>(item));
        }
    }
}

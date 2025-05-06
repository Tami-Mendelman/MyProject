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
        public async Task<CommentsDto> AddItem(CommentsDto item)
        {
            return mapper.Map<Comments, CommentsDto>(await repository.AddItem(mapper.Map<CommentsDto, Comments>(item)));
        }

        public async Task DeleteItem(int id)
        {
           await repository.DeleteItem(id);
        }

        public async Task< List<CommentsDto>> GetAll()
        {
            return mapper.Map<List<Comments>, List<CommentsDto>>(await repository.GetAll());
        }

        public async Task< CommentsDto> GetById(int id)
        {
            return mapper.Map<Comments, CommentsDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(int id, CommentsDto item)
        {
          await  repository.UpdateItem(id, mapper.Map<CommentsDto, Comments>(item));
        }
    }
}

using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IService<CommentsDto> service;
        public CommentsController(IService<CommentsDto> service)
        {
            this.service = service;
        }
        // GET: api/<CommentsController>   
        [HttpGet]
        public IEnumerable<CommentsDto> Get()
        {
            return service.GetAll();
        }


        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public CommentsDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Authorize]
        public CommentsDto Post([FromForm] CommentsDto value)
        {
            return service.AddItem(value);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] CommentsDto dto)
        {
            service.UpdateItem(id, dto);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }


     
        
    }
}

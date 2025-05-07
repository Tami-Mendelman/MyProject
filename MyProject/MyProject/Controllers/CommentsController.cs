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
        public async Task<List<CommentsDto>> Get()
        {
            return await service.GetAll();
        }


        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task< CommentsDto> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<CommentsController>
        //[HttpPost]
        //[Authorize]
        //public async Task< CommentsDto> Post([FromBody] CommentsDto value)
        //{
        //    return await service.AddItem(value);
        //}
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CommentsDto value)
        {
            try
            {
                var result = await service.AddItem(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message ?? "No inner exception";
                return StatusCode(500, $"Server error: {ex.Message} → {inner}");
            }

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

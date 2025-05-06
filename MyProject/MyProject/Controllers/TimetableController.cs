using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly IService<TimetableDto> service;
        public TimetableController(IService<TimetableDto> service)
        {
            this.service = service;
        }
        // GET: api/<TimetableController>
        [HttpGet]
        public async Task<IEnumerable<TimetableDto>> Get()
        {
            return await service.GetAll();
        }


        // GET api/<TimetableController>/5
        [HttpGet("{id}")]
        public async Task< TimetableDto> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<TimetableController>
        [HttpPost]
        [Authorize]
        public  async Task<TimetableDto> Post([FromForm] TimetableDto value)
        {
            return await service.AddItem(value);
        }

        // PUT api/<TimetableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] TimetableDto dto)
        {
            service.UpdateItem(id, dto);
        }

        // DELETE api/<TimetableController>/5
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = service.GetById(id);
            if (entity == null)
                return NotFound();

            service.DeleteItem(id);
            return Ok();
        }





    }
}

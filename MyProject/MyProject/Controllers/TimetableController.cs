using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TimetableController>/5
        [HttpGet("{id}")]
        public TimetableDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<TimetableController>
        [HttpPost]
        public TimetableDto Post([FromBody] TimetableDto value)
        {
            return service.AddItem(value);
        }

        // PUT api/<TimetableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<TimetableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

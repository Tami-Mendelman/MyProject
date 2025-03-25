using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Respository.Entities;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IService<DestinationDto> service;
        public DestinationController(IService<DestinationDto> service)
        {
            this.service = service;
        }
        // GET: api/<DestinationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DestinationController>/5
        [HttpGet("{id}")]
        public DestinationDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<DestinationController>
        [HttpPost]
        public DestinationDto Post([FromBody] DestinationDto value)
        {
            return service.AddItem(value);
        }

        // PUT api/<DestinationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<DestinationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

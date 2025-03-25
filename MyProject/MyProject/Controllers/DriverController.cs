using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IService<DriversDto> service;
        public DriverController(IService<DriversDto> service)
        {
            this.service = service;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public DriversDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<DriverController>
        [HttpPost]
        public DriversDto Post([FromBody] DriversDto drivers)
        {
            UploadImage(drivers.fileImage);
            return service.AddItem(drivers);
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private void UploadImage(IFormFile file)
        {
            //ניתוב לתמונה
            var path = Path.Combine(Environment.CurrentDirectory, "Images/", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {

                file.CopyTo(stream);
            }
        }
    }
}

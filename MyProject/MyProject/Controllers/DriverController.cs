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
       
        public async Task<List<DriversDto>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public async Task< DriversDto> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<DriverController>
        //[HttpPost]
        //public async Task< DriversDto> Post([FromForm] DriversDto drivers)
        //{
        //    UploadImage(drivers.fileImage);
        //    return await service.AddItem(drivers);
        //}
        [HttpPost]
        public async Task<DriversDto> Post([FromForm] DriversDto drivers)
        {
            UploadImage(drivers.fileImage, drivers); // ✅
            return await service.AddItem(drivers);
        }


        // PUT api/<DriverController>/5

        [HttpPut("{id}")]
        public void Put(int id, [FromForm] DriversDto dto)
        {
            service.UpdateItem(id, dto);
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }


        //private void UploadImage(IFormFile file)
        //{
        //    //ניתוב לתמונה
        //    var path = Path.Combine(Environment.CurrentDirectory, "Images/", file.FileName);
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {

        //        file.CopyTo(stream);
        //    }
        //}
        private void UploadImage(IFormFile file, DriversDto driver)
        {
            if (file == null) return;

            var path = Path.Combine(Environment.CurrentDirectory, "Images/", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            using (var readStream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                readStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                memoryStream.CopyTo(stream);

                driver.ArrImage = memoryStream.ToArray(); // ✅ תמונה כ־byte[] ל־React
            }
        }


    }
}

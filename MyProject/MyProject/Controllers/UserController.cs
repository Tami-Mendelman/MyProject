using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Respository.Entities;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<UserDto> service;
        public UserController(IService<UserDto> service)
        {
            this.service = service;
        }

        // GET: api/<UserController>
       
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return service.GetAll();
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public UserDto Post([FromForm] UserDto user)
        {
            UploadImage(user.fileImage);

            return service.AddItem(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<UserController>/5
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

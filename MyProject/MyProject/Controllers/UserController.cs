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
        public async Task< IEnumerable<UserDto>> Get()
        {
            return await service.GetAll();
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task< UserDto> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<UserController>

        //[HttpPost]
        //public async Task<ActionResult<UserDto>> Post([FromForm] UserDto user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values
        //            .SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage)
        //            .ToList();

        //        // מחזיר תשובה עם כל השגיאות שקרו בבקשה
        //        return BadRequest(new { message = "Model validation failed", errors });
        //    }

        //    UploadImage(user.fileImage);

        //    var result = await service.AddItem(user);
        //    return Ok(result);
        //}
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromForm] UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UploadImage(user.fileImage, user); // ✅

            var result = await service.AddItem(user);
            return Ok(result);
        }



        // PUT api/<UserController>/5

        [HttpPut("{id}")]
        public void Put(int id, [FromForm] UserDto dto)
        {
            service.UpdateItem(id, dto);
        }

        // DELETE api/<UserController>/5
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
        private void UploadImage(IFormFile file, UserDto user)
        {
            if (file == null) return;

            var path = Path.Combine(Environment.CurrentDirectory, "Images/", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            using (var readStream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                // העתקה כפולה לשני יעדים: לקובץ וגם ל־ArrImage
                readStream.CopyTo(memoryStream); // שומר ל־MemoryStream
                memoryStream.Position = 0;       // מחזיר להתחלה
                memoryStream.CopyTo(stream);     // שומר לקובץ

                user.ArrImage = memoryStream.ToArray(); // שומר ל־DTO
            }
        }


    }
}

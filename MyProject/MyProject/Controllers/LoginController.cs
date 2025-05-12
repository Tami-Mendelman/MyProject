
//using Common.Dto;
//using Microsoft.AspNetCore.Mvc;
//using Service.Interfaces;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.AspNetCore.Authorization;

//namespace MyProject.Controllers
//{
//    [Route("api/[controller]")]
//    //[Authorize]
//    [ApiController]

//    public class LoginController : ControllerBase
//    {
//        private readonly IService<UserDto> service;
//        private readonly IConfiguration config;

//        public LoginController(IService<UserDto> service, IConfiguration config)
//        {
//            this.service = service;
//            this.config = config;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<UserDto>> Get()
//        {
//            return await service.GetAll();
//        }

//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post([FromForm] UserDto value)
//        {
//            var result = await service.AddItem(value);
//            return Ok(result);
//        }

//        //[HttpPost("login")]
//        //public async Task<IActionResult> Login([FromForm] UserLogin value)
//        //{
//        //    var user = await Authenticate(value); // ✅ חייב להיות await כאן
//        //    if (user != null)
//        //    {
//        //        var token = Generate(user);
//        //        return Ok(token);
//        //    }

//        //    return Unauthorized("User not found");
//        //}
//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromForm] UserLogin value)
//        {
//            var user = await Authenticate(value);
//            if (user != null)
//            {
//                var token = Generate(user);

//                return Ok(new
//                {
//                    token = token,
//                    userId = user.CodeUser,
//                    role = user.Role // זה מאפשר לצד לקוח לנווט בהתאם
//                });

//            }
//            return Unauthorized("User not found");
//        }


//        private string Generate(UserDto user)
//        {
//            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
//            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Name),
//                new Claim(ClaimTypes.Email, user.Mail),
//                new Claim("Password", user.Password),
//                new Claim(ClaimTypes.Role, user.Role),
//            };

//            var token = new JwtSecurityToken(
//                config["Jwt:Issuer"],
//                config["Jwt:Audience"],
//                claims,
//                expires: DateTime.Now.AddMinutes(15),
//                signingCredentials: credentials);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        private async Task<UserDto> Authenticate(UserLogin value)
//        {
//            var users = await service.GetAll();
//            return users.FirstOrDefault(x => x.Password == value.Password && x.Name == value.Name);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put(int id, [FromForm] UserDto dto)
//        {
//            await service.UpdateItem(id, dto);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await service.DeleteItem(id);
//            return NoContent();
//        }
//    }
//}
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService<UserDto> _userService;
        private readonly IService<DriversDto> _driverService;
        private readonly IConfiguration _config;

        public LoginController(IService<UserDto> userService, IService<DriversDto> driverService, IConfiguration config)
        {
            _userService = userService;
            _driverService = driverService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserLogin value)
        {
            var user = await AuthenticateUser(value);
            if (user != null)
            {
                var token = Generate(user.Name, user.Mail, user.Password, "User");
                return Ok(new { token = token, userId = user.CodeUser, role = "User" });
            }

            var driver = await AuthenticateDriver(value);
            if (driver != null)
            {
                var token = Generate(driver.Name, driver.Mail, driver.Password, "Driver");
                return Ok(new { token = token, userId = driver.DriverCode, role = "Driver" });
            }

            return Unauthorized("User not found");
        }

        private async Task<UserDto?> AuthenticateUser(UserLogin value)
        {
            var users = await _userService.GetAll();
            return users.FirstOrDefault(x => x.Name == value.Name && x.Password == value.Password);
        }

        private async Task<DriversDto?> AuthenticateDriver(UserLogin value)
        {
            var drivers = await _driverService.GetAll();
            return drivers.FirstOrDefault(x => x.Name == value.Name && x.Password == value.Password);
        }

        private string Generate(string name, string mail, string password, string role)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, name),
                new Claim(ClaimTypes.Email, mail),
                new Claim("Password", password),
                new Claim(ClaimTypes.Role, role),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<UserDto?> Get(int id)
        {
            var users = await _userService.GetAll();
            return users.FirstOrDefault(u => u.CodeUser == id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserDto value)
        {
            var result = await _userService.AddItem(value);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] UserDto dto)
        {
            await _userService.UpdateItem(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteItem(id);
            return NoContent();
        }

    }
}

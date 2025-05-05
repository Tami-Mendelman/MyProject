﻿using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService<UserDto> service;
        private readonly IConfiguration config;
        public LoginController(IService<UserDto> service, IConfiguration config)
        {
            this.service = service;
            this.config = config;
        }
        // GET: api/<LoginController>
       
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return service.GetAll();
        }


        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromForm] UserDto value)
        {
            service.AddItem(value);
        }
        [HttpPost("login")]
        public string Login([FromForm] UserLogin value)
        {
            var user = Authenticate(value);
            if (user != null)
            {
                var token = Generate(user);
                return token;
            }
            return "user not found";
        }
        private string Generate(UserDto user)
        {

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,user.Name),
            new Claim(ClaimTypes.Email,user.Mail),
            new Claim(ClaimTypes.PostalCode,user.Password),
            new Claim(ClaimTypes.Role,user.Role),
            //new Claim(ClaimTypes.GivenName,user.Name)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserDto Authenticate(UserLogin value)
        {
            UserDto user = service.GetAll().FirstOrDefault(x => x.Password == value.Password && x.Name == value.Name);
            if (user != null)
                return user;
            return null;
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] UserDto dto)
        {
           
            service.UpdateItem(id,dto);
        }
        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }


       
       
    }
}

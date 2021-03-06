using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhyndDemo_v2.Managers;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PhyndDemo_v2.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : Controller
    {

        private IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public LoginController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login(string email, string pass)
        {
            Login login = new Login();
            login.Email = email;
            login.Password = pass;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenStr = GenrateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        private Login AuthenticateUser(Login login)
        {
            Login user = null;
            User checkuser = _userRepository.LoginUser(login.Email, login.Password);
            if (checkuser != null)
            {
                user = new Login { Password = checkuser.Password, Email = checkuser.Email };
            }
            return user;
        }

        private string GenrateJSONWebToken(Login userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

    }
}

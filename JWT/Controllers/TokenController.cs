using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            //Initiates the response with 401 status
            IActionResult response = Unauthorized();
            //Tries to authenticate the user
            var user = Authenticate(login);

            //If authenticated returns the token along with a 200 response
            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(UserModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("custom_claim", "007"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireLimit = 1;
            Int32.TryParse(_config["Jwt:expire_limit"], out expireLimit);

            var token = new JwtSecurityToken(Environment.GetEnvironmentVariable("JWT_ISSUER"),
            Environment.GetEnvironmentVariable("JWT_ISSUER"),
            claims,
            expires: DateTime.Now.AddMinutes(expireLimit),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login != null && login.Username == Environment.GetEnvironmentVariable("JWT_USR") &&
                login.Password == Environment.GetEnvironmentVariable("JWT_PWD"))
            {
                user = new UserModel("Hackerman", "jhon.doe@levismad.com");
            }
            return user;
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class UserModel
        {
            public UserModel(string name, string email)
            {
                Name = name;
                Email = email;
            }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
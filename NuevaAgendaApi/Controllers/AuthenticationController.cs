using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuevaAgendaApi.Data.Repository.Implementations;
using NuevaAgendaApi.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NuevaAgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthenticationController(UserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        [HttpPost("Authenticate")]

        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = _userRepository.ValidateUser(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            if (user != null)
            {
                // devolver token
            }
            //else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<string> Auth(AuthDTO authDto)
        {
            // Verificamos credenciales
            var user = _userRepository.ValidateUser(authDto.UserName, authDto.Password);

            if (user is null)
            {
                return Forbid(); //si nos devuelve nulo significa que el usuario no existe o la pass está mal
            }

            // Generamos un token según los claims
            var claims = new List<Claim>
    {
        new Claim("id", user.Id.ToString()),
        new Claim("username", user.UserName),
        new Claim("fullname", $"{user.Name} {user.LastName}"),
        new Claim("role", user.Rol.ToString())
    };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new
            {
                AccessToken = jwt
            });
        }
    }
}

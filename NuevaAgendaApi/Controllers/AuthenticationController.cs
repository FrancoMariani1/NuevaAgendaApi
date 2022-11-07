using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuevaAgendaApi.Data.Repository;
using NuevaAgendaApi.Dto;

namespace NuevaAgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public AuthenticationController(UserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}

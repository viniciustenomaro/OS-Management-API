using API.Data.VO;
using API.Model;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Login))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [Route("register")]
        public IActionResult Registrar([FromBody]Login login)
        {
            var result = _loginService.Register(login);

            if(result == null)
            {
                return Conflict();
            }

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult Logar([FromBody]Login login)
        {
            var result = _loginService.VerifyLogin(login);

            if(result == null)
            {
                return Conflict();
            }

            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.User;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUserService _userService;

        public AuthController(IAuthService service, IUserService userService)
        {
            _userService = userService;
            _service = service;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserLoginDto request)
        {
            try
            {
                var allowed = _service.VerifyCredentials(request);
                if (!allowed)
                    return BadRequest();
                var user = _service.GetUserFromUsername(request.Username);
                var token = _service.GetToken(user!);
                return Ok(token);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserReadDto> Register(UserRegisterDto request)
        {
            try
            {
                if (request == null)
                    return BadRequest();
                var username = User.Identity!.Name;
                if (string.IsNullOrEmpty(username))
                    return BadRequest();
                var response = _service.Register(request, by: username);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("me")]
        [Authorize]
        public ActionResult GetAuthorizedUser([FromQuery] string token)
        {
            var username = User.Identity?.Name;
            var user = _service.GetUserFromUsername(username!);
            var id = user?.Id;
            var role = user?.Role;
            var firstName = user?.FirstName;
            var lastName = user?.LastName;
            return Ok(new { id, firstName, lastName, username, role, token });
        }
    }
}

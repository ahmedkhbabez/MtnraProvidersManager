using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.User;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IChangesHandler _changesHandler;

        public UsersController(
            IUserService service,
            IChangesHandler changesHandler)
        {
            _service = service;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var users = _service.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserReadDto> Get(string id)
        {
            var user = _service.GetReadUserById(new(id));
            return user == null ? (ActionResult<UserReadDto>)NotFound() : (ActionResult<UserReadDto>)Ok(user);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            var user = _service.GetUserById(id);
            if (user == null)
                return NotFound();
            _service.Delete(user);
            _changesHandler.Save();
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public ActionResult<UserReadDto> Update(Guid id, [FromBody] UserUpdateDto request)
        {
            try
            {
                var user = _service.GetUserById(id);
                if (user == null)
                    return NotFound();
                if (user.Username != User.Identity!.Name)
                    return Forbid();
                if (!string.IsNullOrEmpty(request.Username))
                {
                    var exists = _service.Exists(request.Username, id);
                    if (exists)
                        return BadRequest();
                    user.Username = request.Username;
                }

                if (!string.IsNullOrEmpty(request.FirstName))
                    user.FirstName = request.FirstName;
                if (!string.IsNullOrEmpty(request.LastName))
                    user.LastName = request.LastName;
                user.UpdatedOn = DateTime.Now;
                var updatedUser = _service.Update(user);
                return Ok(updatedUser);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id:guid}/password")]
        [Authorize]
        public ActionResult<UserReadDto> ChangePassword(Guid id, [FromBody] UserChangePasswordDto request)
        {
            try
            {
                var user = _service.GetUserById(id);
                if (user == null)
                    return NotFound();
                if (user.Username != User.Identity!.Name)
                    return Forbid();
                if (request.NewPassword.Length < 6)
                    return BadRequest();
                var updatedUser = _service.UpdatePassword(user, request.NewPassword);
                return Ok(updatedUser);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id:guid}/promote")]
        [Authorize(Roles = "Admin")]
        public IActionResult Promote(Guid id)
        {
            try
            {
                var user = _service.GetUserById(id);
                if (user == null)
                    return NotFound();
                _service.Promote(user);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

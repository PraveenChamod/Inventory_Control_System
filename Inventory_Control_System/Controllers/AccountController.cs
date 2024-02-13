using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AccountController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetUserDto>> RegisterUser([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var result = await _userService.RegisterUser(createEmployeeDto);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login(LoginUserDto loginUserDto)
        {
            var validUser = await _authService.ValidateUser(loginUserDto);
            if (!validUser) return Unauthorized();
            return Ok(new { Token = await _authService.GenerateToken() });
        }
    }
}

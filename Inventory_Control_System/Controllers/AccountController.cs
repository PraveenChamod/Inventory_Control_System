using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.DTOs.User;
using Microsoft.AspNetCore.Http;
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
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

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
    }
}

using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(GetEmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public Task<ActionResult<List<GetEmployeeDto>>> GetEmployeeList()
        {
            try
            {
                var List = _employeeService.GetEmployeeList();
                return Task.FromResult<ActionResult<List<GetEmployeeDto>>>(Ok(List));
            }
            catch (ValidationException ex)
            {
                return Task.FromResult<ActionResult<List<GetEmployeeDto>>>(BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 }));
            }
        }
    }
}

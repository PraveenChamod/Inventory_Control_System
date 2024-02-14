using Bussiness_Logic_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
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
    }
}

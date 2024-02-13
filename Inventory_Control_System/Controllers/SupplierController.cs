using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(GetSupplierDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetSupplierDto>> CreateSupplier([FromBody] CreateSupplierDto createSupplierDto)
        {
            try
            {
                var result = await _supplierService.CreateSupplier(createSupplierDto);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }
    }
}

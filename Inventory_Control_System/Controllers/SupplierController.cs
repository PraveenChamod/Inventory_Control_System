using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Operator)]
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
        [Route("Create/{employeeId}")]
        [ProducesResponseType(typeof(GetSupplierDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetSupplierDto>> CreateSupplier(Guid? employeeId, [FromBody] CreateSupplierDto createSupplierDto)
        {
            try
            {
                var result = await _supplierService.CreateSupplier(createSupplierDto, (Guid)employeeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [HttpPut]
        [Route("Update/{supplierId}/{employeeId}")]
        [ProducesResponseType(typeof(GetSupplierDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetSupplierDto>> UpdateSupplier(Guid? supplierId, Guid? employeeId, [FromBody] UpdateSupplierDto updateSupplierDto)
        {
            try
            {
                var result = await _supplierService.UpdateSupplier((Guid)supplierId!, updateSupplierDto, (Guid)employeeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [HttpPost]
        [Route("Remove/{supplierId}/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteSupplier(Guid? supplierId, Guid? employeeId)
        {
            try
            {
                await _supplierService.SoftDeleteSupplier((Guid)supplierId!, (Guid)employeeId!);
                return Ok("Supplier removed");
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

    }
}

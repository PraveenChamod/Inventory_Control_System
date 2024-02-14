using Bussiness_Logic_Layer.Interfaces;
using Bussiness_Logic_Layer.Services;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Inventory;
using Data_Access_Layer.DTOs.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Manager + "," + Roles.Operator)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(GetInventoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public Task<ActionResult<List<GetInventoryDto>>> GetInventoryList()
        {
            try
            {
                var List = _inventoryService.GetInventoryList();
                return Task.FromResult<ActionResult<List<GetInventoryDto>>>(Ok(List));
            }
            catch (ValidationException ex)
            {
                return Task.FromResult<ActionResult<List<GetInventoryDto>>>(BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 }));
            }
        }

        [HttpPost]
        [Route("Create/{productId}/{employeeId}/{storeId}")]
        [ProducesResponseType(typeof(GetInventoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetInventoryDto>> CreateInventory(Guid? employeeId, Guid? storeId, Guid? productId)
        {
            try
            {
                var result = await _inventoryService.CreateInventory((Guid)employeeId!, (Guid)storeId!, (Guid)productId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }


        [HttpPut]
        [Route("Update/{productId}/{employeeId}/{storeId}")]
        [ProducesResponseType(typeof(GetSupplierDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetInventoryDto>> UpdateInventory(Guid? productId, Guid? employeeId, Guid? storeId, [FromBody] UpdateInventoryDto updateInventoryDto)
        {
            try
            {
                var result = await _inventoryService.UpdateInventory((Guid)productId!, updateInventoryDto, (Guid)employeeId!, (Guid)storeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }
    }
}

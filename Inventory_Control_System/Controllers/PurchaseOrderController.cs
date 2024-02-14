using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.PurchaseOrder;
using Data_Access_Layer.DTOs.SaleOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Manager + "," + Roles.Operator)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost]
        [Route("Create/{employeeId}/{supplierId}")]
        [ProducesResponseType(typeof(GetPurchaseOrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetPurchaseOrderDto>> CreatePurchaseOrder(Guid? employeeId, Guid? supplierId, [FromBody] List<CreatePurchaseOrderDto> purchaseOrderItems)
        {
            try
            {
                var result = await _purchaseOrderService.CreatePurchaseOrder((Guid)employeeId!, (Guid)supplierId!, purchaseOrderItems);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

    }
}

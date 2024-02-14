using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Product;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Manager)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        public ProductController(IProductService productService, UserManager<User> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create/{employeeId}")]
        [ProducesResponseType(typeof(GetProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetProductDto>> CreateProduct(Guid? employeeId, [FromBody] CreateProductDto createProductDto)
        {
            try
            {
                var result = await _productService.CreateProduct(createProductDto, (Guid)employeeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [HttpPut]
        [Route("Update/{productId}/{employeeId}")]
        [ProducesResponseType(typeof(GetProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetProductDto>> UpdateProduct(Guid? productId, Guid? employeeId, [FromBody] UpdateProductDto updateProductDto)
        {
            try
            {
                var result = await _productService.UpdateProduct((Guid)productId!, updateProductDto, (Guid)employeeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [HttpPost]
        [Route("Remove/{productId}/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteProduct(Guid? productId, Guid? employeeId)
        {
            try
            {
                await _productService.SoftDeleteProduct((Guid)productId!, (Guid)employeeId!);
                return Ok("Product removed");
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }
    }
}

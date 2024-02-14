using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.DTOs.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("Create/{employeeId}")]
        [ProducesResponseType(typeof(GetCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCategoryDto>> CreateCategory(Guid? employeeId, [FromBody] CreateCategoryDto createCategoryDto)
        {
            try
            {
                var result = await _categoryService.CreateCategory(createCategoryDto, (Guid)employeeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [HttpPut]
        [Route("Update/{categoryId}/{employeeId}")]
        [ProducesResponseType(typeof(GetCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCategoryDto>> UpdateCategory(Guid? categoryId, Guid? employeeId, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var result = await _categoryService.UpdateCategory((Guid)categoryId!, updateCategoryDto, (Guid)employeeId!);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

        [HttpPost]
        [Route("Remove/{categoryId}/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteCategory(Guid? categoryId, Guid? employeeId)
        {
            try
            {
                await _categoryService.SoftDeleteCategory((Guid)categoryId!, (Guid)employeeId!);
                return Ok("Category removed");
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }

    }
}

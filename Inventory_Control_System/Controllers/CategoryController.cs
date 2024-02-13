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
        [Route("Create")]
        [ProducesResponseType(typeof(GetCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCategoryDto>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            try
            {
                var result = await _categoryService.CreateCategory(createCategoryDto);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }
    }
}

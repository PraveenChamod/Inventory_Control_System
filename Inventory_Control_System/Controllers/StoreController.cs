using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Common;
using Data_Access_Layer.DTOs.Store;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(GetStoreDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommonErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetStoreDto>> CreateStore([FromBody] CreateStoreDto createStoreDto)
        {
            try
            {
                var result = await _storeService.CreateStore(createStoreDto);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new CommonErrorDto { Message = ex.Message, Code = 400 });
            }
        }
    }
}

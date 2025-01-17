using Guider.Application.Interfaces;
using Guider.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryReq req)
        {
            try
            {
                await _categoryService.CreateAsync(req);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Create Category error.");
            }
        }
    }
}

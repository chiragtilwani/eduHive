using FeatureObjects.Abstraction.AbstractObject;
using Microsoft.AspNetCore.Mvc;

namespace get.Knowledge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryManager _courseCategoryManager;
        public CourseCategoryController(ICourseCategoryManager courseCategoryManager)
        {
            _courseCategoryManager = courseCategoryManager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _courseCategoryManager.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _courseCategoryManager.GetAllAsync();
            return Ok(result);
        }
    }
}

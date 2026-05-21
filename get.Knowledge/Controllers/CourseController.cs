using DataStore.Abstraction.Enums;
using FeatureObjects.Abstraction.AbstractObject;
using Microsoft.AspNetCore.Mvc;

namespace get.Knowledge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await _courseManager.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCourses(CourseCategoryEnum? categoryId = null)
        {
            var result = await _courseManager.GetAllAsync(categoryId);
            return Ok(result);
        }
    }
}

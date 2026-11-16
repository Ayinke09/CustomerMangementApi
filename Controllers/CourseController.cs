using CustomerMangementApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMangementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _serv;
            public CourseController(ICourseServices serv)
        {
            _serv = serv;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _serv.GetAllAsync();
            return Ok(courses);
        }
        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _serv.GetByIdAsync(id)

    }
}

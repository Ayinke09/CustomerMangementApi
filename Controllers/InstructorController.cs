using CustomerMangementApi.DTO.CourseDto;
using CustomerMangementApi.DTO.InstructorDto;
using CustomerMangementApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMangementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorServices _serv;
        public InstructorController(IInstructorServices serv)
        {
            _serv = serv;
        }
        [HttpGet]
        public async Task<IActionResult> GetInstructor()
        {
            var Instructor = await _serv.GetAllAsync();
            return Ok();
        }

        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var Instructor = await _serv.GetByIdAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateInstructorDto model)
        {
            var Instructor = await _serv.AddAsync(model);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync([FromQuery] int id, [FromBody] UpdateInstructorDto model)
        {
            var Instructor = await _serv.UpdateAsync(id, model);
            return Ok(Instructor);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _serv.DeleteAsync(id);
            return NoContent();
        }

    }
}

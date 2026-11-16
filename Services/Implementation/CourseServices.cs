using CustomerMangementApi.DTO.CourseDto;
using CustomerMangementApi.Model;
using CustomerMangementApi.Repository.Interface;
using CustomerMangementApi.Services.Interface;

namespace CustomerMangementApi.Services.Implementation
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository _repo;
        public CourseServices(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task<CourseResponseDto> AddAsync(CourseCreateDto model)
        {
            var course = new Course
            {
                Title = model.Title,
                Credits = model.Credits,
                Description = model.Description,
                InstructorId = model.InstructorId

            };
            var created = await _repo.AddAsync(course);
          
            return new CourseResponseDto
            {
                Title = created.Title,
                Credits = created.Credits,
                Description = created.Description,
                InstructorId = created.InstructorId
            };
        }



        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);

        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllAsync()
        {
            var course = await _repo.GetAllAsync();
            return course.Select(c => new CourseResponseDto
            {
                    Title = c.Title,
                    Credits = c.Credits,
                    Description = c.Description,
                    InstructorId = c.InstructorId,
                
            });
           

            
        }

        public async Task<CourseResponseDto> GetByIdAsync(int id)
        {
            var created= await _repo.GetByIdAsync(id);
            return new CourseResponseDto
            {
                Title = created.Title,
                Credits = created.Credits,
                Description = created.Description,
                InstructorId = created.InstructorId
            };
        }

        public async Task<CourseResponseDto> UpdateAsync(int id, CourseUpdateDto model)
        {
            var courses = await _repo.GetByIdAsync(id);
            courses.Title = !string.IsNullOrEmpty(model.Title) ? model.Title : courses.Title;
            courses.Credits = model.Credits != 0 ? model.Credits : courses.Credits;
            courses.Description = !string.IsNullOrEmpty(model.Description) ? model.Description : courses.Description;
            courses.InstructorId = model.InstructorId != 0 ? model.InstructorId : courses.InstructorId;

            await _repo.UpdateAsync(courses);
            return new CourseResponseDto
            {
                Title = courses.Title,
                Credits = courses.Credits,
                Description = courses.Description,
                InstructorId = courses.InstructorId
            };
        }
    }
}

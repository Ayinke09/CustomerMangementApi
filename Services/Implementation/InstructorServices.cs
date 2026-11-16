using CustomerMangementApi.DTO.CourseDto;
using CustomerMangementApi.DTO.InstructorDto;
using CustomerMangementApi.InstructorRepository.Interface;
using CustomerMangementApi.Model;
using CustomerMangementApi.Services.Interface;

namespace CustomerMangementApi.Services.Implementation
{
    public class InstructorServices : IInstructorServices
    {
        private readonly IInstructorRepository _repo;
        public InstructorServices(IInstructorRepository repo)
        {
            _repo = repo;
        }
        public async Task<InstructorResponseDto> AddAsync(CreateInstructorDto model)
        {
            var instructor = new Instructor
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone
            };
            await _repo.AddAsync(instructor);
            return new InstructorResponseDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Email = instructor.Email,
                Phone = instructor.Phone

            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InstructorResponseDto>> GetAllAsync()
        {
            var instructors = await _repo.GetAllAsync();
            return instructors.Select(i => new InstructorResponseDto
            {
                Id = i.Id,
                Name = i.Name,
                Email = i.Email,
                Phone = i.Phone
            });
        }

        public async Task<InstructorResponseDto> GetByIdAsync(int id)
        {
            var instructor = await _repo.GetByIdAsync(id);
            return new InstructorResponseDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Email = instructor.Email,
                Phone = instructor.Phone
            };
        }

        public async Task<InstructorResponseDto> UpdateAsync(int id, UpdateInstructorDto model)
        {
            var instructor = await _repo.GetByIdAsync(id);
            instructor.Name = !string.IsNullOrEmpty(model.Name) ? model.Name : instructor.Name;
            instructor.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : instructor.Email;
            instructor.Phone = !string.IsNullOrEmpty(model.Phone) ? model.Phone : instructor.Phone;

            await _repo.UpdateAsync(instructor);
            return new InstructorResponseDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Email = instructor.Email,
                Phone = instructor.Phone
            };
        }
    }
}

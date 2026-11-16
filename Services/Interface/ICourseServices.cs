using CustomerMangementApi.DTO.CourseDto;
using CustomerMangementApi.Model;

namespace CustomerMangementApi.Services.Interface
{
    public interface ICourseServices
    {
        Task<IEnumerable<CourseResponseDto>> GetAllAsync();
        Task<CourseResponseDto> GetByIdAsync(int id);
        Task<CourseResponseDto> AddAsync(CourseCreateDto model);
        Task<CourseResponseDto> UpdateAsync(int id, CourseUpdateDto model);
        Task DeleteAsync(int id);

    }
}

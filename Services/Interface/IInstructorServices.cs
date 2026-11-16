using CustomerMangementApi.DTO;
using CustomerMangementApi.DTO.InstructorDto;
using CustomerMangementApi.Model;

namespace CustomerMangementApi.Services.Interface
{
    public interface IInstructorServices
    {
       Task<IEnumerable<InstructorResponseDto>> GetAllAsync();
        Task<InstructorResponseDto> GetByIdAsync(int id);
        Task<InstructorResponseDto> AddAsync(CreateInstructorDto model);
        Task<InstructorResponseDto> UpdateAsync(int id, UpdateInstructorDto model);
        Task DeleteAsync(int id);
    }
}

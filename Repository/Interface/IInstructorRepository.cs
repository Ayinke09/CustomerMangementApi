using CustomerMangementApi.Model;

namespace CustomerMangementApi.InstructorRepository.Interface
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetAllAsync();
        Task<Instructor> GetByIdAsync(int id);
        Task<Instructor> AddAsync(Instructor model);
        Task<Instructor> UpdateAsync(Instructor model);
        Task DeleteAsync(int id);
    }
}

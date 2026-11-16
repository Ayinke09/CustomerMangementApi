using CustomerMangementApi.Model;

namespace CustomerMangementApi.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> AddAsync(Course model);
        Task<Course> UpdateAsync(Course model);
        Task DeleteAsync(int id);

    }
}

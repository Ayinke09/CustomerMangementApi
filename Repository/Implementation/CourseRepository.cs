using CustomerMangementApi.Context;
using CustomerMangementApi.Model;
using CustomerMangementApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerMangementApi.Repository.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _db;
        public CourseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Course> AddAsync(Course model)
        {
            var result = await _db.Courses.AddAsync(model);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            _db.Remove(await GetByIdAsync(id));
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _db.Courses
               .Include(x => x.InstructorId)
               .OrderByDescending(x => x.InstructorId)
               .Take(10)
               .ToListAsync();

        }

        public async Task<Course> GetByIdAsync(int id)
        {
           return await _db.Courses
                 .Include(x => x.InstructorId)
                .FirstOrDefaultAsync(x => x.Id == id);
           
        }

        public async Task<Course> UpdateAsync(Course model)
        {
            var result = _db.Courses.Update(model);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
    }
}

using CustomerMangementApi.Context;
using CustomerMangementApi.InstructorRepository.Interface;
using CustomerMangementApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerMangementApi.InstructorRepository.Implementation
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _db;
        public InstructorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Instructor> AddAsync(Instructor model)
        {
            var result = await _db.Instructors.AddAsync(model);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

       
        public async Task DeleteAsync(int id)
        {
            _db.Remove(await GetByIdAsync(id));
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
          return await _db.Instructors
            .Include(x => x.Courses)
            .ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
           return await _db.Instructors
            .Include(x => x.Courses)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Instructor> UpdateAsync(Instructor model)
        {
           var result = _db.Instructors.Update(model);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
    }
}

using CustomerMangementApi.Model;

namespace CustomerMangementApi.DTO.InstructorDto
{
    public class CreateInstructorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}

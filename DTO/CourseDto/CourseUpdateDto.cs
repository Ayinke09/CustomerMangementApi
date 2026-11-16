using CustomerMangementApi.Model;

namespace CustomerMangementApi.DTO.CourseDto
{
    public class CourseUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}

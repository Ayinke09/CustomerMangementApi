namespace CustomerMangementApi.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}

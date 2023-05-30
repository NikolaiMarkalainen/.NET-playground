namespace School.Models
{
    public class EnrolledCourses
    {
        public string? EnrolledCourseId { get; set; }
        public string? CourseName { get; set; }
        public ICollection <Student>? Students { get; set; }
        public Teacher? Teacher { get; set; }
        public int StudentPoints { get; set; } = 0;

    }
}
namespace School.Models
{
    public class AvailableCourses
    {
        public string? AvailableCourseId { get; set; }
        public string? CourseName { get; set; }
        public ICollection <Student>? Students { get; set; }
        public Teacher? Teacher { get; set; }
        public int StudentPoints { get; set; }

    }
}
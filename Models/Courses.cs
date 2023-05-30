namespace School.Models
{
    public class Courses
    {
        public Student? Student { get; set; }
        public ICollection<AvailableCourses>? AvailableCourses { get; set; }
        public ICollection<EnrolledCourses>? EnrolledCourses  { get; set; }
    }
}
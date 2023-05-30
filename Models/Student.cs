namespace School.Models
{
    public class Student:User
    {
        public string? StudentId { get; set; }
        public string? Name  { get; set; }
        public string? ClassGroup { get; set; }
        public ICollection<Courses>? Courses { get; set; }
        public int StudentPoints { get; set; } = 0;
        public string? Grades {get; set;}

        public Student()
        {
            UserType = UserStatusType.Student;
        }
    }
}
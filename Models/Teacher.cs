namespace School.Models
{
    public class Teacher:User
    {
        public string TeacherId  { get; set; }
        public string Name  { get; set; }
        public ICollection<Courses> Courses  { get; set; }
        public string Title { get; set; }
    }
}
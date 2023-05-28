namespace School.Models
{
    public class Principal:User
    {
        public string PrincipalId { get; set; }
        public string Name  { get; set; }
        public ICollection<Courses> Courses { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
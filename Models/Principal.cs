namespace School.Models
{
    public class Principal:User
    {
        public string PrincipalId { get; set; } = "1";
        public string? Name  { get; set; }
        public ICollection<Courses>? Courses { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public Principal()
        {
            UserType = UserStatusType.Principal;
        }
    }
}
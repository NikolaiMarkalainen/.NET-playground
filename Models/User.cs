using System.Text.Json.Serialization;

namespace School.Models
{
    public class User
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum UserStatusType
        {
            Student,
            Teacher,
            Principal,
            Admin
        }
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Password  { get; set; }
        public UserStatusType UserType { get; set; }
    }
}
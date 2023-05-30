using School.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly string _courseApiUrl = "http://localhost:5252/api/Courses";
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = "3",
                Name = "Tikku ukko",
                StudentPoints = 107,

            }
        };
 
        [HttpGet]
        public async Task<ActionResult<Student>> Get() 
        {
            foreach (var student in students)
            {
                var courses = await GetCoursesFromApi();
                student.Courses = courses;
            }
            return Ok(students);
        }

        private async Task<List<Courses>> GetCoursesFromApi()
        {
            var response = await _httpClient.GetAsync(_courseApiUrl);
            if(response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Courses>>();
                if(courses != null && courses.Any())
                {
                    return courses;
                }
            }
            return new List<Courses>();
        }
    }
}

using School.Models;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly string _availableApiUrl = "http://localhost:5252/api/AvailableCourse";

        [HttpGet]
        public async Task<ActionResult<Courses>> Get()
        {
            var response = await _httpClient.GetAsync(_availableApiUrl);
            if(response.IsSuccessStatusCode)
            {
                var availableCourses = await response.Content.ReadFromJsonAsync<List<AvailableCourses>>();
                if(availableCourses != null && availableCourses.Any())
                {
                    var courses = CreateCourseList(availableCourses);
                    return Ok(courses);
                }
            }
            return NotFound();
        }

        private List<Courses> CreateCourseList(List<AvailableCourses> availableCourses)
        {
            var courses = new List<Courses>();
            foreach(var availableCourse in availableCourses)
            {
                var course = new Courses
                {
                    AvailableCourses = new List<AvailableCourses> { availableCourse },
                    EnrolledCourses = null,
                    Student = null
                };
                courses.Add(course);
            }
            return courses;
        }
    }
}
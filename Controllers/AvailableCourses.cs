using Microsoft.AspNetCore.Mvc;
using School.Models;


namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailableCourseController : ControllerBase
    {
        private static List<AvailableCourses> courses = new List<AvailableCourses>
        {
            new AvailableCourses
            {
                CourseName = "Discrete mathematics",
                StudentPoints = 3,
                Teacher = new Teacher
                {
                    TeacherId = "1",
                    Name = "John Smith",
                    Title = "Mathematics Teacher"
                }
            },
            new AvailableCourses
            {
                CourseName = "Trigonometry",
                StudentPoints = 3,
                Teacher = new Teacher
                {
                    TeacherId = "2",
                    Name = "Jane Smith",
                    Title = "Mathematics Teacher"
                }
            }
        };
        [HttpGet]
        public ActionResult<List<AvailableCourses>> Get()
        {
            return Ok(courses);
        }
    }
}